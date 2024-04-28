using System;

namespace CodeGeneration.ServerCodeGenerator.Enums
{
	[Flags]
	internal enum GeneratedFiles : long
	{
		None = 0,
		Service = 1 << 3,
		Controller = 1 << 5,
		All = (1 << 8) - 1
	}
}
