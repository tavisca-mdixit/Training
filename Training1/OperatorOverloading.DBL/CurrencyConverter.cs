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
        private string _jsonFile;
        public string JsonFile
        {
            get
            {
                return _jsonFile;
            }
            set
            {
                _jsonFile = value;
            }
        }

        public CurrencyConverter(string jsonFile)
        {
            //Checking for null arguement 
            if (string.IsNullOrEmpty(jsonFile) || string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new FileLoadException(Messages.LoadUnsuccessful);
            }
            JsonFile = jsonFile;
        }

        //Method to get the conversion rate 
        public double GetConversionRate(string from, string to)
        {
            //Checking for valid arguements
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || from.Length != 3 && to.Length != 3)
            {
                throw new System.ArgumentException(Messages.InvalidInput);
            }

            //Splitting the jsonFile           
            string[] jsonFileArray = _jsonFile.Split('{', ',', '}');

            //If to and from currency are same
            if (string.Equals(to, from, StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }

            //Calling the convert function to convert from USD 
            if (string.Equals(from, "USD", StringComparison.OrdinalIgnoreCase))
            {
                return CurrencyParser.ConversionRate(jsonFileArray, to.ToUpper());
            }

            //Calling the convert function to conver to USD
            else if (string.Equals(to, "USD", StringComparison.OrdinalIgnoreCase))
            {
                return 1 / CurrencyParser.ConversionRate(jsonFileArray, from.ToUpper());
            }

            //Throwing Exception if none of the currency is USD
            else
            {
                throw new System.ArgumentException(Messages.InvalidCurrency);
            }

        }

    }
}
