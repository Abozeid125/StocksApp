using Entities;

namespace StocksAppAss.RepositeryContracts
{
	public interface IStockRepositery
	{


		Task<BuyOrder> AddBuyOrder(BuyOrder buyOrder);
		Task<SellOrder> AddSellOrder(SellOrder sellOrder);

		Task<List<BuyOrder>> GetBuyOrders();

		Task<List<SellOrder>> GetSellOrders();


	}
}
