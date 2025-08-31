using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Rotativa.AspNetCore;
using StocksAppAss.DTOS;
using StocksAppAss.Models;
using StocksAppAss.ServiceContracts;

namespace StocksAppAss.Controllers
{
    public class TradeController : Controller
    {

        private readonly IFinnHubService _myService;
        private readonly IOptions<TradingOptions> _options;
        private readonly IStockServices _stockServices;

        public TradeController(IFinnHubService myService, IOptions<TradingOptions> options, IStockServices stockServices)

        {
            _myService = myService;
            _options = options;
            _stockServices = stockServices;
        }



        [Route("/Trade/Index/{stockSymbol}")]
        public async Task<IActionResult> Index(string stockSymbol)
        {
            string symbol;

            if (!string.IsNullOrEmpty(stockSymbol))
            {
                symbol = stockSymbol;

            }
            else symbol = "MSFT";
          

            Dictionary<string, object>? quoteResponse = await _myService.GetStockPriceQuote(symbol);
            Dictionary<string, object>? profileResponse = await _myService.GetCompanyProfile(symbol);


            StockTrade stockTrade = new StockTrade()
            {
                StockSymbol = symbol,
                StockName = profileResponse["name"].ToString()
                , StockPrice = Convert.ToDouble( quoteResponse["c"].ToString()),
                StockQuantity = Convert.ToInt32( _options.Value.DefaultOrderQuantity)
                




            };







            return View(stockTrade);
        }


        


        [Route("Trade/Orders")]
        public async Task< IActionResult> Orders()
        {

          

            List<BuyOrderResponse> BoughtOrders = await _stockServices.GetBuyOrders();

            List<SellOrderResponse> SoldOrders = await _stockServices.GetSellOrders();

            ViewBag.BuyOrders = BoughtOrders;
            ViewBag.SellOrders = SoldOrders;
            


              return  View();
        }

        [HttpPost]
        [Route("/Trade/BuyOrder")]
        public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade
                {
                    StockName = buyOrderRequest.StockName,
                    StockPrice = buyOrderRequest.Price,
                    StockSymbol = buyOrderRequest.StockSymbol,
                    StockQuantity = Convert.ToInt32(buyOrderRequest.Quantity)


                };

                return View("Index",stockTrade);


            }

           BuyOrderResponse buyOrderResponse = await _stockServices.CreateBuyOrder(buyOrderRequest);




          return  RedirectToAction("Orders", "Trade");


            

        }

        [HttpPost]
        [Route("/Trade/SellOrder")]
        public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Errors = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade
                {
                    StockName = sellOrderRequest.StockName,
                    StockPrice = sellOrderRequest.Price,
                    StockSymbol = sellOrderRequest.StockSymbol,
                    StockQuantity = Convert.ToInt32(sellOrderRequest.Quantity)


                };

                return View("Index", stockTrade);
            }


            SellOrderResponse sellOrderResponse = await _stockServices.CreateSellOrder(sellOrderRequest);




            return RedirectToAction("Orders", "Trade");




        }


        [Route("/trade/Orderspdf")]

        public async Task<IActionResult> OrdersPDF()
        {
            List<BuyOrderResponse> BoughtOrders = await _stockServices.GetBuyOrders();

            List<SellOrderResponse> SoldOrders = await _stockServices.GetSellOrders();

            ViewBag.BuyOrders = BoughtOrders.OrderByDescending(b => b.DateAndTimeOfOrder);
            ViewBag.SellOrders = SoldOrders.OrderByDescending(s => s.DateAndTimeOfOrder);

            BuyOrderResponse buyOrderResponse = new BuyOrderResponse();
           


            return new ViewAsPdf(ViewData);



        }


    }
}
