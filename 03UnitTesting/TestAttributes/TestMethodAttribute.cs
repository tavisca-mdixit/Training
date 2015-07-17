using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestAttribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {
        public TestMethodAttribute()
        {
        }
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestMethodAttribute)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
