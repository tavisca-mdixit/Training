using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
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
                //Calling the Parameterized constructor of Money Class.
                var moneyTwo = new Money(Console.ReadLine());

                //Overloading the Plus operator.          
                Console.WriteLine(moneyTwo + moneyOne);

                Console.WriteLine("Enter the amount and Currency type ex: 100 USD");
                var money = new Money(Console.ReadLine());
                Console.WriteLine("Enter the currency you want to convert into ex :INR ");

                var convertedMoney = money.Convert(Console.ReadLine());
                Console.WriteLine(convertedMoney);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
