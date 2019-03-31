using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Customer
    {
        private static int numberOfCust = 1;
        private readonly int customerID;
        private readonly int customerNumber;
        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
        }

        public int CustomerNumber
        {
            get
            {
                return this.customerNumber;
            }
        }
        
        public Customer(string name, int phone, int id)
        {
            Name = name;
            PhNumber = phone;
            customerID = id;

           this.customerNumber = numberOfCust++;
         
        }
        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (ReferenceEquals(customer1, null) && ReferenceEquals(customer2, null))
            {
                return true;
            }

            if (ReferenceEquals(customer1, null) || ReferenceEquals(customer2, null))
            {
                return false;
            }

            if (customer1.CustomerNumber == customer2.CustomerNumber)
                return true;

            return false;
        }
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Customer otherCust = obj as Customer;

            return this.CustomerNumber == otherCust.CustomerNumber;
        }
        public override int GetHashCode()
        {
            return this.customerNumber;
        }
        public override string ToString()
        {
            return $"Customer Name:{Name} Phone Number: {PhNumber} Customer ID: {CustomerID} Customer Number: {CustomerNumber} ";
        }
    }
}
