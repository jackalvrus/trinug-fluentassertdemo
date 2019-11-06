using NUnit.Framework;

namespace FluentAssertDemo.NUnit
{
    public class CurrencyConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DollarsToCents_Succeeds()
        {
            string dollars = "$0.27";

            string cents = CurrencyConverter.DollarsToCents(dollars);

            Assert.AreEqual("27¢", cents);
        }
    }
}