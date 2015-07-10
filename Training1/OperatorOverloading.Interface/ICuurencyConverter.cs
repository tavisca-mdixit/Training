using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Interface
{
    public interface ICuurencyConverter
    {
        double GetConversionRate(string from, string to);
    }
}
