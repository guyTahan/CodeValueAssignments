using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyAnalayzer analayzer = new AssemblyAnalayzer(); 

            analayzer.AssemblyChecker(Assembly.GetExecutingAssembly());

            analayzer.AssemblyChecker(typeof(string).Assembly);
        }
    }
}
