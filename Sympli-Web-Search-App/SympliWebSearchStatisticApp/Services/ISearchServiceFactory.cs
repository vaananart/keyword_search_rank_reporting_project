using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Services
{
	public interface ISearchServiceFactory
	{
		ISearchService GetService(string searchEngineName);
	}
}
