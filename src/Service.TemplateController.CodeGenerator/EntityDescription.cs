using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeGeneration.ServerCodeGenerator.Enums;

namespace CodeGeneration.ServerCodeGenerator;

internal class EntityDescription
{
	internal string Name { get; set; }
	internal string PluralName { get; set; }
	internal IList<PropertyInfo> Properties { get; set; }
	internal Dictionary<string, string> FilterProperties { get; set; }

	public EntityDescription()
	{
	}

	public EntityDescription(string name, string pluralName, Dictionary<string, string> filterProperties, IEnumerable<PropertyInfo> properties)
	{
		Name = name;
		PluralName = pluralName;
		Properties = new List<PropertyInfo>();
		FilterProperties = filterProperties;
		Properties = properties.ToList();
	}
}