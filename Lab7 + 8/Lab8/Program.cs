using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {

        public delegate bool CustomerFilter(CustomersApp.Customer person);

        public static ICollection<CustomersApp.Customer> GetCustomers(ICollection<CustomersApp.Customer> collection, CustomerFilter filter)
        {
            LinkedList<CustomersApp.Customer> list = new LinkedList<CustomersApp.Customer>();

            foreach (CustomersApp.Customer person in collection)
            {
                if (filter(person))
                {
                    list.AddLast(person);
                }
            }

            return list;
        }

        public static bool FilterAK(CustomersApp.Customer person)
        {
                string name = person.Name;

                if (name[0] >= 'A' && name[0] <= 'K')
                {
                    return true;
                }
                return false;
        }

        public static bool FilterLZ(CustomersApp.Customer person)
        {
            string name = person.Name;

            if (name[0] >= 'L' && name[0] <= 'Z')
            {
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
           
            LinkedList<CustomersApp.Customer> customers = new LinkedList<CustomersApp.Customer>();
            customers.AddLast(new CustomersApp.Customer("Guy",86,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Dana",134,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Aviko",93,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Meshi",154,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Or",54,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Idan",171,"Givat Shmuel"));

            Console.WriteLine("Before the filter:");
            foreach (CustomersApp.Customer person in customers)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("using the A-K filter:");
            Console.WriteLine();

            ICollection<CustomersApp.Customer> customers2;
            CustomerFilter filter = Program.FilterAK;
            customers2 = GetCustomers(customers, filter);
        

            foreach (CustomersApp.Customer person in customers2)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("using the L-Z filter:");
            Console.WriteLine();

            ICollection<CustomersApp.Customer> customers3;
            CustomerFilter filter2 = Program.FilterLZ;
            customers3 = GetCustomers(customers, filter2);

            foreach (CustomersApp.Customer person in customers3)
            {
                Console.WriteLine(person.ToString());
            }


            CustomerFilter filter3 = (CustomersApp.Customer person) => person.ID < 100;

            Console.WriteLine();
            Console.WriteLine("using the ID < 100 filter:");
            Console.WriteLine();

            ICollection<CustomersApp.Customer> customers4;
            customers4 = GetCustomers(customers, filter3);

            foreach (CustomersApp.Customer person in customers4)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
