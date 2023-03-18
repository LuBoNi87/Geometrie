using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace invelitoare_convexa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random random = new Random();
            int n = random.Next(50);
            int[] a = new int[n];
            Point[] points = new Point[n];
            Point[] good_points = new Point[n];
            Pen redPen = new Pen(Color.Red,3);
            Pen greenPen = new Pen(Color.Green,3);
            Pen blackPen = new Pen(Color.Black,1);
            for (int i = 0; i < n; i++)
            {
                points[i].X = random.Next(panel1.Width);
                points[i].Y = random.Next(panel1.Height);
            }
            for (int i = 0; i < n-2; i++)
            {
                for (int j = i+1; j < n-1; j++)
                {
                    for (int k = j+1; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            if (l != i && l != j && l != k)
                                if (Apart(points[l], points[i], points[j], points[k]))
                                    a[l] = 1;
                        }
                    }
                }
            }
            int s = -1;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == 1)
                    g.DrawEllipse(redPen, points[i].X, points[i].Y - 1, 2, 2);
                else
                {
                    g.DrawEllipse(greenPen, points[i].X, points[i].Y - 1, 2, 2);
                    s++;
                    good_points[s].X=points[i].X;
                    good_points[s].Y=points[i].Y;
                }
            }
            Point p1 = new Point();
            Point p2 = new Point();
            if (s >= 0)
                p1 = good_points[0];
            if (s >= 1)
                p2 = good_points[1];
            Point min_point = new Point();
            for (int i = 0; i <= s; i++)
            {
                double max_angle = 0,an;
                for (int j = 0; j <= s; j++)
                {
                    an = Angle(p1, good_points[j], p2);
                    if (an > max_angle)
                    {
                        max_angle = Angle(p1, good_points[j], p2);
                        min_point = good_points[j];
                    }
                }
                    an = Angle(p1, good_points[0], p2);
                    if (an > max_angle)
                        min_point = good_points[0];
                p1 = p2;
                p2 = min_point;
                g.DrawLine(blackPen, p1, p2);
            }
        }

        private double Angle(Point p0, Point p1, Point c)
        {
            double p0c = Math.Sqrt(Math.Pow(c.X - p0.X, 2) +
                        Math.Pow(c.Y - p0.Y, 2)); // p0->c (b)   
            double p1c = Math.Sqrt(Math.Pow(c.X - p1.X, 2) +
                                Math.Pow(c.Y - p1.Y, 2)); // p1->c (a)
            double p0p1 = Math.Sqrt(Math.Pow(p1.X - p0.X, 2) +
                                 Math.Pow(p1.Y - p0.Y, 2)); // p0->p1 (c)
            return Math.Acos((p1c * p1c + p0c * p0c - p0p1 * p0p1) / (2 * p1c * p0c));
        }

        bool Apart(Point x, Point a, Point b, Point c)
        {
            bool apart = true;
            float k1, k2, k3;
            k1 = Sarrus(a, b, x);
            k2 = Sarrus(b, c, x);
            k3 = Sarrus(c, a, x);
            if(k1*k2<0 || k1*k3<0 || k2*k3<0)
                apart = false;
            return apart;
        }
        float Sarrus(Point a, Point b, Point c)
        {
            float x = a.X*b.Y + b.X*c.Y + c.X*a.Y - b.Y*c.X - c.Y*a.X - a.Y*b.X;
            return x;
        }
    }
}
