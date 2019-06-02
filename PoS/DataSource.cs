using System.Collections.Generic;

namespace PoS
{
	// For a more complex program we would add an interface to this for dependency injection etc
	public static class DataSource
	{
		public static IEnumerable<ProductType> ProductTypes {
			get
			{
				List<ProductType> productTypes = new List<ProductType>();
				productTypes.Add(new ProductType { ProductCode = "A", PriceEach = 1.25m, Deal = new Deal { DealQuantity = 3, DealCost = 3m } });
				productTypes.Add(new ProductType { ProductCode = "B", PriceEach = 4.25m });
				productTypes.Add(new ProductType { ProductCode = "C", PriceEach = 1.00m, Deal = new Deal { DealQuantity = 6, DealCost = 5 } });
				productTypes.Add(new ProductType { ProductCode = "D", PriceEach = 0.75m });

				return productTypes;
			}
		}
	}
}
