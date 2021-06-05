using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            Point p2 = new Point(3.14, 4.15);
            Point p3 = new Point(5, 6);
            Point p4 = new Point("(3.0, 4.0)");

            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p2 = {p2}");


            Console.WriteLine($"Distanta de la punctul {p3} la origine este {p3.DistanceToOrigin()}");
            Console.WriteLine($"Distanta de la punctul {p3} la origine este {p3.DistanceTo(p2).ToString("#.##")}");

            Line line1 = new Line(p2, p3);
            Line line2 = new Line(1.0, 2.0, 3.0, 4.0);

            Console.WriteLine($"line1 = {line1}, length = {line1.Length}");

            Console.WriteLine(new Point("(2.0, 1.0)"));
        }
    }
}
