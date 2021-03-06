﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.DBL;
using System.Text.RegularExpressions;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public Money(string currencyAndAmount)
        {
            if (string.IsNullOrWhiteSpace(currencyAndAmount))
            {
                throw new ArgumentException(Messages.InvalidInput);
            }

            var args = currencyAndAmount.Split(' ');
            if (args.Length != 2)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }

            double amount;
            while ((double.TryParse(args[0], out amount)) == false)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }
            this.Amount = amount;
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
                if (value < 0 || double.IsInfinity(value) || value > double.MaxValue)
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
                if (string.IsNullOrEmpty(value) || (value.Length != 3))
                {
                    throw new ArgumentException(Messages.InvalidInput);
                }
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
        /// <summary>
        /// Taking to as destionation currency
        ///And calling GetConversionRate on currenct object and destination currency
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public Money Convert(string to)
        {
            //Checking for null arguements and white spaces and the length of arguement. 
            if (string.IsNullOrWhiteSpace(to) || string.IsNullOrEmpty(to) || to.Length != 3 || Regex.IsMatch(to, @"^[a-zA-Z]+$") == false)
            {
                throw new ArgumentException(Messages.InvalidInput);
            }
            CurrencyConverter currencyConverter = new CurrencyConverter();
            return new Money(Amount * currencyConverter.GetConversionRate(Currency, to), to);
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}
