using System;
using System.Text.RegularExpressions;

namespace LineasWPF
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double X,double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Point() { X = 0;Y = 0; }
        public static Point operator - (Point pointA, Point pointB)
        {
            return new Point(pointA.X-pointB.X,pointA.Y-pointB.Y);
        }
        public double Length()
        {
            return Math.Sqrt(X*X + Y*Y);
        }
    }
}
