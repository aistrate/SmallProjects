using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TravelingSalesman
{
    public class Point
    {
        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }

        public static decimal Distance(Point a, Point b)
        {
            return (decimal)Math.Sqrt(Math.Pow(decimal.ToDouble(b.X - a.X), 2) + Math.Pow(decimal.ToDouble(b.Y - a.Y), 2));
        }

        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }

        public static RectangleF CreateRectangleF(Point a, Point b)
        {
            return new RectangleF(a.ToPointF(), new SizeF((float)(b.X - a.X), (float)(b.Y - a.Y)));
        }

        public override string ToString()
        {
            return string.Format("({0:000}, {1:000})", X, Y);
        }
    }

    public class PointList : List<Point>
    {
        public PointList() : base() { }
        public PointList(IEnumerable<Point> collection) : base(collection) { }
        public PointList(int capacity) : base(capacity) { }

        public void Add(decimal x, decimal y)
        {
            Add(new Point(x, y));
        }

        public PointList Clone()
        {
            PointList newList = new PointList();
            newList.AddRange(this);
            return newList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");
            bool first = true;
            foreach (Point p in this)
            {
                sb.AppendFormat("{0}{1}", (first ? "" : ";  "), p);
                first = false;
            }
            sb.Append("}");
            return sb.ToString();
        }
    }

    public class PairOfPoints
    {
        public PairOfPoints(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public Point A { get; set; }
        public Point B { get; set; }

        public decimal Distance
        {
            get { return Point.Distance(A, B); }
        }

        public PairOfPoints Invert()
        {
            return new PairOfPoints(B, A);
        }

        public override bool Equals(object obj)
        {
            PairOfPoints other = obj as PairOfPoints;
            return other != null && other.A == A && other.B == B;
        }
    }
}
