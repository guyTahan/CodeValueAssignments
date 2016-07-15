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
            /*
            Type objType = o.GetType();
            Type strType = str.GetType();
            Type[] args = { str.GetType() };
            MethodInfo hello = objType.GetMethod("Hello", args);
            object[] parameters = { str };
            hello.Invoke(o, parameters);
            */
            object[] args = { str };
            Type type = o.GetType();
            try
            {
                return o.GetType().InvokeMember("Hello", BindingFlags.InvokeMethod, null, o, args) as string;
            }
            catch(System.Reflection.TargetInvocationException)
            {
                Console.WriteLine("could not invoke method.. exception was thrown. ");
                return null;
            }
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
