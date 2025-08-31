using Entities;
using System.ComponentModel.DataAnnotations;



namespace StocksAppAss.DTOS
{
	public class BuyOrderRequest
	{


		[Required(ErrorMessage = "Stock Symbol can't be blank")]
		public string? StockSymbol { get; set; }

		[Required(ErrorMessage = "Stock name can't be blank")]

		public string? StockName { get; set; }

		public DateTime? DateAndTimeOfOrder { get; set; }


		[Range(1, 100000, ErrorMessage = "Quantity is out of range should be between (1,100000")]
		public uint? Quantity { get; set; }

		[Range(1, 100000, ErrorMessage = "Price is out of range should be between (1,100000")]

		public double? Price { get; set; }


		public BuyOrder ToBuyOrder ()
		{


			return new BuyOrder
			{
				StockSymbol = StockSymbol,
				StockName = StockName,
				DateAndTimeOfOrder = DateAndTimeOfOrder,
				Quantity = Quantity,
				Price = Price
			}; 

		}





	}
}
