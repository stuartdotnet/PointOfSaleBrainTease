using System.Collections.Generic;

namespace PoS.PricingStrategy
{
	public interface IPricingStrategy
	{
		decimal GetTotal(IEnumerable<Product> productCollection);
	}
}
