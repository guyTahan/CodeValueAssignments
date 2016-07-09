using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rationals;
using static Rationals.RationalHelper;

namespace Rationals
{

    public class RationalMath
    {
        public RationalHelper.Rational Add(RationalHelper.Rational ra1, RationalHelper.Rational ra2)
        {
            int numerator = ra1.Numerator * ra2.Denominator + ra2.Numerator * ra1.Denominator;
            int denominator = ra1.Denominator * ra2.Denominator;

            return new RationalHelper.Rational(numerator, denominator);
        }

        public RationalHelper.Rational Mul(RationalHelper.Rational ra1, RationalHelper.Rational ra2)
        {
            int numerator = ra1.Numerator * ra2.Numerator;
            int denominator = ra1.Denominator * ra2.Denominator;
            return new Rational(numerator, denominator);
        }

        public int GCD(int num1, int num2)
        {
            int gcd = 1;

            for (int i = num1; i >= 1; i--)
            {
                if (num1 % i == 0 && num2 % i == 0)
                {
                    gcd = i;
                    return gcd;
                }
            }
            return gcd;
        }
    }
}
