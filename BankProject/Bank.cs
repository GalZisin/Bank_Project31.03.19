using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank: IBank, IEnumerable<Customer>
    {
        public string Name { get; }
        public string Address { get; }
        public int CustomerCount { get; }
        private List<Account> accounts;
        private List<Customer> customers;
        private Dictionary<int, Customer> customerByID; // int = customerID
        private Dictionary<int, Customer> customerByCustomerNumber;//int =customerNumber
        private Dictionary<int, Account> accountByAccountNumber; //int =accountNumber
        private Dictionary<Customer, List<Account>> accountsByCustomer;
        private int totalMoneyInBank;
        private int profits;

        public int NumOfCust
        {
            get
            {
                return customers.Count;
            }
        }

        public Bank(string name, string address, int customerCount)
        {
            Name = name;
            Address = address;
            CustomerCount = customerCount;
            customerByID = new Dictionary<int, Customer>();
            customerByCustomerNumber = new Dictionary<int, Customer>();
            accountByAccountNumber = new Dictionary<int, Account>();
            accountsByCustomer = new Dictionary<Customer, List<Account>>();
            customers = new List<Customer>();
            accounts = new List<Account>();
        }

        internal Customer GetCustomeByID(int customerId)
        {
            if (!customerByID.ContainsKey(customerId))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
                
            return customerByID[customerId];
        }
        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (!customerByCustomerNumber.ContainsKey(customerNumber))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            return customerByCustomerNumber[customerNumber];
        }
        internal Account GetAccountByNumber(int accountNumber)
        {
            if (!accountByAccountNumber.ContainsKey(accountNumber))
            {
                throw new AccountNotFoundException("Account not found");
            }
            return accountByAccountNumber[accountNumber];
        
        }
        internal List<Account> GetAccountsByCustomer(Customer customer)
        {
            if (!accountsByCustomer.ContainsKey(customer))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            return accountsByCustomer[customer];
        }
        internal void AddNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new NullException("customer is Null");
            }
            if (customers.Contains(customer))
            {
                throw new CustomerAlreadyExistException($"Customer: {customer} already exist");
            }
            customers.Add(customer);
            customerByID.Add(customer.CustomerID, customer);
            customerByCustomerNumber.Add(customer.CustomerNumber, customer);
            accountsByCustomer.Add(customer, new List<Account>());
        }
        internal void OpenNewAccount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistException($"Account: {account} already exist");
            }
            accounts.Add(account);
            accountByAccountNumber.Add(account.AccountNumber, account);
            accountsByCustomer[customer].Add(account);
        }
        internal int Deposit(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException("Account not found");
            }
            account.Add(amount);
            totalMoneyInBank += amount;
            return totalMoneyInBank;
        }
        internal int Withdraw(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException("Account not found");
            }
            if (account.MaxMinusAllowed < amount)
                throw new BalanceException("amount deviation");
            account.Subtrac(amount);
            totalMoneyInBank -= amount;
            return totalMoneyInBank;
        }
        internal int GetCustomerTotalBalance(Customer customer)
        {
            int sum = 0;
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            
            foreach (Account account in accountsByCustomer[customer])
            {
                sum += account.Balance;
                
            }

            return sum;
        }
        internal void CloseAccount(Account account, Customer customer)
        {
            if (!customers.Contains(customer))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException("Account not found");
            }
            if (!accountsByCustomer[customer].Contains(account))
            {
                throw new AccountNotFoundException("Account not found");
            }
            if (!accountByAccountNumber.ContainsKey(account.AccountNumber))
            {
                throw new AccountNotFoundException("Account not found");
            }
            accountsByCustomer[customer].Remove(account);
            accounts.Remove(account);
            accountByAccountNumber.Remove(account.AccountNumber);
        }
        
        internal void ChargeAnnualCommission(float percentage)
        {
            foreach (Account account in accounts)
            {
                float commission = 0;
           
                if (account.Balance > 0)
                {
                    commission = (account.Balance * percentage) / 100;
                }
                else
                {
                    commission = (2 * account.Balance * percentage) / 100;
                }
                int intCommission = Convert.ToInt32(commission);
                profits = profits + intCommission;
                account.Balance = account.Balance - intCommission;
            }
        }
        internal void JoinAccount(Account account1, Account account2)
        {
            if(!(account1.AccountOwner == account2.AccountOwner))
            {
                throw new NotSameCustomerException("Not same customer");
            }
            Account newAccount = account1 + account2;
            OpenNewAccount(newAccount, newAccount.AccountOwner);
            CloseAccount(account1, account1.AccountOwner);
            CloseAccount(account2, account2.AccountOwner);
        }
        internal void PrintAllCustomers()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return customers.GetEnumerator();
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return customers.GetEnumerator();
        }
        public override string ToString()
        {
            return $"Bank name: {Name} Address: {Address} Customer Count: {CustomerCount}";
        }
    }
}
