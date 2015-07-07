using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloadingMoney
    {
    public class Money
    {

        public double Amount { get; set; }
        public string Currency { get; set; }

        public static Money operator+(Money moneyOne,Money moneyTwo)  {
            Money moneyThree = new Money();
          
                if (moneyOne.Currency.Equals(moneyTwo.Currency) )
                {
                    
                    moneyThree.Amount= moneyOne.Amount + moneyTwo.Amount;
                    if (moneyOne.Amount>(double.MaxValue-moneyTwo.Amount) || moneyThree.Amount<0)
                    { throw new System.ArgumentException(); }
                    moneyThree.Currency = moneyOne.Currency;
                    return moneyThree;
                }
                else{
                throw new System.Exception();}

        
        }
        
    }
}
