using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_Assignment_Numere_Rationale
{
    public class Rational
    {
        int numerator, denominator;

        public Rational(int numerator, int denominator)
        {
            int greatestComDiv = gcd(numerator, denominator);

            this.numerator = numerator / greatestComDiv;
            this.denominator = denominator / greatestComDiv;
        }

        private int gcd(int numerator, int denominator)
        {
            while ( (numerator % denominator) > 0 )
            {
                int r = numerator % denominator;
                numerator = denominator;
                denominator = r;
            }
            return denominator;
        }

        public Rational(int numerator) : this(numerator, 1)
        {

        }

        public Rational(string fraction)
        {
            fraction = Regex.Replace(fraction, @"\s+", "");
            Regex pattern = new Regex(@"(\+|-|)\d+");
            MatchCollection matches = pattern.Matches(fraction);

            if (matches.Count != 2)
            {
                if (fraction.Contains("/"))
                {
                    throw new Exception("Incorrect input.");
                }
                else
                {
                    this.numerator = int.Parse(matches[0].ToString());
                    this.denominator = 1;
                }
                
            }
            else
            {
                this.numerator = int.Parse(matches[0].ToString());
                this.denominator = int.Parse(matches[1].ToString());

                if (this.numerator < 0 ^ this.denominator < 0)
                {
                    this.numerator = Math.Abs(this.numerator);
                    this.denominator = Math.Abs(this.denominator);

                    int greatestComDiv = gcd(numerator, denominator);

                    this.numerator /= greatestComDiv * -1;
                    this.denominator /= greatestComDiv;
                }
                else if (this.numerator < 0 && this.denominator < 0)
                {
                    this.numerator = Math.Abs(this.numerator);
                    this.denominator = Math.Abs(this.denominator);

                    int greatestComDiv = gcd(numerator, denominator);

                    this.numerator /= greatestComDiv;
                    this.denominator /= greatestComDiv;
                }
                else
                {
                    int greatestComDiv = gcd(numerator, denominator);

                    this.numerator /= greatestComDiv;
                    this.denominator /= greatestComDiv;
                }
            }
        }

        public Rational Multiplying(Rational r1) => new Rational(r1.numerator * this.numerator, r1.denominator * this.denominator);
        public Rational Division(Rational r1) => new Rational(this.numerator * r1.denominator, this.denominator * r1.numerator);
        public Rational Addition(Rational r1) => new Rational((this.numerator* r1.denominator) + (r1.numerator* this.denominator), this.denominator * r1.denominator);
        public Rational Subtraction(Rational r1) => new Rational((this.numerator * r1.denominator) - (r1.numerator * this.denominator), this.denominator * r1.denominator);
        public Rational SquareRoot() => new Rational((int)Math.Sqrt(this.numerator), (int)Math.Sqrt(this.denominator));
        public Rational Power(int n) => new Rational((int)Math.Pow(this.numerator, n), (int)Math.Pow(this.denominator, n));
    }
}
