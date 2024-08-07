﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeGeneration.ServerCodeGenerator.Enums;
using CodeGeneration.ServerCodeGenerator.MergeUtilities;
using CodeGeneration.ServerCodeGenerator.Options;
using CodeGeneration.ServerCodeGenerator.Templates;
using Service.TemplateController.DAL.Application.Filters;
using Service.TemplateController.DAL.Database;
using Sharprompt;

namespace CodeGeneration.ServerCodeGenerator;

internal class CodeGenerator
{
	internal TextWriter MessagesWriter { get; }
	internal MergeUtility MergeUtility { get; set; }
	internal string SolutionFolderPath { get; }
	internal ExistingFilesProcessMode ExistingFilesProcessMode { get; }
	internal IList<EntityDescription> Entities { get; }
	internal GeneratorConfigurations Configurations { get; }
	internal int MaxLineWidth { get; set; }

	internal CodeGenerator(GeneratorConfigurations config, string solutionFolderPath, TextWriter messagesWriter = null, 
		MergeUtility mergeUtility = null)
	{
		SolutionFolderPath = solutionFolderPath;
		MessagesWriter = messagesWriter;
		MergeUtility = mergeUtility;
		Configurations = config;
		var dalProjectPath = Path.Combine(SolutionFolderPath, "Service.TemplateController.DAL", "Entities");
		var entityFiles = Directory.GetFiles(dalProjectPath).Where(item => item.EndsWith(".cs"))
			.Select(item => item.Split(Path.DirectorySeparatorChar).LastOrDefault()?.Replace(".cs", string.Empty)).ToArray();
		var assembly = Assembly.GetAssembly(typeof(DefaultDbContext));
		var assemblyTypes = assembly?.GetTypes();
		Entities = new List<EntityDescription>();
		foreach (var item in entityFiles)
		{
			var filterProperty = GetFilterProperty(item, assemblyTypes);
			Entities.Add(new EntityDescription(item, item, filterProperty, 
				assemblyTypes?.First(type => type.Name == item).GetProperties(BindingFlags.Public | BindingFlags.Instance)));
		}
	}

	private Dictionary<string, string> GetFilterProperty(string entityFile, Type[] assemblyTypes)
	{
		PropertyInfo[] properties =
			assemblyTypes.First(item => item.Name == entityFile).GetProperties(BindingFlags.Public | BindingFlags.Instance);

		return properties.Where(item => item.GetCustomAttributes(typeof(IncludeInFilterModelAttribute)).Any())
			.Select(i => (i.PropertyType.Name=="Nullable`1" ? i.PropertyType.GenericTypeArguments[0].Name : i.PropertyType.Name , i.Name))
			.ToDictionary(item => item.Item1, item => item.Item2);
	}
		

	internal void Generate()
	{
		MicrosoftBuildProject project;
		project = new MicrosoftBuildProject(Path.Combine(SolutionFolderPath, "Service.TemplateController.BL", "Service.TemplateController.BL.csproj"));
		GenerateBusinessLogicClasses(project);
		project.Save();
			
		project = new MicrosoftBuildProject(Path.Combine(SolutionFolderPath, "Service.TemplateController.PL", "Service.TemplateController.PL.csproj"));
		switch (Configurations.BaseConfiguration.UsageTemplate)
		{
			case UsageTemplateEnum.Controller:
				GenerateControllers(project);
				break;
			case UsageTemplateEnum.Endpoint:
				GenerateEndpoints(project, Configurations.BaseConfiguration.UsageTemplate);
				break;
			default:
				break;
		}
		var props = GenerateViewModels(project, Configurations.BaseConfiguration.UsageTemplate);
		GenerateMappers(project, Configurations.BaseConfiguration.UsageTemplate, props);
		GenerateFilters(project, Configurations.BaseConfiguration.UsageTemplate);
		project.Save();
		
		if (Configurations.BaseConfiguration.NeedUnitTest)
		{
			project = new MicrosoftBuildProject(Path.Combine(SolutionFolderPath, "Service.TemplateController.Test", "Service.TemplateController.Test.csproj"));
			GenerateTests(project);
		}
		project.Save();
	}
	
	private void GenerateTests(MicrosoftBuildProject project)
	{
		foreach (var description in Entities)
		{
			var testFileName = $"{description.PluralName}ServiceTest.cs";
			var testItem = new MicrosoftBuildProject.Item(Path.Combine("Tests", testFileName), "Compile");
			CreateFileInProject(project, testItem, 
				new UnitTestTemplate(description, MaxLineWidth).TransformText(),
				new UnitTestTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация тестов бизнес-логики {testFileName}...");
			var fileName = $"Mock{description.PluralName}.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("MockData", fileName), "Compile");
			CreateFileInProject(project, item, 
				new MockDataTemplate(description, MaxLineWidth).TransformText(),
				new MockDataTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация конструктора моков {fileName}...");
		}
	}
	private void GenerateBusinessLogicClasses(MicrosoftBuildProject project)
	{
		foreach (var description in Entities)
		{
			var interfaceFileName = $"I{description.PluralName}Service.cs";
			var interfaceItem = new MicrosoftBuildProject.Item(Path.Combine("Services", "Interfaces", interfaceFileName), "Compile");
			CreateFileInProject(project, interfaceItem, 
				new IServiceTemplate(description, MaxLineWidth).TransformText(),
				new IServiceTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация интерфейса бизнес-логики {interfaceFileName}...");
			var fileName = description.PluralName + "Service.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("Services", fileName), "Compile");
			CreateFileInProject(project, item, 
				new ServiceTemplate(description, MaxLineWidth).TransformText(),
				new ServiceTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация класса бизнес-логики {fileName}...");
		}
	}

	private void GenerateControllers(MicrosoftBuildProject project)
	{
		foreach (var description in Entities)
		{
			var fileName = description.PluralName + "Controller.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("Controllers", fileName), "Compile");
			CreateFileInProject(project, item, 
				new ControllerTemplate(description, MaxLineWidth).TransformText(),
				new ControllerTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация контроллера {fileName}...");
		}
	}
	private Dictionary<string, PropertyInfo[]> GenerateViewModels(MicrosoftBuildProject project, UsageTemplateEnum template)
	{
		var props = new Dictionary<string, PropertyInfo[]>();
		foreach (var description in Entities)
		{
			var fileName = description.PluralName + "ViewModel.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("Models", fileName), "Compile");
			var propertyInfos = Prompt.MultiSelect($"Выберите свойства для {description.Name}ViewModel", description.Properties, 15, 0);
			if (!propertyInfos.Any())
			{
				continue;
			}
			CreateFileInProject(project, item, 
				new ViewModelTemplate(description, MaxLineWidth, propertyInfos.ToArray()).TransformText(),
				new ViewModelTemplate(description, MaxLineWidth, propertyInfos.ToArray()).TransformText(), 
				$"Генерация view model {fileName}...");
			props[description.PluralName] = propertyInfos.ToArray();
		}

		return props;
	}
	private void GenerateEndpoints(MicrosoftBuildProject project, UsageTemplateEnum template)
	{
		foreach (var description in Entities)
		{
			var fileName = description.PluralName + "EndPoint.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("EndPoints",  description.PluralName, fileName), "Compile");
			CreateFileInProject(project, item, 
				new ControllerTemplate(description, MaxLineWidth).TransformText(),
				new ControllerTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация контроллера {fileName}...");
		}
	}
	private void GenerateFilters(MicrosoftBuildProject project, UsageTemplateEnum template)
	{
		foreach (var description in Entities)
		{
			if (description.FilterProperties.Count == 0)
				continue;
			var fileName = description.PluralName + "FilterModel.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("Models", "Filters", fileName), "Compile");
			CreateFileInProject(project, item, 
				new FilterModelTemplate(description, MaxLineWidth).TransformText(),
				new FilterModelTemplate(description, MaxLineWidth).TransformText(), 
				$"Генерация фильтра {fileName}...");
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="project"></param>
	/// <param name="template"></param>
	private void GenerateMappers(MicrosoftBuildProject project, UsageTemplateEnum template, Dictionary<string, PropertyInfo[]> props)
	{
		var assembly = Assembly.GetAssembly(typeof(DefaultDbContext));
		var assemblyTypes = assembly?.GetTypes();
		foreach (var description in Entities)
		{ 
			if (!props.TryGetValue(description.PluralName, out var viewModelProps)) continue;
			var fileName = description.PluralName + "MappingProfile.cs";
			var item = new MicrosoftBuildProject.Item(Path.Combine("Mappings", fileName), "Compile");
			var type = assemblyTypes.First(i => i.Name == description.PluralName);
			
			CreateFileInProject(project, item, 
				new MapperTemplate(description, MaxLineWidth, type, viewModelProps).TransformText(),
				new MapperTemplate(description, MaxLineWidth, type, viewModelProps).TransformText(), 
				$"Генерация маппингов {fileName}...");
		}
	}

	private void CreateFileInProject(MicrosoftBuildProject project, MicrosoftBuildProject.Item item, string oldFileContent, string currentFileContent, string infoMessage)
	{
		MessagesWriter?.WriteLine(infoMessage);
		var projectDirectory = new FileInfo(project.Path).Directory.FullName;
		var filePath = Path.Combine(projectDirectory, item.Path);
		new FileInfo(filePath).Directory.Create();
		var fileContent = currentFileContent;
		if (!File.Exists(filePath) || ExistingFilesProcessMode != ExistingFilesProcessMode.Skip)
		{
			if (File.Exists(filePath) && ExistingFilesProcessMode == ExistingFilesProcessMode.Merge && MergeUtility != null)
			{
				var generatedFilePath = filePath + ".generated.tmp";
				File.WriteAllText(generatedFilePath, currentFileContent, Encoding.UTF8);
				var oldFilePath = filePath + ".old.tmp";
				File.WriteAllText(oldFilePath, oldFileContent, Encoding.UTF8);
				var mergedFilePath = filePath + ".merged.tmp";
				File.Delete(mergedFilePath);
				MergeUtility.PerformMerge(oldFilePath, generatedFilePath, filePath, mergedFilePath);
				if (File.Exists(mergedFilePath))
				{
					var sourceContent = File.ReadAllText(filePath, Encoding.UTF8);
					var mergedContent = File.ReadAllText(mergedFilePath, Encoding.UTF8);
					MessagesWriter?.WriteLine(sourceContent != mergedContent
						? "Выполняем объединение изменений."
						: "Файл не изменен.");
					fileContent = mergedContent;
					File.Delete(mergedFilePath);
				}
				else
				{
					MessagesWriter?.WriteLine("Объединение отменено, используем новый файл.");
				}
				File.Delete(generatedFilePath);
				File.Delete(oldFilePath);
			}
			File.WriteAllText(filePath, fileContent, Encoding.UTF8);
		}
		else
		{
			MessagesWriter?.WriteLine("Файл существует, пропускаем.");
		}
	}
}