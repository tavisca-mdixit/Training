using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.GetFile;
using System.IO;
namespace OperatorOverloading.DBL
{
    class CurrencyParser
    {
        private string _jsonFile;
        public string JsonFile
        {
            get
            {
                return _jsonFile;
            }
            private set
            {
                _jsonFile = value;
            }
        }
        /// <summary>
        /// Constructor to fetch the json file as a string
        /// from GetFile class
        /// </summary>
        public CurrencyParser()
        {
            var jsonFile = GetFile.GetF();
            if (string.IsNullOrEmpty(jsonFile) || string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new FileLoadException(Messages.LoadUnsuccessful);
            }
            JsonFile = jsonFile;
        }
        /// <summary>
        /// Method to get the conversion rate betwwen two currencies 
        /// specified as to and from
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public double ConversionRate(string currency)
        {
            string[] jsonFileArray = JsonFile.Split('{', ',', '}');
            if (jsonFileArray == null || jsonFileArray.Length == 0)
                throw new System.ArgumentNullException(Messages.ArguementNull);
            foreach (string currencies in jsonFileArray)
            {
                if (currencies.Contains(currency))
                {
                    string[] convertRate = currencies.Split(':');
                    //checking the length of the array after split
                    if (convertRate.Length != 2)
                        throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);

                    return Convert.ToDouble(convertRate[1]);
                }
            }
            throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
        }
        /// <summary>
        /// Method to get the source of api currency used to convert the currencies
        /// </summary>
        /// <returns></returns>
        public string GetApiSource()
        {
            string[] jsonFileArray = JsonFile.Split('{','}', ',');
            if (jsonFileArray == null || jsonFileArray.Length == 0)
                throw new System.ArgumentNullException(Messages.ArguementNull);
            foreach (string currencies in jsonFileArray)
            {
                if (currencies.Contains("source"))
                {
                    string[] apiSource = currencies.Split(':');
                    //checking the length of the array after split
                    if (apiSource.Length != 2)
                        throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
                    Console.WriteLine(apiSource[1].Trim('"')); 
                    return apiSource[1].Trim('"');
                }
            }
            throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
        }
    }
}
