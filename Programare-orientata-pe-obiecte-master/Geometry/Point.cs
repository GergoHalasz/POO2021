using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Geometry
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static Stack<Point> History { get; }

        public static void Undo() => History.Pop();

        public Point() : this(0.0, 0.0) { }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(string str)
        {
            Regex rgx = new Regex(@"\s*\(\s*(\d+(?:\.\d+)?)\s*,\s*(\d+(?:\.\d+)?)\s*\)\s*");
            var match = rgx.Match(str);

            if (match.Success)
            {
                X = double.Parse(match.Groups[1].ToString());
                Y = double.Parse(match.Groups[2].ToString());
            }

            else throw new ArgumentException("Input string was in wrong format.");
        }

        public override string ToString() => $"({X}, {Y})";

        public void MoveBy(double x, double y)
        {
            X += x;
            Y += y;
        }

        public double DistanceToOrigin() => DistanceTo(new Point());
        public double DistanceTo(Point point) => Math.Sqrt(Math.Pow(X - point.X, 2.0) + Math.Pow(Y - point.Y, 2.0));
    }
}