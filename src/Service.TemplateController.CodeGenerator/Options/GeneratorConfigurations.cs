using System.Collections.Generic;

namespace CodeGeneration.ServerCodeGenerator.Options;

public class GeneratorConfigurations
{
    public BaseConfiguration BaseConfiguration { get; set; }
    public List<EntityConfiguration> EntityConfigurations { get; set; } = null;
}