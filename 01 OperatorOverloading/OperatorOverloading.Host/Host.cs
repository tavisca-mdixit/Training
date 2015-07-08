using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading;

namespace OperatorOverloading
{
    class Host
    {
        static void Main(string[] args)
        {
            bool tryParse;
            double amount;
            string currency;
            Money moneyOne;
            Money moneyTwo;
            Money moneyThree;

            try
            {


                Console.WriteLine("Enter the Curreny type  USD/INR and the amount ");
                currency = Console.ReadLine();
                tryParse=double.TryParse(Console.ReadLine(), out amount);

                //Calling the Parameterized constructor of Money Class
                moneyOne = new Money(currency, amount);
                moneyOne.TryParse=tryParse;
                
                
                Console.WriteLine("Enter the Curreny type  USD/INR/YEN and the amount ");
                currency = Console.ReadLine();
                tryParse=double.TryParse(Console.ReadLine(), out amount);


                //Calling the Parameterized constructor of Money Class
                moneyTwo = new Money(currency, amount);
                moneyTwo.TryParse = tryParse;
                
                //Overloading the Plus operator           
                moneyThree = moneyTwo + moneyOne;

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

