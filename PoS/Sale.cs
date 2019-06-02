using PoS.PricingStrategy;
using System.Collections.Generic;
using System.Linq;

namespace PoS
{
	public class Sale
	{
		public Sale()
		{
			this.Products = new List<Product>();
		}

		public List<Product> Products { get; set; }

		public decimal GetTotal()
		{
			decimal total = 0;
			foreach (var productCode in this.Products.Select(p => p.ProductType.ProductCode).Distinct())
			{
				total += ProductTotal(productCode);
			}

			return total;
		}

		private decimal ProductTotal(string productCode)
		{
			var products = this.Products.Where(p => p.ProductType.ProductCode == productCode);

			if (!products.Any()) return 0;

			// all products have the same product type so grab the first
			var productType = products.Select(p => p.ProductType).First();
			
			IPricingStrategy pricingStrategy;

			if (productType.HasDeal)
			{
				pricingStrategy = new DealPricingStrategy(productType.Deal);
			}
			else
			{
				pricingStrategy = new DefaultPricingStrategy();
			}

			return pricingStrategy.GetTotal(products);
		}
	}
}
