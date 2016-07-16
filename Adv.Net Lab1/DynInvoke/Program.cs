using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {

        static string InvokeHello(Object o, String str)
        {
            object[] args = { str };
            bool exceptionThrown = false;
            string output = "";
            Type type = o.GetType();
            try
            {
                output = o.GetType().InvokeMember("Hello", BindingFlags.InvokeMethod, null, o, args) as string;
            }
            catch(System.Reflection.TargetInvocationException)
            {
                exceptionThrown = true;
                Console.WriteLine("could not invoke method.. TargetInvocationException exception was thrown. ");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("are you serious? really? a null argument?!  ArgumentNullException? exception was thrown.....");
            }
            finally
            {
                
            }
            if (exceptionThrown == true)
            {
                Console.WriteLine("Attempt to invoke hello has failed . . . ");
                output = "";
            }

            return output;

        }

        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(InvokeHello(a, "A "));
            sb.AppendLine(InvokeHello(b, "B "));
            sb.AppendLine(InvokeHello(c, "C "));
            Console.WriteLine(sb.ToString());
        }
    }
}
