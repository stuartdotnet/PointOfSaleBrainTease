using System.Diagnostics;

namespace PoS
{
	[DebuggerDisplay("{ProductCode} ${PriceEach} each")]
	public class ProductType
	{
		public string ProductCode { get; set; }
		public decimal PriceEach { get; set; }

		public Deal Deal { get; set; }
		public bool HasDeal { get { return this.Deal != null; } }
	}
}
