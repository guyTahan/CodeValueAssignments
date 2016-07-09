using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            string fileName = args[1];

            FileSeeker seeker = new FileSeeker();
            StringBuilder sb = seeker.PresentAllRelevantFiles(fileName, path);
            Console.WriteLine(sb.ToString());
        }
    }
}
