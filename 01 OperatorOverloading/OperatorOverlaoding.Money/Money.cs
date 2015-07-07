using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Money
    {

        public double amount { get; set; }
         
        public string currency { get; set; }

        public static Money operator +(Money moneyOne, Money moneyTwo)
        {
            /*Comparing String Ignoring their cases and checking for Null values*/

            if (!string.IsNullOrEmpty(moneyOne.currency) && !string.IsNullOrEmpty(moneyTwo.currency) && string.Equals(moneyOne.currency, moneyTwo.currency, StringComparison.OrdinalIgnoreCase))
            {

                /*checked does not work for double and I was not able to find any other other method for double so i m using this logic 
                  its similar to a=100-b ,,if a is first amount and b the is second amount with 100 being the max value
                  a=100-b will throw me an exception if a+b>100*/

                if(moneyOne.amount>double.MaxValue-moneyTwo.amount || moneyOne.amount<0 ||moneyTwo.amount<0)
                {
                    throw new ArgumentException("Arguements Entered are Wrong");
                }
                Money moneyThree = new Money();
                moneyThree.amount= moneyOne.amount + moneyTwo.amount;
                moneyThree.currency = moneyOne.currency;
                return moneyThree;
            }
            else
            {
                throw new Exception("Different  Currencies Entered/String Entered is Incorrect ");
            }


        }

    }
}
