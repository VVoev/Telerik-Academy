namespace _02.BankAccounts.BankCustomers
{
    using BankInterfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Customer
    {
        // Field
        private string customerName;

        // Property.
        public string CustomerName
        {
            get { return this.customerName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("You must enter a name.");
                }
                this.customerName = value;
            }
        }

        // Constructor.
        public Customer(string customerName)
        {
            this.CustomerName = customerName;
        }
    }
}
