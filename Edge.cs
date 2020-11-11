using System;
using System.Collections.Generic;
using System.Windows;

namespace LineasWPF
{
    class Edge:DependencyObject
    {
        public event EventHandler ShapeChanged;
        private readonly double Thickness;
        private readonly List<Point> Stable;

        public Point Center { get; set; }
        public double Angle { get; set; }

        public Edge(bool isRight,double thickness)
        {
            if (isRight)
                Thickness = thickness;
            else Thickness = -thickness;
            Stable = new List<Point>();
            ToTrapezoidal();
        }
        protected virtual void OnShapeChanged()
        {
            ShapeChanged?.Invoke(this, EventArgs.Empty);
        }
        public void ToCircular()
        {
            Stable.Clear();
            var inc = Math.PI/10;
            double X,Y;
            var td2 = Thickness / 2;
            for (double angle = -Math.PI/2; angle <= Math.PI/2; angle += inc)
            {
                 X = td2 * Math.Cos(angle);
                 Y = td2 * Math.Sin(angle);
                Stable.Add(new Point( X, Y));
            }
            OnShapeChanged();
        }
        public void ToTrapezoidal()
        {
            Stable.Clear();
            Stable.Add(new Point( Thickness / 2, -Thickness / 2));
            Stable.Add(new Point( Thickness / 2,  Thickness / 2));
            OnShapeChanged();
        }
        public IEnumerable<Point> GetPositions()
        {
            var Cos = Math.Cos(Angle);
            var Sin = Math.Sin(Angle);
            foreach (var point in Stable)
            {
                var x = point.X * Cos - point.Y * Sin + Center.X;
                var y = point.Y * Cos + point.X * Sin + Center.Y;
                yield return new Point(x, y);
            }
        }
        public IEnumerable<Point> WithAngle(double angle)
        {
            var Cos = Math.Cos(angle);
            var Sin = Math.Sin(angle);
            foreach (var point in Stable)
            {
                var x = point.X * Cos - point.Y * Sin;
                var y = point.Y * Cos + point.X * Sin;
                yield return new Point(x, y);
            }
        }
    }
}
