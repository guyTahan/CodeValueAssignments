using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {

         //---------------------- part 2 ------------------------------------------------------------------------
            var allPublicTypes = from type in typeof(string).Assembly.GetTypes()
                                 where type.IsClass && type.IsPublic
                                 let properties = type.GetProperties()
                                 select new XElement("Type",
                                    new XAttribute("Name", type.FullName),
                                    new XElement("Properties",
                                        from p in properties
                                        select new XElement("Property",
                                            new XAttribute("Name", p.Name),
                                            new XAttribute("Type", p.PropertyType.FullName ?? "Generic"))),
                                    new XElement("Methods", from method in type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly)
                                                            where !method.IsSpecialName  // to prevent methods that cannot be called by the User
                                                            select new XElement("Method",
                                                            new XAttribute("Name", method.Name),
                                                            new XAttribute("ReturnType", method.ReturnType.FullName ?? "Generic"),
                                                            new XElement("Parameters",
                                                            from para in method.GetParameters()
                                                            select new XElement("Parameter",
                                                            new XAttribute("Name", para.Name),
                                                            new XAttribute("Type", para.ParameterType))))));
            var typesInXML = new XElement("Types", allPublicTypes);


            Console.WriteLine(typesInXML.ToString());


            //---------------------------------part 3 a ------------------------------------------

            var typesWithoutProperties = from type in allPublicTypes
                                         where type.Element("Properties").Descendants().Count() == 0
                                         let name = (string)type.Attribute("FullName")
                                         orderby name
                                         select name;

            Console.WriteLine($"There are {typesWithoutProperties.Count()} types that have no properties at all");
            Console.WriteLine();

            //---------------------------------part 3 b ----------------------------------------------

            int sum = 0;
            foreach(var type in allPublicTypes)
            {
                sum += type.Element("Methods").Descendants().Count();
            }

            Console.WriteLine($"The Total number of methods is {sum}");

            //---------------------------------part 3 c ----------------------------------------------

            sum = 0;
            foreach (var type in allPublicTypes)
            {
                sum += type.Element("Properties").Descendants().Count();
            }

            Console.WriteLine($"The Total number of properties is {sum}");

            var allParameters = from parameter in allPublicTypes.Descendants("Parameter")
                             group parameter by (string)parameter.Attribute("Type")
                             into allParametersInTypeGroups
                             orderby allParametersInTypeGroups.Count() descending
                             select new
                             {
                                 Name = allParametersInTypeGroups.Key,
                                 Count = allParametersInTypeGroups.Count()
                             };
        }
    }
}
