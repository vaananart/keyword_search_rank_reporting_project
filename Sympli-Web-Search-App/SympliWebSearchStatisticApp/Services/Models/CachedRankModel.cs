using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Services.Models
{
	public class CachedRankModel
	{
		public string EngineName { get; set; }
		public string KeyWordSearch { get; set; }
		public string RankWordSearch { get; set; }
		public DateTime LastQueriedDateTime { get; set; }
		public int?[] RankResult { get; set; }
	}
}
