using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionClass
{
    public class Fraction
    {
        protected long Numerator;
        protected long Denominator;
        public Fraction(long numer, long denom)
        {
            Numerator = numer;
            Denominator = denom;
            Fix();
            Simplify();
        }
        public Fraction(long numer)
        {
            Numerator = numer;
            Denominator = 1;
        }
        public Fraction(double l)
        {
            Denominator = 1;
            while (l > (long)l)
            {
                l *= 10;
                Denominator *= 10;
            }
            Numerator = (long)l;
            Simplify();
        }
        public Fraction(double num, double den)
        {
            Denominator = 1;
            while ((num > (long)num) || (den > (long)den))
            {
                num *= 10;
                den *= 10;
            }
            Numerator = (long)num;
            Denominator = (long)den;
            Simplify();
        }
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }
        public static Fraction operator +(Fraction a)
        {
            return new Fraction(a.Numerator, a.Denominator);
        }
        public static Fraction operator !(Fraction a)
        {
            Fraction res = new Fraction(a.Denominator, a.Numerator);
            res.Fix();
            return res;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + a.Denominator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator +(Fraction a, long b)
        {
            return a + new Fraction(b);
        }
        public static Fraction operator +(long a, Fraction b)
        {
            return new Fraction(a) + b;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - a.Denominator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator -(Fraction a, long b)
        {
            return a - new Fraction(b);
        }
        public static Fraction operator -(long a, Fraction b)
        {
            return new Fraction(a) - b;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator *(Fraction a, long b)
        {
            return a * new Fraction(b);
        }
        public static Fraction operator *(long a, Fraction b)
        {
            return new Fraction(a) * b;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * !b;
        }
        public static Fraction operator /(Fraction a, long b)
        {
            return a * !(new Fraction(b));
        }
        public static Fraction operator /(long a, Fraction b)
        {
            return new Fraction(a) * !b;
        }

        public void Simplify()
        {
            long num = Numerator;
            long den = Denominator;
            if (Numerator<0) {
                num *= -1;
            }
            while ((num != 0) && (den != 0))
            {
                if (num > den)
                     num %= den;
                else
                    den %= num;
            }
            long nod = Math.Max(num, den);
            Numerator /= nod;
            Denominator /= nod;
        }
        public void Fix()
        {
            if ((Numerator <= 0 && Denominator <= 0) || (Denominator <= 0 && Numerator >= 0))
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }
        public override string ToString()
        {
            string s = "Inf";
            if (Denominator == 0)
                return s;
            else
                return $"{Numerator}/{Denominator}";
        }
    }
}