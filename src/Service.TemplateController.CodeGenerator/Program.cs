using System;
using CodeGeneration.ServerCodeGenerator;
using CodeGeneration.ServerCodeGenerator.Enums;
using CodeGeneration.ServerCodeGenerator.MergeUtilities;
var generator = new CodeGenerator(args[0], Console.Out, new KDiff3MergeUtility());
if (generator.ExistingFilesProcessMode == ExistingFilesProcessMode.Overwrite)
{
Console.WriteLine("ВНИМАНИЕ! Все существующие файлы будут перезаписаны. Нажмите ENTER для продолжения.");
Console.ReadLine();
}
generator.Generate();
Console.WriteLine("Завершено");

