using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cerc_minim
{
    internal class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Circle(Point c, double r)
        {
            this.Center = c;
            this.Radius = r;
        }
        static Point GetCircleCenter(Point b, Point c)
        {
            double B_mod = b.X * b.X + b.Y * b.Y;
            double C_mod = c.X * c.X + c.Y * c.Y;
            double D = b.X * c.Y - b.Y * c.X;
            return new Point(Convert.ToInt32((c.Y * B_mod - b.Y * C_mod) / (2 * D)), Convert.ToInt32((b.X * C_mod - c.X * B_mod) / (2 * D)));
        }
        static double Dist(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        public bool IsInside(Point p)
        {
            return Dist(Center, p) <= Radius;
        }
        public Circle(Point A, Point B, Point C)
        {
            Point I = GetCircleCenter(new Point(B.X - A.X, B.Y - A.Y), new Point(C.X - A.X, C.Y - A.Y));
            I = new Point(I.X + A.X, I.Y + A.Y);
            this.Center = I;
            this.Radius = Dist(I, A);
        }
        public Circle(Point a, Point b)
        {
            Point C = new Point(Convert.ToInt32((a.X + b.X) / 2.0), Convert.ToInt32((a.Y + b.Y) / 2.0));
            this.Center = C;
            this.Radius = Dist(a, b) / 2.0;
        }
        public bool IsValid(IList<Point> Points)
        {
            foreach (Point p in Points)
            {
                if (!IsInside(p))
                    return false;
            }
            return true;
        }


    }
}
