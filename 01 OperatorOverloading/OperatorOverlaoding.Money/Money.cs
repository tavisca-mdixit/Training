using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverLoading.Model;

namespace OperatorOverloading
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public Money(string currencyAndAmount)
        {
            if (string.IsNullOrWhiteSpace(currencyAndAmount) == true)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }

            var args = currencyAndAmount.Split(' ');
            if ((args.Length == 2) == false)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }

            double temporaryAmount;
            while ((double.TryParse(args[0], out temporaryAmount)) == false)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }
            this.Amount = temporaryAmount;
            //Checking for Empty/Null Strings                
            if (string.IsNullOrEmpty(args[1]) == true)
            {
                throw new ArgumentException(Messages.EmptyInput);
            }
            if ((args[1].Length == 3) == false)
            {
                throw new ArgumentException(Messages.InvalidInput);
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
        {   //Checking for null objects 

            if (moneyOne == null || moneyTwo == null)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }
            //Comparing two String without considering cases.
            if (string.Equals(moneyOne.Currency, moneyTwo.Currency, StringComparison.OrdinalIgnoreCase) == false)
            {
                throw new ArgumentException(Messages.InputNotEqual);
            }
            double amount = moneyOne.Amount + moneyTwo.Amount;
            return new Money(amount, moneyOne.Currency);
        }
        override public string ToString()
        {
            return Amount + "  " + Currency;
        }
    }
}
