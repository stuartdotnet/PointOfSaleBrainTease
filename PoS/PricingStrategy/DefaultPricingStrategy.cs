using System.Collections.Generic;
using System.Linq;

namespace PoS.PricingStrategy
{
	public class DefaultPricingStrategy : IPricingStrategy
	{
		public decimal GetTotal(IEnumerable<Product> productCollection)
		{
			return productCollection.Sum(p => p.ProductType.PriceEach);
		}
	}
}
