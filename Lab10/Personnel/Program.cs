using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            NameReader reader = new NameReader();
            string lab10DirectoryPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            LinkedList<string> names = reader.ReadNamesFrom(lab10DirectoryPath + "\\nameList.txt");

            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            }

        }
    }
}
