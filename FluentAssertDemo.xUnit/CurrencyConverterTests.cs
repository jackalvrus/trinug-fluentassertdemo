using System;
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

            Assert.Equal("27¢", cents);
        }
    }
}
