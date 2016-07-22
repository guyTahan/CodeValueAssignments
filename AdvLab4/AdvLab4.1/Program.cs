using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvLab4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------- lab 4.1 a------------------------------------


            Assembly assembly = typeof(string).Assembly;
            List<Type> list = new List<Type>();

            var query1 = from type in assembly.GetTypes()
                         where type.IsInterface && type.IsPublic
                         orderby type.Name
                         select new
                         {
                             Name = type.Name,
                             NumberOfMethods = type.GetMethods().Length
                         };

            foreach(var q in query1)
            {
                Console.WriteLine($"Name: {q.Name}  Methods: {q.NumberOfMethods}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //--------------- lab 4.1 b + c-----------------------------------


            processStartTimeChecker checker = new processStartTimeChecker();

            var query2 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5 
                         group p by p.BasePriority into priorityGroup
                         select priorityGroup;

            foreach (var group in query2)
            {
                Console.WriteLine($"Priority:  {group.Key}");
                foreach (var process in group )
                {
                    if (checker.CheckIfYouCanAccessRunTime(process) == true)
                    {
                        Console.WriteLine($"Name: {process.ProcessName} ID: {process.Id}  StartTime: {process.StartTime}");
                    }
                    else
                    {
                        Console.WriteLine($"Name: {process.ProcessName} ID: {process.Id}  StartTime: Access Denied");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }




            //--------------- lab 4.1 d-----------------------------------

            var query3 = from p in Process.GetProcesses()
                         select p.Threads.Count;

            long sum = 0;
            foreach (int threads in query3)
            {
                sum += threads;
            }

            Console.WriteLine($"Total number of threads in this system: {sum}");
        }

    }
}
