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
            /*

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

            */

            //--------------- lab 4.1 b-----------------------------------


            processStartTimeChecker checker = new processStartTimeChecker();

            var query2 = from p in Process.GetProcesses()
                where p.Threads.Count < 5 && checker.CheckIfYouCanAccessRunTime(p)==true
                orderby  p.Id
                select new{
                    Name = p.ProcessName
                    ,ID = p.Id
                    ,p.StartTime
                };

            foreach (var q in query2)
            {
                Console.WriteLine($"Name: {q.Name} ID: {q.ID}  StartTime: {q.StartTime}");
            }
            //--------------- lab 4.1 c-----------------------------------
        }

    }
}
