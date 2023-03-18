using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cerc_minim
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
            Random r = new Random();
            List<Point> points = new List<Point>();
            int n = r.Next(5,25);
            Pen p = new Pen(Color.Black, 3);
            for (int i = 0; i < n; i++)
            {
                Point point = new Point();
                point.X = r.Next(50, panel1.Width-50);
                point.Y = r.Next(50, panel1.Height-50);
                g.DrawEllipse(p, point.X-1,point.Y-1,2,2);
                points.Add(point);
            }
            Circle final_circle = new Circle(new Point(0, 0), Double.PositiveInfinity);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Circle test_circle = new Circle(points[i], points[j]);
                    if (test_circle.Radius < final_circle.Radius && test_circle.IsValid(points))
                    {
                        final_circle = test_circle;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        Circle test_circle = new Circle(points[i], points[j], points[k]);
                        if (test_circle.Radius < final_circle.Radius && test_circle.IsValid(points))
                            final_circle = test_circle;
                    }
                }
            }
            Pen redp = new Pen(Color.Red, 3);
            float circleX = (float)final_circle.Center.X-(float)final_circle.Radius;
            float circleY = (float)final_circle.Center.Y-(float)final_circle.Radius;
            g.DrawEllipse(redp,circleX,circleY,(float)final_circle.Radius*2, (float)final_circle.Radius*2);
        }
    }
}
