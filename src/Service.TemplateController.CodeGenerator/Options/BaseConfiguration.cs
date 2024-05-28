using System.Text.Json.Serialization;
using CodeGeneration.ServerCodeGenerator.Enums;

namespace CodeGeneration.ServerCodeGenerator.Options;

public class BaseConfiguration
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UsageTemplateEnum UsageTemplate { get; set; }
    public bool NeedUnitTest { get; set; } = true;
    public string? AuthenticationScheme { get; set; }
}