using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Facade
{
    class StartUp
    {
        static void Main()
        {
            //Facade
            Mortage mortage = new Mortage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Vladimir Voev");
            bool eligible = mortage.isEligible(customer, 5000000);
            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }
}
