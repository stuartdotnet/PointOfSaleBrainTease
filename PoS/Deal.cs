using System.Diagnostics;

namespace PoS
{
	[DebuggerDisplay("{DealQuantity} for ${DealCost}")]
	public class Deal
	{
		public int DealQuantity { get; set; }
		public decimal DealCost { get; set; }
	}
}
