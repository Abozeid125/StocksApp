using Entities;

namespace StocksAppAss.DTOS
{
	public class SellOrderResponse
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
            SellOrderResponse? other = obj as SellOrderResponse;


			if (other == null) return false;
            return StockName == other.StockName && StockSymbol == other.StockSymbol && DateAndTimeOfOrder == other.DateAndTimeOfOrder &&
                Quantity == other.Quantity && Price == other.Price && TradeAmount == other.TradeAmount && BuyOrderID == other.BuyOrderID;
        }


    }



    public static class SellOrderExtensions
    {


        public static   SellOrderResponse ToSellOrderResponse(this SellOrder buyOrder)
        {


            return new SellOrderResponse
            {
                BuyOrderID = buyOrder.Id,
                Price = buyOrder.Price,
                StockName = buyOrder.StockName,
                StockSymbol = buyOrder.StockSymbol,
                Quantity = buyOrder.Quantity,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                TradeAmount = buyOrder.Quantity*buyOrder.Price

            };



        }
    }
}
