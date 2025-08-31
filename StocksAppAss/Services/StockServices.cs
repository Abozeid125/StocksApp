using Entities;
using StocksAppAss.DTOS;
using StocksAppAss.Entities;
using StocksAppAss.Helper;
using StocksAppAss.RepositeryContracts;
using StocksAppAss.ServiceContracts;

namespace StocksAppAss.Services
{
    public class StockServices : IStockServices
    {
       
        
		private readonly IStockRepositery _stockRepositery;

		public StockServices(IStockRepositery stockRepositery ) 
        
        {
      
          
			_stockRepositery = stockRepositery;
		}


        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
           if(buyOrderRequest == null) 
                throw new ArgumentNullException(nameof(buyOrderRequest));


            ValidationHelper.ModelValidations(nameof(buyOrderRequest));

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.Id = Guid.NewGuid();
            await _stockRepositery.AddBuyOrder(buyOrder);
             

               return buyOrder.ToBuyOrderResponse();
                



        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {

            if (sellOrderRequest == null)
                throw new ArgumentNullException(nameof(sellOrderRequest));


            ValidationHelper.ModelValidations(nameof(sellOrderRequest));

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.Id = Guid.NewGuid();
           await  _stockRepositery.AddSellOrder(sellOrder);

            return sellOrder.ToSellOrderResponse();




        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            if (await _stockRepositery.GetBuyOrders()== null)
                return null;

            List<BuyOrder> buyOrders = await _stockRepositery.GetBuyOrders();


			return buyOrders.OrderByDescending(o => o.DateAndTimeOfOrder).Select( o => o.ToBuyOrderResponse()).ToList();


        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {

            if ( await _stockRepositery.GetSellOrders() == null)
                return null;

            List<SellOrder> sellOrders = await _stockRepositery.GetSellOrders();


			return sellOrders.OrderByDescending(o => o.DateAndTimeOfOrder).Select( o => o.ToSellOrderResponse()).ToList();

            
        }
    }
}
