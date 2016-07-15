using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class AssemblyAnalayzer
    {
        public bool AssemblyChecker(Assembly assembly)
        {
            StringBuilder sb = new StringBuilder();
            bool allCodeIsGood = true;

            Type[] types = assembly.GetExportedTypes();

            foreach (Type t in types)
            {
                IEnumerable<Attribute> list = t.GetCustomAttributes();

                foreach(Attribute att in list)
                {
                    if (att.GetType() == typeof(CodeReviewAttribute))
                    {
                       if ( (att as CodeReviewAttribute).CodeIsGood == false)
                        {
                            allCodeIsGood = false;
                        }
                        sb.Append("Reviewer: ");
                        sb.Append((att as CodeReviewAttribute).ReviewerName);
                        sb.Append("Date: ");
                        sb.Append((att as CodeReviewAttribute).ReviewDate);
                        if (((att as CodeReviewAttribute).CodeIsGood)==true)
                        {
                            sb.AppendLine(" Quality: good");
                        }
                        else
                        {
                            sb.AppendLine(" Quality: bad");
                        }
                        Console.WriteLine(sb.ToString());
                        sb.Clear();
                    }
                }
            }

            return allCodeIsGood;
        } 
    }
}
