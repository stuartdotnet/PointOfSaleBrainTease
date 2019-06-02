using System.Diagnostics;

namespace PoS
{

	[DebuggerDisplay("{ProductType.ProductCode}")]
	public class Product 
	{
		public Product(ProductType productType)
		{
			this.ProductType = productType;
		}

		public ProductType ProductType { get; }
	}
}
