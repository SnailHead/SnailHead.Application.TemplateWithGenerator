﻿using System.Collections.Generic;
using System.Linq;
using CodeGeneration.ServerCodeGenerator.Enums;

namespace CodeGeneration.ServerCodeGenerator
{
	internal class EntityDescription
	{
		internal string Name { get; set; }
		internal string PluralName { get; set; }
		internal GeneratedFiles Files { get; set; }
		internal IList<PropertyDescription> Properties { get; set; }

		public EntityDescription()
		{
		}

		public EntityDescription(string name, string pluralName, GeneratedFiles generatedFiles)
		{
			Name = name;
			PluralName = pluralName;
			Files = generatedFiles;
			Properties = new List<PropertyDescription>();
		}

		internal EntityDescription ExcludeNewProperties()
		{
			return new EntityDescription
			{
				Name = Name,
				PluralName = PluralName,
				Properties = Properties.Where(item => !item.IsNew).ToList()
			};
		}
	}
}
