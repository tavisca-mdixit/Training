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
        public Money(string currencyAndAmount)
        {
            var args = currencyAndAmount.Split(' ');
            if (double.TryParse(args[0], out _amount))
            {
                this.Amount = _amount;
            }
            else
            {
                Console.WriteLine("The Value Entered is Incorrect");
            }
            //Checking for Empty/Null Strings                
            if (string.IsNullOrWhiteSpace(args[1]) == true)
            {
                throw new Exception(Messages.NullInput);
            }
            this.Currency = args[1];
        }
        public Money(double amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }        
        public double Amount
        {
            get
            {
                return _amount;
            }
            private set
            {  //Checking for Negative and Positive Infinity values
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
                _currency = value;
            }
        }
        public static Money operator +(Money moneyOne, Money moneyTwo)
        {
            if (moneyOne == null || moneyTwo == null)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }
            //Comparing two String without considering cases.
            if (string.Equals(moneyOne.Currency, moneyTwo.Currency, StringComparison.OrdinalIgnoreCase) == false)
            {
                throw new Exception(Messages.InputNotEqual);
            }
            double amount = moneyOne.Amount + moneyTwo.Amount;
            return new Money(amount, moneyOne.Currency);
         }
    }
}
