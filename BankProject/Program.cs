using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bankHapoalim = new Bank("Bankhapoalim", "Or Akiva", 100000);
       
            List<Customer> customers = new List<Customer>();
            Customer a, b, c;
            bankHapoalim.AddNewCustomer(a = new Customer("Gal", 0508138257, 307301564));
            bankHapoalim.AddNewCustomer(b = new Customer("Yosi", 0508373603, 568713584));
            bankHapoalim.AddNewCustomer(c = new Customer("Orly", 0526789355, 887878811));

            //try
            //{
            //    bankHapoalim.AddNewCustomer(c);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.WriteLine(bankHapoalim.GetCustomeByID(887878811));
            Console.WriteLine(bankHapoalim.GetCustomerByNumber(2));

            Console.WriteLine(bankHapoalim);
            bankHapoalim.PrintAllCustomers();

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                bankHapoalim.OpenNewAccount(new Account(customer, 20000), customer);
                bankHapoalim.OpenNewAccount(new Account(customer, 30000), customer);
                bankHapoalim.OpenNewAccount(new Account(customer, 40000), customer);
            }
            bankHapoalim.OpenNewAccount(new Account(c, 40000), c);
            bankHapoalim.OpenNewAccount(new Account(c, 20000), c);

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
               
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    bankHapoalim.Deposit(account, 10000); // add amount of 10000 to all accounts
                }
            }

            bankHapoalim.GetAccountByNumber(2).Add(2000); //add amount of 2000 to account number (2)
            bankHapoalim.GetAccountByNumber(5).Subtrac(3000); //substrac amount of 3000 from account number (5)
            bankHapoalim.Withdraw(bankHapoalim.GetAccountByNumber(6), 5000); //withdraw amount of 5000 from account number (6)


            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    Console.WriteLine(account);
                }
            }

            Console.WriteLine();

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Total balance of customer : {customer.Name}");
                Console.WriteLine(bankHapoalim.GetCustomerTotalBalance(customer)); // Total balance of all customers
            }

            Console.WriteLine();

            bankHapoalim.CloseAccount(bankHapoalim.GetAccountByNumber(3), bankHapoalim.GetCustomerByNumber(1));

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    Console.WriteLine(account);
                }
            }
            Console.WriteLine();

            bankHapoalim.ChargeAnnualCommission(1.5f);

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    Console.WriteLine(account); // print accounts by customer 
                }
            }
            Console.WriteLine();
            bankHapoalim.GetAccountByNumber(5).Subtrac(20000); //substrac amount of 20000 from account number (5)
            bankHapoalim.ChargeAnnualCommission(1.5f);         //Charge Annual Commission from all accounts 
                                                               //account (5) charged by 1.5% x2 ,balance is negative

            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    Console.WriteLine(account); // print accounts by customer 
                }
            }
            Console.WriteLine();

            bankHapoalim.JoinAccount(bankHapoalim.GetAccountByNumber(4), bankHapoalim.GetAccountByNumber(5)); //Join account (4) and account (5)
                                                                                                              //and create new account
                                                                                                              //Delete account (4) and account (5)
            for (int i = 1; i <= bankHapoalim.NumOfCust; i++)
            {
                Customer customer = bankHapoalim.GetCustomerByNumber(i);
                Console.WriteLine($"Account List of customer : {customer.Name}");
                foreach (Account account in bankHapoalim.GetAccountsByCustomer(customer))
                {
                    Console.WriteLine(account); // print accounts by customer 
                }
            }
            Console.ReadLine();
        }
    } 
}
