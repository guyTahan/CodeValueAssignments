using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class NameReader
    {

        public LinkedList<string> ReadNamesFrom(string path)
        {
            LinkedList<string> result = new LinkedList<string>();
            FileStream stm = new FileStream(path, FileMode.Open,
            FileAccess.Read, FileShare.Read);

            StreamReader reader = new StreamReader(stm);
            string temp = reader.ReadLine();
            while (temp != null)
            {
                result.AddLast(temp);
                temp = reader.ReadLine();
            }
            reader.Close();

            return result;
        }
    }
}
