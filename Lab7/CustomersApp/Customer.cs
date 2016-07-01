using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp 
{
    public class Customer : IComparable<Customer> , IEquatable<Customer>
    {
        private string _name, _address;
        private int _id;

        public Customer(string name, int id, string address)
        {
            _name = name;
            _id = id;
            _address = address;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public bool Equals(Customer other)
        {
            if (this.ID == other.ID && this.Name.CompareTo(other.Name)==0 )
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Customer other)
        {
            return String.Compare(  this.Name,  other.Name,  true);
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Name: ");
            sb.Append(_name.ToString());
            sb.Append(" ID: ");
            sb.Append(_id.ToString());
            sb.Append(" Address: ");
            sb.Append(_address.ToString());

            return sb.ToString();
        }
    }
}
