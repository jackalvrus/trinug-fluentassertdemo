using FluentAssertions;
using Xunit;

namespace FluentAssertDemo.xUnit
{
    public class CurrencyConverterTests
    {
        [Fact]
        public void DollarsToCents_Succeeds()
        {
            string dollars = "$0.27";

            string cents = CurrencyConverter.DollarsToCents(dollars);

            cents.Should()
                .NotStartWith("$", "the dollar sign should be removed")
                .And.NotStartWith("0", "any leading zeros should be removed")
                .And.NotContain(".", "the decimal should be removed")
                .And.EndWith("¢", "the cent sign should be added")
                .And.Contain("27", "the amount should be included");
        }
    }
}
