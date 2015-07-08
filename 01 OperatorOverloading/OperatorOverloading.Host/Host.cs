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

            double amount;
            string currency;
            Money moneyOne;
            Money moneyTwo;
            Money moneyThree;

            try
            {
                    
     
               Console.WriteLine("Enter the Curreny type  USD/INR and the amount ");
               currency = Console.ReadLine();
               double.TryParse( Console.ReadLine(),out amount);
               moneyOne = new Money(currency, amount);
               Console.WriteLine("Enter the Curreny type  USD/INR/YEN and the amount ");
                currency = Console.ReadLine();
                moneyTwo = new Money(currency, double.MaxValue);
            
               double.TryParse(Console.ReadLine(), out amount);
            
                
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

