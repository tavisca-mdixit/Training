using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestAttribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCategoryAttribute : Attribute
    {
        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
        }
        public TestCategoryAttribute(string testCategory)
        {
            _category = testCategory;
        }

        public static bool Exists(MethodInfo memberInfo, string category)
        {
            foreach (object attribute in memberInfo.GetCustomAttributes(true))
            {
                if (attribute is TestCategoryAttribute)
                {
                    var attr = attribute as TestCategoryAttribute;
                    if (attr.Category != null)
                        if (attr.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                            return true;
                }
            }
            return false;
        }

    }
}
