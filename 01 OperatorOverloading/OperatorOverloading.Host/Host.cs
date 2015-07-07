using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloadingMoney;

namespace OperatorOverloading.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            Money Money1 = new Money();
            Money Money2 = new Money();
            Money Money3 = new Money();

     

            try
            {
                Console.WriteLine("Enter the Curreny type  USD/INR and the amount ");
                Money1.Currency = Console.ReadLine();
                Money1.Amount = Convert.ToDouble(Console.ReadLine());
    

                Console.WriteLine("Enter the Curreny type  USD/INR/YEN and the amount ");
                Money2.Currency = Console.ReadLine();
                Money2.Amount = Convert.ToDouble(Console.ReadLine());
                if (Money1.Amount < 0 || Money2.Amount < 0)
                { throw new System.Exception();}
                Money3 = Money2 + Money1;
            }
            catch(Exception E){
                Console.WriteLine("Exception Caught");
                Console.WriteLine("Cuurent /Amount Invalid");
                   Console.WriteLine(E.StackTrace);

            }

            Console.WriteLine("The Currency and Amount is : {0}  {1}", Money3.Currency, Money3.Amount);
 
          
            Console.ReadKey();
        }
    }
}
