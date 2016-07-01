using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        private static IEnumerator<KeyValuePair<int, string>> iter;
        


        static void Main(string[] args)
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();
            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");
            dictionary.Add(1, "ich");
            dictionary.Add(2, "nee");
            dictionary.Add(3, "sun");

            ICollection<string> values1 = dictionary.Values;
            StringBuilder sb = new StringBuilder();

            if (dictionary.Count > 0)
            {
                Console.WriteLine("complete list:");
                Console.WriteLine();
                int i = 1;
                iter = dictionary.GetEnumerator();
                while (iter.MoveNext())
                {
                    sb.Append("Key: ");
                    sb.Append(iter.Current.Key.ToString());
                    sb.Append(" Value: ");
                    sb.Append(iter.Current.Value.ToString());
                    Console.WriteLine(sb.ToString());
                    i++;
                    sb.Clear();
                }
                Console.WriteLine();
            }

             
            System.Collections.Generic.ICollection<int> keys =  dictionary.Keys;
            ICollection<string> values2 = dictionary.Values;
            bool test = dictionary.Contains(3, "three");
            bool test2 = dictionary.Remove(3, "three");
            bool test3 = dictionary.Contains(3, "three");

            Console.WriteLine();

            Console.WriteLine("list after removing {3,three}");

            iter = dictionary.GetEnumerator();
            if (dictionary.Count > 0)
            {
                int i = 1;
                while (iter.MoveNext())
                {
                    sb.Append("Key: ");
                    sb.Append(iter.Current.Key.ToString());
                    sb.Append(" Value: ");
                    sb.Append(iter.Current.Value.ToString());
                    Console.WriteLine(sb.ToString());
                    i++;
                    sb.Clear();
                }
            }

            Console.WriteLine();
            bool test4 = dictionary.Remove(3);
            bool test5 = dictionary.Contains(3,"sun");

            Console.WriteLine("list after removing key number 3:");
            Console.WriteLine();
            iter = dictionary.GetEnumerator();
            if (dictionary.Count > 0)
            {
                int i = 1;
                while (iter.MoveNext())
                {
                    sb.Append("Key: ");
                    sb.Append(iter.Current.Key.ToString());
                    sb.Append(" Value: ");
                    sb.Append(iter.Current.Value.ToString());
                    Console.WriteLine(sb.ToString());
                    i++;
                    sb.Clear();
                }
            }
        }
    }
}
