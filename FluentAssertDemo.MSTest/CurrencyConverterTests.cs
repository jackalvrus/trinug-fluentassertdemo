using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertDemo.MSTest
{
    [TestClass]
    public class CurrencyConverterTests
    {
        [TestMethod]
        public void DollarsToCents_Succeeds1()
        {
            string dollars = "$0.27";

            string cents = CurrencyConverter.DollarsToCents(dollars);

            Assert.AreEqual("27¢", cents);
        }

        [TestMethod]
        public void DollarsToCents_Succeeds2()
        {
            string dollars = "$0.27";

            string cents = CurrencyConverter.DollarsToCents(dollars);

            Assert.IsFalse(cents.StartsWith("$"), "the dollar sign should be removed");
            Assert.IsFalse(cents.StartsWith("0"), "any leading zeros should be removed");
            Assert.IsFalse(cents.Contains("."), "the decimal should be removed");
            Assert.IsTrue(cents.EndsWith("¢"), "the cent sign should be added");
            Assert.IsTrue(cents.Contains("27"), "the amount should be included");
        }

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DollarsToCents_UnknownCurrency1()
        {
            string dollars = "3";

            CurrencyConverter.DollarsToCents(dollars);
        }

        [TestMethod]
        public void DollarsToCents_UnknownCurrency2()
        {
            string dollars = "3";

            Assert.ThrowsException<InvalidOperationException>(
                () => CurrencyConverter.DollarsToCents(dollars));
        }

        [TestMethod]
        public void DollarsToCents_UnknownCurrency3()
        {
            string dollars = "3";
            Exception actualException = null;

            try
            {
                CurrencyConverter.DollarsToCents(dollars);
            }
            catch (Exception ex)
            {
                actualException = ex;
            }

            Assert.IsNotNull(actualException);
            Assert.IsInstanceOfType(actualException, typeof(InvalidOperationException));
            Assert.AreEqual("Unable to determine currency", actualException.Message);
        }

        #region Fluent Exceptions


        //[TestMethod]
        //public void DollarsToCents_UnknownCurrencyFluent()
        //{
        //    string dollars = "3";

        //    Action act = () => CurrencyConverter.DollarsToCents(dollars);

        //    act.Should()
        //        .Throw<InvalidOperationException>()
        //        .WithMessage("Unable to determine currency");
        //}

        #endregion

        #endregion
    }
}
