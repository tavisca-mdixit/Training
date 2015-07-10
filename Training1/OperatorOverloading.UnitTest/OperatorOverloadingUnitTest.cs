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
            var money = new Money(100,"USD");
            var amount = money.CurrencyConverter("INR");

            Assert.IsTrue(amount==6347.345);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestMethod2()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("YEN");    
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod3()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("IN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod4()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("");

        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod5()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("\0");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod6()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("   ");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod7()
        {
            var money = new Money(100, "INR");
            var amount = money.CurrencyConverter("AFN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod8()
        {
            var money = new Money(100, "INR");
            var amount = money.CurrencyConverter("AFN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod9()
        {
            var money = new Money(100, "INR");
            var amount = money.CurrencyConverter("YEN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod10()
        {
            var money = new Money(100, "YEN");
            var amount = money.CurrencyConverter("INR");

        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestMethod11()
        {
            var money = new Money(100, "USD");
            var amount = money.CurrencyConverter("YEN");

        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod12()
        {
            Money money = null;
            var amount = money.CurrencyConverter("YEN");
        }
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void TestMethod13()
        {
            Converter convert = new Converter("  ");
            convert.GetConversionRate("INR", "USD");        
        }
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void TestMethod14()
        {
            Converter convert = new Converter("");
            convert.GetConversionRate("INR", "USD");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod15()
        {
            Converter convert = new Converter("ABCD");
            convert.GetConversionRate("  ", "   ");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod16()
        {
            Converter convert = new Converter("ABCD");
            convert.GetConversionRate("","");
        }


    }
}
