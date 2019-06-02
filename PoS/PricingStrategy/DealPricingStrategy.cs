using System.Collections.Generic;
using System.Linq;

namespace PoS.PricingStrategy
{
	public class DealPricingStrategy : IPricingStrategy
	{
		private Deal _deal;

		public DealPricingStrategy(Deal deal)
		{
			_deal = deal;
		}

		public decimal GetTotal(IEnumerable<Product> productCollection)
		{
			// first calculate cost of items that didn't make the deal
			int productsNotInDealCount = productCollection.Count() % _deal.DealQuantity;
			decimal total = productsNotInDealCount * productCollection.Select(p => p.ProductType.PriceEach).First();

			// Then add the deal totals
			int productsWithDealCount = productCollection.Count() - productsNotInDealCount;
			decimal dealsCount = productsWithDealCount / _deal.DealQuantity;

			total += _deal.DealCost * dealsCount;
			return total;
		}
	}
}
