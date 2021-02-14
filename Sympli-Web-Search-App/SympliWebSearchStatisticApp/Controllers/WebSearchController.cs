using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SympliWebSearchStatisticApp.Models;
using SympliWebSearchStatisticApp.Services;

namespace SympliWebSearchStatisticApp.Controllers
{
	public class WebSearchController : Controller
	{
		private readonly ILogger<WebSearchController> _logger;
		private readonly ISearchServiceFactory _searchFactory;

		public WebSearchController(ILogger<WebSearchController> logger, ISearchServiceFactory searchFactory)
		{
			_logger = logger;
			this._searchFactory = searchFactory;
		}

		[Route("search")]
		[HttpGet]
		public async Task<IActionResult> SearchFirstHunderdEntries(string search, string rank, string searchengine = null )
		{ 
			var searchService = this._searchFactory.GetService(searchengine);
			int?[] result;
			try
			{
				result = await searchService.RetrieveRanksByKeywordSearchAsync(search, rank);
			}
			catch (Exception ex)
			{
				return StatusCode(400, ex.Message);
			}

			return Content(string.Join(", ", result));
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
