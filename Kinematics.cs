using System;
using System.Collections.Generic;

namespace LineasWPF
{
    class Kinematics
    {
        public static Point Rot(Point point, double angle)
        {
            var Cos = Math.Cos(angle);
            var Sin = Math.Sin(angle);
            var x = point.X * Cos - point.Y * Sin;
            var y = point.Y * Cos + point.X * Sin;
            return new Point(x,y);
        }
        public static double Angle(Point pointA, Point pointB)
        {
            return Math.Atan2(pointB.Y - pointA.Y, pointB.X - pointA.X);
        }
        public static Point Dir(Point pointA, Point pointB)
        {
            var res = pointB - pointA;
            var length = res.Length();
            return new Point(res.X/length, res.Y/length);
        }
        public static Point Rot(Point point, Point direction)
        {
            var x = point.X * direction.X - point.Y * direction.Y;
            var y = point.Y * direction.X + point.X * direction.Y;
            return new Point(x,y);
        }
        public static Point Move(Point point, Point Distance)
        {
            var x = point.X + Distance.X;
            var y = point.Y + Distance.Y;
            return new Point(x, y);
        }
        public static Point RotAndMove(Point point, Point direction, Point distance)
        {
            //Rota en torno al punto (0,0) con dirección normalizada y los mueve 
            var x = point.X * direction.X - point.Y * direction.Y + distance.X;
            var y = point.Y * direction.X + point.X * direction.Y + distance.Y;
            return new Point(x, y);
        }
        public static Point RotAndMove(Point point, double angle, Point distance)
        {
            var Cos = Math.Cos(angle);
            var Sin = Math.Sin(angle);
            var x = point.X * Cos - point.Y * Sin + distance.X;
            var y = point.Y * Cos + point.X * Sin + distance.Y;
            return new Point(x, y);
        }
        public static List<Point> RotAndMove(List<Point> points, double angle, Point distance)
        {
            var list = new List<Point>();
            var Cos = Math.Cos(angle);
            var Sin = Math.Sin(angle);
            foreach(var point in points)
            {
                var x = point.X * Cos - point.Y * Sin + distance.X;
                var y = point.Y * Cos + point.X * Sin + distance.Y;
                list.Add(new Point(x, y));
            }
            return list;
        }
    }
}
