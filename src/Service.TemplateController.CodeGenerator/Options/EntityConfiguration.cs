namespace CodeGeneration.ServerCodeGenerator.Options;

public class EntityConfiguration
{
    public string EntityName { get; set; }
    public string? AuthenticationScheme { get; set; }
    public bool NeedApi { get; set; } = true;
    public bool NeedUnitTest { get; set; } = true;
}