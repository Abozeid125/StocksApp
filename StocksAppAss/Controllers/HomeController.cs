using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksAppAss.ServiceContracts;
using StocksAppAss.Models;

namespace StocksAppAss.Controllers
{
	public class HomeController : Controller
	{
		private readonly IFinnHubService _myService;
		private readonly IOptions<TradingOptions> _options;

		public HomeController(IFinnHubService myService, IOptions<TradingOptions> options)

		{
			_myService = myService;
			_options = options;
		}


		//[Route("/")]
		//public async Task<IActionResult> Index()
		//{

		//	if (_options.Value.DefaultStockSymbol == null)
		//	{


		//		_options.Value.DefaultStockSymbol = "MSFT";
		//	}

		//	Dictionary<string, object>? response = await _myService.GetStockPriceQuote(_options.Value?.DefaultStockSymbol);

		//	Stock stock = new Stock
		//	{
		//		StockSymbol = _options.Value.DefaultStockSymbol,
		//		CurrentPrice = Convert.ToDouble(response["c"].ToString()),
		//		HighestPrice = Convert.ToDouble(response["h"].ToString()),
		//		LowestPrice = Convert.ToDouble(response["l"].ToString()),
		//		OpenPrice = Convert.ToDouble(response["o"].ToString()),




		//	};
		//	return View(stock);
		//}


		//[Route("/profile")]
		//public async Task<IActionResult> Profile()
		//{



		//	if (_options.Value.DefaultStockSymbol == null)
		//	{


		//		_options.Value.DefaultStockSymbol = "MSFT";
		//	}

		//	Dictionary<string, object>? response = await _myService.GetCompanyProfile(_options.Value?.DefaultStockSymbol);



		//	StockProfile stockProfile = new StockProfile
		//	{
		//		Country = response["country"]?.ToString(),
		//		Currency = response["currency"].ToString()
		//		, Name = response["name"].ToString(),
		//		Phone = response["phone"].ToString()


		//	};




		//	return View(stockProfile);
		//}


		[Route("/")]
		[Route("stock")]
		[Route("stock/explore/{stock?}")]

		public async Task<IActionResult> Explore(string? stock, bool viewAll = false)
		{

			List<Dictionary<string,string>> data = await _myService.GetStocks();

			List<StockTrade> stocks = new List<StockTrade>();

			if(data != null)
			{

				if(!viewAll && _options.Value.Top25PopularStocks != null)
				{

					string[]? Top25PopularStocksList = _options.Value.Top25PopularStocks.Split(',');

					if(Top25PopularStocksList != null)
					{

						data = data.Where(temp => Top25PopularStocksList.Contains(temp["symbol"].ToString())).ToList();



					}


				}

				stocks = data.Select(temp => new StockTrade { StockName = temp["description"].ToString(), StockSymbol = temp["symbol"].ToString() }).ToList();


			}

			ViewBag.stock = stock;

			return View(stocks);




		}





	}
}
