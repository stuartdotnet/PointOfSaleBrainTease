using System;
using System.Diagnostics;
using System.Linq;

namespace PoS
{

	[DebuggerDisplay("{ProductType.ProductCode}")]
	public class Product 
	{
		public Product(string productCode)
		{
			var productType = DataSource.ProductTypes.SingleOrDefault(p => p.ProductCode == productCode);
			this.ProductType = productType ?? throw new Exception("Product Code not found");
		}

		public ProductType ProductType { get; }
	}
}
