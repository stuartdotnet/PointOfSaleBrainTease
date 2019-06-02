using System.Collections.Generic;
using System.Linq;

namespace PoS
{
	public class PointOfSaleTerminal
	{
		private Sale _sale;
		private List<ProductType> _productTypes;

		public PointOfSaleTerminal()
		{
			_sale = new Sale();
		}

		public void SetPricing()
		{
			_productTypes = new List<ProductType>();
			_productTypes.Add(new ProductType { ProductCode = "A", PriceEach = 1.25m, Deal = new Deal { DealQuantity = 3, DealCost = 3m } });
			_productTypes.Add(new ProductType { ProductCode = "B", PriceEach = 4.25m });
			_productTypes.Add(new ProductType { ProductCode = "C", PriceEach = 1.00m, Deal = new Deal { DealQuantity = 6, DealCost = 5m } });
			_productTypes.Add(new ProductType { ProductCode = "D", PriceEach = 0.75m });
		}

		public void Scan(string productCode)
		{
			var productType = _productTypes.SingleOrDefault(p => p.ProductCode == productCode);
			if (productType != null)
			{
				_sale.Products.Add(new Product(productType));
			}
			else
			{
				throw new System.Exception("Product Code not on this");
			}
		}

		public decimal GetSaleTotal()
		{
			return _sale.GetTotal();
		}
	}
}
