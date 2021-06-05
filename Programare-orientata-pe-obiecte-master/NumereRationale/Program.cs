using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Assignment_Numere_Rationale
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(16, 9);
            Rational r2 = new Rational(4, 7);
            Rational r3 = r1.Power(2);
        }
    }
}
