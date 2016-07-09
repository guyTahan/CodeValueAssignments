using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public class RationalHelper
    {
        public struct Rational
        {
            private int numerator;
            private int denominator;

            public double Value
            {
                get { return (double)numerator / denominator; }
            }

            

            public int Denominator
            {
                get { return denominator; }
                set { denominator = value; }
            }
            public int Numerator
            {
                get { return numerator; }
                set { numerator = value; }
            }


            public Rational(int numerator, int denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            public Rational(int numerator)
            {
                this.numerator = numerator;
                this.denominator = 1;
            }



            public void reduce()
            {
                RationalMath rm = new RationalMath();
                int divider = rm.GCD(this.Numerator, this.Denominator);
                if (divider > 1)
                {
                    this.Numerator = this.Numerator / divider;
                    this.Denominator = this.Denominator / divider;
                }
            }


            public override string ToString()
            {
                return ((double)Numerator / (double)Denominator).ToString();
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {

                if (obj == null)
                {
                    return false;
                }

                try
                {
                    Rational thisRa = new Rational(this.numerator, this.denominator);
                    Rational otherRa = new Rational(((Rational)obj).numerator, ((Rational)obj).denominator);

                    thisRa.reduce();
                    otherRa.reduce();
                    if (thisRa.denominator == otherRa.denominator && thisRa.numerator == otherRa.numerator)
                    {
                        return true;
                    }
                }
                catch (InvalidCastException)
                {
                    return false;
                }

                return false;

            }

            public static Rational operator +(Rational a, Rational b)
            {
                int a1 = a.Numerator;
                int a2 = a.Denominator;

                int b1 = b.Numerator;
                int b2 = b.Denominator;

                int c1 = a1 * b2 + a2 * b1;
                int c2 = a2 * b2;
                Rational output = new Rational(c1, c2);

                return output;
            }

            public static Rational operator -(Rational a, Rational b)
            {
                int a1 = a.Numerator;
                int a2 = a.Denominator;

                int b1 = b.Numerator;
                int b2 = b.Denominator;

                int c1 = a1 * b2 - a2 * b1;
                int c2 = a2 * b2;
                Rational output = new Rational(c1, c2);

                return output;
            }

            public static Rational operator *(Rational a, Rational b)
            {
                int a1 = a.Numerator;
                int a2 = a.Denominator;

                int b1 = b.Numerator;
                int b2 = b.Denominator;

                int c1 = a1 * b1;
                int c2 = a2 * b2;
                Rational output = new Rational(c1, c2);

                return output;
            }

            public static Rational operator /(Rational a, Rational b)
            {
                int a1 = a.Numerator;
                int a2 = a.Denominator;

                int b1 = b.Numerator;
                int b2 = b.Denominator;

                int c1 = a1 * b2;
                int c2 = a2 * b1;
                Rational output = new Rational(c1, c2);

                return output;
            }

            public static explicit operator Rational(int i)
            {           
                return new Rational(i,1);
            }

            public static explicit operator double(Rational r)
            {
                double a = r.Numerator;
                double b = r.Denominator;

                return a/b;
            }


        }
    }
}
