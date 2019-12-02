using System;
using FractionClass;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(5, 7);
            Fraction c = new Fraction(17);
            Fraction d = new Fraction(1.7);
            Fraction res = a + b;
            Console.WriteLine(a-c);
            Console.WriteLine(b+d);
            Console.WriteLine(b/a);
            Console.WriteLine(a*d);
            Console.WriteLine(-a);
            Console.WriteLine(a+c/d);

        }
    } 
}
