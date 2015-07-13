using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Interface
{
    public interface ICurencyConverter
    {   //Interface for the conversion function;
        /// <summary>
        /// GetConversionRate Function which takes 2 strings as input and returns 
        /// double as output
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        double GetConversionRate(string from, string to);
    }
}
