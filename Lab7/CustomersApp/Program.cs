using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] costumers = new Customer[5];
            costumers[0] = new Customer("Moran", 4652, "Ramat Effal");
            costumers[1] = new Customer("Guy", 4662, "Ramat Ilan");
            costumers[2] = new Customer("Efrat", 4672, "Ramat Hasharon");
            costumers[3] = new Customer("Stas", 4621, "Ramat Amidar");
            costumers[4] = new Customer("Yarin", 4610, "Ramat Gan");

            Array.Sort<Customer>(costumers);

            Console.WriteLine("Customers sorted with the original Customer compare method:");
            Console.WriteLine();
            foreach (Customer c in costumers)
            {
                Console.WriteLine(c.ToString());
            }



            Console.WriteLine("Customers sorted with AnotherCustomerComparer compare method:");
            Console.WriteLine();
            AnotherCustomerComparer comparer = new AnotherCustomerComparer();
            Array.Sort<Customer>(costumers, comparer);

            foreach (Customer c in costumers)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
