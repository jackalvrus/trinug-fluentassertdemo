using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertDemo.MSTest
{
    [TestClass]
    public class CurrencyConverterTests
    {
        [TestMethod]
        public void DollarsToCents_Succeeds()
        {
            string dollars = "$0.27";

            string cents = CurrencyConverter.DollarsToCents(dollars);

            Assert.AreEqual("27¢", cents);
        }
    }
}
