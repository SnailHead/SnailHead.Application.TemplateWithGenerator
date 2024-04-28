using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodeGeneration.ServerCodeGenerator
{
	internal class MicrosoftBuildProject
	{
		public string Path { get; set; }
		private readonly XmlDocument document;
		private Dictionary<string, XmlNode> BuildActionToSectionDictionary { get; set; }

		public MicrosoftBuildProject(string path)
		{
			Path = path;
			document = new XmlDocument();
			document.Load(path);
			BuildActionToSectionDictionary = new Dictionary<string, XmlNode>();
		}
		
		public void Save()
		{
			document.Save(Path);
		}

		public class Item
		{
			public string Path { get; set; }
			public string BuildAction { get; set; }

			public Item(string path, string buildAction)
			{
				Path = path;
				BuildAction = buildAction;
			}
		}
	}
}
