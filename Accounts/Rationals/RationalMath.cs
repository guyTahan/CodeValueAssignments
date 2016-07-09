using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rationals
{
    class RationalMath
    {

        public Rational Add(Rational ra1, Rational ra2)
        {
            int numerator = ra1.Numerator * ra2.Denominator + ra2.Numerator * ra1.Denominator;
            int denominator = ra1.Denominator * ra2.Denominator;

            return new Rational(numerator, denominator);
        }
    }
}
