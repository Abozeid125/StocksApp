
using Entities;
using System.Runtime.CompilerServices;

namespace StocksAppAss.DTOS
{
	public class BuyOrderResponse
	{

		public Guid? BuyOrderID { get; set; }

		public string? StockSymbol { get; set; }


		public string? StockName { get; set; }

		public DateTime? DateAndTimeOfOrder { get; set; }

		public uint? Quantity { get; set; }

		public double? Price { get; set; }

		public double? TradeAmount { get; set; }

		public override bool Equals(object? obj)
		{
			BuyOrderResponse? other = obj as BuyOrderResponse;

			return StockName == other.StockName && StockSymbol == other.StockSymbol && DateAndTimeOfOrder == other.DateAndTimeOfOrder &&
				Quantity == other.Quantity && Price == other.Price && TradeAmount == other.TradeAmount;
		}


	}


	public static class BuyOrderExtensions {


		public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
		{


			return new BuyOrderResponse { BuyOrderID = buyOrder.Id, Price = buyOrder.Price,
				StockName = buyOrder.StockName, StockSymbol = buyOrder.StockSymbol, Quantity = buyOrder.Quantity,
				DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
				TradeAmount = buyOrder.Quantity * buyOrder.Price,

			};



		}
	} 

}
