using Entities;
using Microsoft.EntityFrameworkCore;
using StocksAppAss.Entities;
using StocksAppAss.RepositeryContracts;

namespace StocksAppAss.Repositeries
{
	public class StockRepositery : IStockRepositery
	{
		private readonly StockDbContext _Context;

		public StockRepositery(StockDbContext stockDbContext) {
			_Context = stockDbContext;
		}


		public async Task<BuyOrder> AddBuyOrder(BuyOrder buyOrder)
		{
			 await _Context.BuyOrders.AddAsync(buyOrder);
			await _Context.SaveChangesAsync();
			return buyOrder;
		}

		public async Task<SellOrder> AddSellOrder(SellOrder sellOrder)
		{
			await _Context.SellOrders.AddAsync(sellOrder);
			await _Context.SaveChangesAsync();

			return sellOrder;
		}

		public  async Task<List<BuyOrder>> GetBuyOrders()
		{
			return await _Context.BuyOrders.ToListAsync();
		}

		public  async Task<List<SellOrder>> GetSellOrders()
		{
			return await _Context.SellOrders.ToListAsync();
		}
	}
}
