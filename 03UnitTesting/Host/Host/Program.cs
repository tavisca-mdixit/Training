using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestCLass;
using TestAttribute;
namespace Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Category type:");

            if (string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]))
            {
                Console.WriteLine("Invalid Arguments entered");
                Console.ReadKey();
                return;

            }
            var category = args[1];


            try
            {
                Assembly assembly = Assembly.LoadFrom(args[0]);


                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && TestClassAttribute.Exists(type))
                    {
                        Console.WriteLine("The name of class is :{0}\n", type.FullName);
                        foreach (MethodInfo method in (type.GetMethods()))
                        {

                            if (TestMethodAttribute.Exists(method))
                            {
                                if (string.IsNullOrWhiteSpace(category) || TestCategoryAttribute.Exists(method, category))
                                    Console.WriteLine("The name of executable  method is :{0}\n", method.Name);
                                else if (IgnoreAttribute.Exists(method))
                                    Console.WriteLine("The name of ignored  method is :{0}", method.Name);

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
