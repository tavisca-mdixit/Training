using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloadimg.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD ");
            //    //Calling the Parameterized constructor of Money Class
            //    var moneyOne = new Money(Console.ReadLine());

            //    Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD");
            //    //Calling the Parameterized constructor of Money Class
            //    var moneyTwo = new Money(Console.ReadLine());

            //    //Overloading the Plus operator          
            //    Console.WriteLine(moneyTwo + moneyOne);
               
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            var money = new Money(100, "USD");
            //var val = money.CurrencyConverter("INR", "USD");
            var val = money.CurrencyConverter( "INR","CLP");
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
}
