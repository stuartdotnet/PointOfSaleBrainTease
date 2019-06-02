using System.Collections.Generic;
using System.Linq;

namespace PoS
{
	public class PointOfSaleTerminal
	{
		private List<Product> _products;

		public PointOfSaleTerminal()
		{
			_products = new List<Product>();
		}

		public void Scan(string productCode)
		{
			_products.Add(new Product(productCode));
		}

		public decimal ProductTotal(string productCode)
		{
			var products = _products.Where(p => p.ProductType.ProductCode == productCode);
			bool isProductDeal = products.Any(p => p.ProductType.HasDeal);
			
			if (isProductDeal)
			{
				int dealQuantityForProductType = products.Select(p => p.ProductType.Deal.DealQuantity).First();

				// first calculate cost of items that didn't make the deal
				int productsNotInDeal = products.Count() % dealQuantityForProductType;
				decimal total = productsNotInDeal * products.Select(p => p.ProductType.PriceEach).First();

				// Then add the deal totals
				total += products.Select(p => p.ProductType.Deal.DealCost).First() * ((products.Count() - productsNotInDeal) / products.Select(p=>p.ProductType.Deal.DealQuantity).First());
				return total;
			}
			else
			{
				return products.Sum(p => p.ProductType.PriceEach);
			}
		}

		public decimal GetGrandTotal()
		{
			decimal total = 0;
			foreach (var productCode in _products.Select(p => p.ProductType.ProductCode).Distinct())
			{
				total += ProductTotal(productCode);
			}

			return total;
		}
	}
}
