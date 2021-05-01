using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Utils.Enums;

namespace SympliWebSearchStatisticApp.Utils.StringSupport
{
	public static class EngineEnumExtension
	{
		public static string ToNormalisedString(this EngineEnum engineEnum)
		{
			return engineEnum.ToString().ToLower().Normalize();
		}
	}
}
