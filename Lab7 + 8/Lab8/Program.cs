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

        public ICollection<CustomersApp.Customer> GetCustomers(ICollection<CustomersApp.Customer> collection, CustomerFilter filter)
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

        public bool FilterMethod(CustomersApp.Customer person)
        {
                string name = person.Name;

                if (name[0] >= 'A' && name[0] <= 'K')
                {
                    return true;
                }
                return false;
        }

        static void Main(string[] args)
        {
           
            LinkedList<CustomersApp.Customer> customers = new LinkedList<CustomersApp.Customer>();
            customers.AddLast(new CustomersApp.Customer("Guy",125,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Dana",134,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Aviko",132,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Meshi",154,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Or",162,"Givat Shmuel"));
            customers.AddLast(new CustomersApp.Customer("Idan",171,"Givat Shmuel"));

            //CustomerFilter filter = /* Create a class instead of program for this filter method */ Program.FilterMethod;
            
            /*
            ICollection<CustomersApp.Customer> customers2 = new LinkedList<CustomersApp.Customer>();
            customers2 = GetCustomers(customers, filter);

            foreach (CustomersApp.Customer person in customers2)
            {
                Console.WriteLine(person.ToString());
            }
             * */
        }
    }
}
