using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_5_Jarvis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int n=10;
        Graphics g;
        List<Point> points;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void buttonDraw_Click_1(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.GradientInactiveCaption);
            Brush brush = new SolidBrush(Color.Black);
            points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(50, this.panel1.Width - 50), rnd.Next(50, this.panel1.Height - 50));
                points.Add(p);
                g.DrawEllipse(new Pen(Color.Black,3), p.X - 1, p.Y - 2, 2, 2);

            }
        }

        private void buttonDeseneaza_Click_1(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen convex = new Pen(Color.Black, 3);

            List<int> hull = new List<int>();
            bool goOn;
            int iMin = 0;
            for (int i = 0; i < n; i++)
            {
                if (points[i].Y < points[iMin].Y)
                {
                    iMin = i;
                }
            }
            hull.Add(iMin);
            do
            {
                goOn = true;
                int pArbitrar = (hull[hull.Count - 1] + 1) % n;
                for (int i = 0; i < n; i++)
                {
                    if (DetSensTrigonometric(points[hull[hull.Count - 1]].X, points[hull[hull.Count - 1]].Y, points[i].X, points[i].Y, points[pArbitrar].X, points[pArbitrar].Y) > 0)
                    {
                        pArbitrar = i;
                    }
                }
                hull.Add(pArbitrar);
                if (pArbitrar == iMin)
                {
                    goOn = false;
                }
            } while (goOn);

            for (int i = 0; i < hull.Count - 1; i++)
            {
                g.DrawLine(convex, points[hull[i]].X, points[hull[i]].Y, points[hull[i + 1]].X, points[hull[i + 1]].Y);
            }
        }

        private double DetSensTrigonometric(double pX, double pY, double qX, double qY, double rX, double rY)
        { return pX * qY + qX * rY + pY * rX - rX * qY - pX * rY - qX * pY; }
    }
}