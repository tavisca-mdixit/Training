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
            Money moneyOne = new Money();
            Money moneyTwo= new Money();
            Money moneyThree = new Money();
            double amount;
           
     
                Console.WriteLine("Enter the Curreny type  USD/INR and the amount ");
                moneyOne.currency = Console.ReadLine();
                double.TryParse( Console.ReadLine(),out amount);
                moneyOne.amount = amount;
                Console.WriteLine("Enter the Curreny type  USD/INR/YEN and the amount ");
                moneyTwo.currency = Console.ReadLine();
                double.TryParse(Console.ReadLine(), out amount);
                moneyTwo.amount = amount;
                
                try
                {
                    moneyThree = moneyTwo + moneyOne;
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                Console.WriteLine("The Currency and Amount is : {0}  {1}", moneyThree.currency, moneyThree.amount);
 
          
            Console.ReadKey();
        }
    }
}
