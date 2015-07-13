using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorOverloading.Model;
using OperatorOverloading.DBL;
using System.IO;
namespace OperatorOverloading.UnitTest
{
    [TestClass]
    public class OperatorOverloadingUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("INR");

            Assert.IsTrue(amount == 6347.345);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestMethod2()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("YEN");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod3()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("IN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod4()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("");

        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod5()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("\0");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod6()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("   ");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod7()
        {
            var money = new Money(100, "INR");
            var amount = money.Convert("AFN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod8()
        {
            var money = new Money(100, "INR");
            var amount = money.Convert("AFN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod9()
        {
            var money = new Money(100, "INR");
            var amount = money.Convert("YEN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod10()
        {
            var money = new Money(100, "YEN");
            var amount = money.Convert("INR");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestMethod11()
        {
            var money = new Money(100, "USD");
            var amount = money.Convert("YEN");

        }
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void TestMethod13()
        {
            CurrencyConverter convert = new CurrencyConverter("  ");
            convert.GetConversionRate("INR", "USD");
        }
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void TestMethod14()
        {
            CurrencyConverter convert = new CurrencyConverter("");
            convert.GetConversionRate("INR", "USD");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod15()
        {
            CurrencyConverter convert = new CurrencyConverter("ABCD");
            convert.GetConversionRate("  ", "   ");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod16()
        {
            CurrencyConverter convert = new CurrencyConverter("ABCD");
            convert.GetConversionRate("", "");
        }


    }
}
