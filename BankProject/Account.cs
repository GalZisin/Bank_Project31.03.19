using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Account
    {
        private static int numberOfAcc = 0;
        private readonly int accountNumber; 
        private readonly Customer accountOwer;

        public int MonthlyIncome { get; }

        private int maxMinusAllowed;
        public int AccountNumber
        { get { return accountNumber; } }

        public int Balance { get; set; }
      
        public Customer AccountOwner { get { return accountOwer; } }
        
        public int MaxMinusAllowed
        {
            get
            {
                return this.maxMinusAllowed;
            }
        }
        public Account(Customer customer, int monthlyIncome)
        {
            accountOwer =  customer;
            MonthlyIncome = monthlyIncome;
            maxMinusAllowed = 3 * monthlyIncome;
            numberOfAcc++;
            this.accountNumber = numberOfAcc;
        }
        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Subtrac(int amount)
        {
            Balance -= amount;
        }
        public static bool operator ==(Account account1, Account account2)
        {
            if (ReferenceEquals(account1, null) && ReferenceEquals(account2, null))
            {
                return true;
            }

            if (ReferenceEquals(account1, null) || ReferenceEquals(account2, null))
            {
                return false;
            }

            if (account1.AccountNumber == account2.AccountNumber)
                return true;

            return false;
        }
        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Account otherAcc = obj as Account;

            return this.AccountNumber == otherAcc.AccountNumber;
        }
        public override int GetHashCode()
        {
            return this.AccountNumber;
        }
        public static Account operator +(Account account1, Account account2)
        {
            Account newAccount = new Account(account1.AccountOwner, account1.MonthlyIncome + account2.MonthlyIncome);
            newAccount.Add(account1.Balance + account2.Balance);
            return newAccount;
        }
        public static Account operator +(Account account, int amount)
        {
            account.Balance = account.Balance + amount;
            return account;
        }
        public static Account operator -(Account account, int amount)
        {
            account.Balance = account.Balance - amount;
            return account;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber} Balance: {Balance} Account Owner: {AccountOwner} Max Minus Allowed:{MaxMinusAllowed}";
        }
    }
}
