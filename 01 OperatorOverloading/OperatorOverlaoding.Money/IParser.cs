using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverLoading.Model
{
    public interface IParser
    {
        double GetConversionRate(string from, string to);
    }

}
