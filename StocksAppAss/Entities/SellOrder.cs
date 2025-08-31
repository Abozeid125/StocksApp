using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class SellOrder
	{


		 public Guid? Id { get; set; }

		public string? StockSymbol { get; set; }

		public string? StockName { get; set; }

		public DateTime? DateAndTimeOfOrder { get; set; }

		public uint? Quantity { get; set; }

		public double? Price { get; set; }




	}
}
