using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.DBL
{
    class CurrencyParser
    {
        public static double ConversionRate(string[] jsonFileArray, string currency)
        {
            foreach (string rate in jsonFileArray)
            {
                if (rate.Contains(currency))
                {
                    string[] convertRate = rate.Split(':');
                    //checking the length of the array after split
                    if (convertRate.Length != 2)
                        throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);

                    return Convert.ToDouble(convertRate[1]);
                }
            }
            throw new System.ArgumentOutOfRangeException(Messages.OutOfRange);
        }
    }
}
