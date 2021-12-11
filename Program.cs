using System;
using System.Linq;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter coordinate x of dot A:");
            double ax = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot A:");
            double ay = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coordinate x of dot B:");
            double bx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot B:");
            double by = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coordinate x of dot C:");
            double cx = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot C:");
            double cy = Convert.ToDouble(Console.ReadLine());

            Triangle ABC = new Triangle(ax, ay, bx, by, cx, cy);

            Console.Write("Triangle Existence: ");
            Console.WriteLine(ABC.Exists());

            Console.WriteLine("Triangle Sides Length: ");
            foreach (var side in ABC.GetSideSizes())
            {
                Console.WriteLine(side);
            }

            Console.Write("Triangle Perimeter: ");
            Console.WriteLine(ABC.GetPerimeter());
            for (var i = 0; i <= ABC.GetPerimeter(); i = i + 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Triangle Is Isosceles: ");
            Console.WriteLine(ABC.IsIsosceles());

            Console.WriteLine("Triangle Is Equilateral: ");
            Console.WriteLine(ABC.IsEquilateral());

            Console.WriteLine("Triangle Is Right: ");
            Console.WriteLine(ABC.IsRight());

        }
    }

    public class Triangle
    {
        internal class Point
        {
            public double X;
            public double Y;

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double GetSize()
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }


        private Point[] verts = new Point[3];

        private double[] _sizes = new double[3];

        public Triangle(double ax, double ay, double bx, double by, double cx, double cy)
        {
            verts[0] = new Point(bx - ax, by - ay);
            verts[1] = new Point(cx - bx, cy - by);
            verts[2] = new Point(cx - ax, cy - ay);

            _sizes = verts.Select(x => x.GetSize()).ToArray();

        }

        public double[] GetSideSizes()
        {
            return _sizes;
        }

        public double GetPerimeter()
        {
            return GetSideSizes().Sum();
        }

        public bool Exists()
        {
            return _sizes[0] + _sizes[1] > _sizes[2] && _sizes[0] + _sizes[2] > _sizes[1] && _sizes[1] + _sizes[2] > _sizes[0];
        }

        public bool IsIsosceles()
        {
            var sizes = GetSideSizes();
            if ((Math.Abs(sizes[0] - sizes[1]) <= 0.01)
                || (Math.Abs(sizes[1] - sizes[2]) <= 0.01)
                || (Math.Abs(sizes[0] - sizes[2]) <= 0.01)) return true;
            else return false;
        }

        public bool IsEquilateral()
        {
            var sizes = GetSideSizes();
            if ((Math.Abs(sizes[0] - sizes[1]) <= 0.01)
                && (Math.Abs(sizes[1] - sizes[2]) <= 0.01)
                && (Math.Abs(sizes[0] - sizes[2]) <= 0.01)) return true;
            else return false;
        }

        public bool IsRight()
        {
            var sizes = GetSideSizes();
            if ((Math.Abs(sizes[0] * sizes[0] - sizes[1] * sizes[1] - sizes[2] * sizes[2]) <= 0.01)
                || (Math.Abs(sizes[1] * sizes[1] - sizes[0] * sizes[0] - sizes[2] * sizes[2]) <= 0.01)
                || (Math.Abs(sizes[2] * sizes[2] - sizes[1] * sizes[1] - sizes[0] * sizes[0]) <= 0.01)) return true;
            else return false;
        }

    }

}
