using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Utils.Converters
{
	public static class Converter
	{
		public static T Convert<T>(string text) where T : System.Enum
		{
			if (string.IsNullOrEmpty(text))
				return default(T);

			if (typeof(T).IsEnum)
			{
				var enumArray = Enum.GetValues(typeof(T));

				foreach(T element in enumArray)
				{
					if (element.ToString().ToLower().Normalize() == text.ToLower().Normalize())
						return element;
				}

			}

			return default(T);
		}
	}
}
