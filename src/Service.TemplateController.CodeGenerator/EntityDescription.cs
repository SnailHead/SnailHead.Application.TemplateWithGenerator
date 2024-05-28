using System.Collections.Generic;
using System.Linq;
using CodeGeneration.ServerCodeGenerator.Enums;

namespace CodeGeneration.ServerCodeGenerator;

internal class EntityDescription
{
	internal string Name { get; set; }
	internal string PluralName { get; set; }
	internal IList<PropertyDescription> Properties { get; set; }
	internal Dictionary<string, string> FilterProperties { get; set; }

	public EntityDescription()
	{
	}

	public EntityDescription(string name, string pluralName, Dictionary<string, string> filterProperties)
	{
		Name = name;
		PluralName = pluralName;
		Properties = new List<PropertyDescription>();
		FilterProperties = filterProperties;
	}

	internal EntityDescription ExcludeNewProperties()
	{
		return new EntityDescription
		{
			Name = Name,
			PluralName = PluralName,
			FilterProperties = FilterProperties,
			Properties = Properties.Where(item => !item.IsNew).ToList()
		};
	}
}