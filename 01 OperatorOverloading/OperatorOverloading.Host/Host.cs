using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading;
using System.IO;
using OperatorOverloading.Host;

namespace OperatorOverloading
{
    class Host
    {
        static void Main(string[] args)
        {
            
            string currencyAndAmount;
            Money moneyOne;
            Money moneyTwo;
            try
            {
                Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD ");
                currencyAndAmount = Console.ReadLine();

                //Calling the Parameterized constructor of Money Class
                moneyOne = new Money(currencyAndAmount);

                Console.WriteLine("Enter the amount and the Curreny type,, ex:  100 USD");
                currencyAndAmount = Console.ReadLine();

                //Calling the Parameterized constructor of Money Class
                moneyTwo = new Money(currencyAndAmount);

                //Overloading the Plus operator           
                var moneyThree = moneyTwo + moneyOne;
                Console.WriteLine("The Currency and Amount is : {0}  {1}", moneyThree.Currency, moneyThree.Amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();                          
        }
    }
}

