using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading;
using System.IO;
using operatorOverloading;

namespace OperatorOverloading
{
    class Host
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD ");
                //Calling the Parameterized constructor of Money Class
                var moneyOne = new Money(Console.ReadLine());

                Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD");
                //Calling the Parameterized constructor of Money Class
                var moneyTwo = new Money(Console.ReadLine());

                //Overloading the Plus operator          
                Console.WriteLine(moneyTwo + moneyOne);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

