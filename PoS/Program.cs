using System;
using System.Collections.Generic;

namespace PoS
{
	class Program
	{
		static void Main(string[] args)
		{
			var terminal = new PointOfSaleTerminal();
			terminal.SetPricing();

			terminal.Scan("A");
			// etc
		}
	}
}
