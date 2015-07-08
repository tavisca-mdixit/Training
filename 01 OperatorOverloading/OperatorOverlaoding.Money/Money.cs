using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public Money(string currency, double amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }
        
        public double Amount
        {
            get
            {
                return _amount;
            }
            private set
            {   
                //Checking for Negative and Positive Infinity values
                if (value < 0 || double.IsInfinity(value))
                {
                    throw new ArgumentException(Messages.InvalidInput);
                }
                _amount = value;
            }
        }
        public string Currency
        {
            get
            {
                return _currency;
            }
            private set
            {
                //Checking for Empty/Null Strings
                if (string.IsNullOrEmpty(value) == true)
                {
                    throw new Exception(Messages.NullInput);
                }
                _currency = value;
            }
        }


        public static Money operator +(Money moneyOne, Money moneyTwo)
        {
            //Comparing two String without considering cases.
            if (string.Equals(moneyOne.Currency, moneyTwo.Currency, StringComparison.OrdinalIgnoreCase) == false)
            {
                throw new Exception(Messages.InputNotEqual);
            }
            
            double amount = moneyOne.Amount + moneyTwo.Amount;
            return new Money(moneyOne.Currency, amount);

        }

    }
}

