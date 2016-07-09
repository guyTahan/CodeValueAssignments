using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rationals.RationalHelper;

namespace Rationals
{
    class Program
    {
  
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Rational a = new Rationals.RationalHelper.Rational(1, 2);
            Rational b = new Rationals.RationalHelper.Rational(1, 4);

            Rational c = a + b;
            sb.Append(c.ToString());
            sb.Append(" = ");
            sb.Append(a.ToString());
            sb.Append(" + ");
            sb.AppendLine(b.ToString());

            Rational d = a - b;

            sb.Append(d.ToString());
            sb.Append(" = ");
            sb.Append(a.ToString());
            sb.Append(" - ");
            sb.AppendLine(b.ToString());

            Rational e = a * b;

            sb.Append(e.ToString());
            sb.Append(" = ");
            sb.Append(a.ToString());
            sb.Append(" * ");
            sb.AppendLine(b.ToString());

            Rational f = a / b;

            sb.Append(f.ToString());
            sb.Append(" = ");
            sb.Append(a.ToString());
            sb.Append(" / ");
            sb.AppendLine(b.ToString());

            double g = (double)a;
            sb.Append(g.ToString());
            sb.Append(" = (double)");
            sb.AppendLine(a.ToString());

            Rational h = (Rational)55;

            sb.Append(g.ToString());
            sb.Append(" = (Rational)");
            sb.AppendLine(a.ToString());

            Console.WriteLine("Test Complete, the results are:");
            Console.WriteLine(sb.ToString());

        }
    }
}
