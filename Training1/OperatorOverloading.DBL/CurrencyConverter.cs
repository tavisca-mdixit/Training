using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Interface;
using System.IO;
namespace OperatorOverloading.DBL
{
    public class CurrencyConverter : ICurencyConverter
    {
        /// <summary>
        ///Taking from and to as source and destination strings 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        //Method to get the conversion rate 
        public double GetConversionRate(string from, string to)
        {
            //Checking for valid arguements
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || from.Length != 3 && to.Length != 3)
            {
                throw new System.ArgumentException(Messages.InvalidInput);
            }

            //Splitting the jsonFile           
            //If to and from currency are same
            if (string.Equals(to, from, StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }
            CurrencyParser currencyParser = new CurrencyParser();
            //Calling the convert function to convert from USD 
            if (string.Equals(from, currencyParser.GetApiSource(), StringComparison.OrdinalIgnoreCase))
            {
                return currencyParser.ConversionRate(to.ToUpper());
            }

            //Calling the convert function to conver to USD
            else if (string.Equals(to, currencyParser.GetApiSource(), StringComparison.OrdinalIgnoreCase))
            {
                return 1 / currencyParser.ConversionRate(from.ToUpper());
            }

            //Throwing Exception if none of the currency is USD
            else
            {
                throw new System.ArgumentException(Messages.InvalidCurrency);
            }

        }

    }
}
