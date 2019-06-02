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
			bool isProductDeal = products.Any(p => p.ProductType.HasDeal);

			IPricingStrategy pricingStrategy;

			if (isProductDeal)
			{
				pricingStrategy = new DealPricingStrategy(products.Select(p => p.ProductType.Deal).First());
			}
			else
			{
				pricingStrategy = new DefaultPricingStrategy();
			}

			return pricingStrategy.GetTotal(products);
		}
	}
}
