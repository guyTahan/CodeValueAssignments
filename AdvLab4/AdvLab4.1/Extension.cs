using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLab4._1
{
    public static class Extension
    {
        public static void CopyTo(this object obj, object other)
        {
            var query = from a in obj.GetType().GetProperties()
                        from b in other.GetType().GetProperties()
                        where a.Name == b.Name && a.CanRead && b.CanWrite && a.PropertyType == b.PropertyType
                        select new
                        {
                            ObjProperty = a,
                            OtherProperty = b
                        };

            foreach (var val in query)
            {
                val.OtherProperty.SetValue(other, val.ObjProperty.GetValue(obj, null), null);
            }
        }
    }
}
