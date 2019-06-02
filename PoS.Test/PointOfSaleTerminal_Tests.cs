using Xunit;

namespace PoS.Test
{
	public class PointOfSaleTerminal_Tests
	{
		[Fact]
		public void Scan_WhenABCDABA_ThenPriceIs13_25()
		{
			// Arrange
			PointOfSaleTerminal terminal = new PointOfSaleTerminal();
			terminal.SetPricing();

			terminal.Scan("A");
			terminal.Scan("B");
			terminal.Scan("C");
			terminal.Scan("D");
			terminal.Scan("A");
			terminal.Scan("B");
			terminal.Scan("A");

			// Act
			decimal result = terminal.GetSaleTotal();

			// Assert
			Assert.Equal(13.25m, result);
		}

		[Fact]
		public void Scan_WhenCCCCCC_ThenPriceIs6()
		{
			// Arrange
			PointOfSaleTerminal terminal = new PointOfSaleTerminal();
			terminal.SetPricing();
			terminal.Scan("C");
			terminal.Scan("C");
			terminal.Scan("C");
			terminal.Scan("C");
			terminal.Scan("C");
			terminal.Scan("C");
			terminal.Scan("C");

			// Act
			decimal result = terminal.GetSaleTotal();

			// Assert
			Assert.Equal(6m, result);
		}

		[Fact]
		public void Scan_WhenABCD_ThenPriceIs7_25()
		{
			// Arrange
			PointOfSaleTerminal terminal = new PointOfSaleTerminal();
			terminal.SetPricing();
			terminal.Scan("A");
			terminal.Scan("B");
			terminal.Scan("C");
			terminal.Scan("D");

			// Act
			decimal result = terminal.GetSaleTotal();

			// Assert
			Assert.Equal(7.25m, result);
		}

		[Fact]
		public void Scan_WhenNothingScanned_ThenPriceIs0WithNoErrors()
		{
			PointOfSaleTerminal terminal = new PointOfSaleTerminal();
			terminal.SetPricing();

			decimal result = terminal.GetSaleTotal();

			Assert.Equal(0, result);
		}
	}
}
