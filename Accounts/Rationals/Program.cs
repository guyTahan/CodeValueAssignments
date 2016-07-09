using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        struct Rational
        {
            private int numerator;
            private int denominator;

            public double Value
            {
                get { return (double)numerator / denominator;}
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

            public static Rational Add(Rational ra1, Rational ra2)
            {
                int numerator = ra1.Numerator * ra2.Denominator + ra2.Numerator * ra1.Denominator;
                int denominator = ra1.Denominator * ra2.Denominator;

                return new Rational(numerator, denominator);
            }

            public static Rational Mul(Rational ra1, Rational ra2)
            {
                int numerator = ra1.Numerator * ra2.Numerator;
                int denominator = ra1.Denominator * ra2.Denominator;
                return new Rational(numerator,denominator);
            }

            public static int GCD(int num1, int num2)
            {
                int gcd = 1;

                for (int i =num1; i>=1; i--)
                {
                    if ( num1%i == 0 && num2%i == 0)
                    {
                        gcd=i;
                        return gcd;
                    }
                }
                return gcd;
            }

            public void reduce()
            {
                int divider = GCD(this.Numerator, this.Denominator);
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
                    Rational thisRa = new Rational(this.numerator,this.denominator);
                    Rational otherRa = new Rational ( ((Rational)obj).numerator, ((Rational)obj).denominator);

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


        }

        static void Main(string[] args)
        {
            Rational ra1 = new Rational(5, 10);
            Rational ra2 = new Rational(20, 40);
           
            Console.WriteLine("Creating ra1 = 5/10  and ra2=20/40");
            Console.WriteLine("");
            ra1.reduce();


            Console.WriteLine("ra1 after reduce is:  numinator: " + ra1.Numerator + " denom: " + ra1.Denominator);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Result of ra1.Equals(ra2) = " + ra1.Equals(ra2));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("creating Rational ra3 = ra1 + ra2 :");
            Rational ra3 = Rational.Add(ra1,ra2);
            Console.WriteLine("Result: ra3 = " + ra3);
            Console.WriteLine();

            Console.WriteLine("creating Rational ra4 = ra1 * ra2 :");
            Rational ra4 = Rational.Mul(ra1, ra2);
            Console.WriteLine();
            Console.WriteLine("result: " + ra4);
            Console.WriteLine();

            Console.WriteLine("ra1: " + ra1 + " ra2: " + ra2 + " ra3: " + ra3 + " ra4: " + ra4);

            Console.WriteLine();

            Console.WriteLine();
 
            Console.WriteLine("Creating ra5 = 20/41");
            Rational ra5 = new Rational(20, 41);
            Console.WriteLine("ra1 == ra5  is : " + ra1.Equals(ra5));
        }
    }
}
