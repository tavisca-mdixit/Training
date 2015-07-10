using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Interface;
using System.IO;
namespace OperatorOverloading.DBL
{
    public class Converter : ICuurencyConverter
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

        public Converter(string jsonFile)
        {
            if (string.IsNullOrEmpty(jsonFile) || string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new FileLoadException(Messages.LoadUnsuccessful);
            }
            JsonFile = jsonFile;
        }

        public double GetConversionRate(string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || from.Length != 3 && to.Length != 3)
            {
                throw new System.ArgumentException(Messages.InvalidInput);
            }
            string[] jsonFileArray = _jsonFile.Split('{', ',', '}');
            if (string.Equals(from, "USD", StringComparison.OrdinalIgnoreCase))
            {
                var rate = FromUSD(jsonFileArray, from, to);
                return rate;
            }
            else if (string.Equals(to, "USD", StringComparison.OrdinalIgnoreCase))
            {
                var rate = ToUSD(jsonFileArray, from, to);
                return rate;
            }
            else
            {
                throw new System.ArgumentException(Messages.InvalidCurrency);
            }

        }

        public double FromUSD(string[] jsonFileArray, string from, string to)
        {
            foreach (string i in jsonFileArray)
            {
                if (i.Contains(to.ToUpper()))
                {
                    if (string.Equals(from, to, StringComparison.OrdinalIgnoreCase))
                    {
                        return 1;
                    }

                    string[] converRate = i.Split(':');
                    return Convert.ToDouble(converRate[1]);
                }
            }
            throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
        }

        public double ToUSD(string[] jsonFileArray, string from, string to)
        {
            foreach (string i in jsonFileArray)
            {
                if (i.Contains(from.ToUpper()))
                {
                    if (string.Equals(from, to, StringComparison.OrdinalIgnoreCase))
                    {
                        return 1;
                    }
                    string[] converRate = i.Split(':');
                    return 1 / Convert.ToDouble(converRate[1]);
                }
            }
            throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
        }
    }
}
