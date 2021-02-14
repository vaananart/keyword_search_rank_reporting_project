using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SympliWebSerchStatisticAppTests.Util
{
	public class TestSampleDataExtractor
	{
		static public List<string> Extract(string fileName)
		{
			var assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(fileName));
			string content = String.Empty;
			List<string> lines = new List<string>();

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					//if (line.Contains("//") == false)
					lines.Add(line);
				}

				content = reader.ReadToEnd();
			}

			return lines;
		}
	}
}
