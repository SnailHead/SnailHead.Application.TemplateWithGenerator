using System;
using System.IO;
using System.Text.Json;
using CodeGeneration.ServerCodeGenerator;
using CodeGeneration.ServerCodeGenerator.Enums;
using CodeGeneration.ServerCodeGenerator.MergeUtilities;
using CodeGeneration.ServerCodeGenerator.Options;

var stream = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"));
var json = await stream.ReadToEndAsync();
stream.Dispose();
var configurations = JsonSerializer.Deserialize<GeneratorConfigurations>(json);
var generator = new CodeGenerator(configurations, args[0], Console.Out, new KDiff3MergeUtility());
if (generator.ExistingFilesProcessMode == ExistingFilesProcessMode.Overwrite)
{
    Console.WriteLine("ВНИМАНИЕ! Все существующие файлы будут перезаписаны. Нажмите ENTER для продолжения.");
    Console.ReadLine();
}

generator.Generate();
Console.WriteLine("Завершено");