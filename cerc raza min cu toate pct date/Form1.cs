using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cerc_raza_min_cu_toate_pct_date
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Se da o multime de puncte in plan, sa se det cercul de arie minima care
        // sa contina toate punctele in interior.
        //"Minimal enclosing circle"
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random r = new Random();
            int n = r.Next(100);
            float raza = 1;
            float max_dist = 0;
            float raza_cerc = 0;
            Pen p = new Pen(Color.Black, 3);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            List<float> x = new List<float>();
            List<float> y = new List<float>();
            float xa=0, ya=0,xb=0,yb=0;
            Point C = new Point();
            float maxleft=999, maxright=999, maxtop=0, maxbottom=0;
            for (int i = 0; i < n; i++)
            {
                float x1 = r.Next(25, panel1.Width-50);
                float y1 = r.Next(25, panel1.Height-50);
                g.DrawEllipse(p, x1 - raza, y1 - raza, raza * 2, raza * 2);
                if(x1<maxleft)
                    maxleft = x1;
                if(y1<maxtop)
                    maxtop = y1;
                if(x1>maxright)
                    maxright = x1;
                if(y1>maxbottom)
                    maxbottom = y1;
                x.Add(x1);
                y.Add(y1);
            }
            for (int i = 0; i < x.Count; i++)
                for (int j = 0; j < y.Count; j++)
                {
                    float dist = Math.Abs((float)Math.Sqrt(Math.Pow(x[j] - x[i], 2) + Math.Pow(y[j] - y[i], 2)));
                    if (dist > max_dist)
                    {
                        max_dist = dist;
                        xa = x[i];
                        ya = y[i];
                        xb = x[j];
                        yb = y[j];
                        C.X = (int)(xa + xb) / 2;
                        C.Y = (int)(ya + yb) / 2;
                    }
                }
            raza_cerc = max_dist / 2;
            g.DrawEllipse(redPen, xa - raza, ya - raza, raza * 2, raza * 2);
            g.DrawEllipse(greenPen, xb - raza, yb - raza, raza * 2, raza * 2);
            g.DrawEllipse(redPen, C.X - raza, C.Y - raza, raza * 2, raza * 2);
            float xCerc = Math.Min(xa, xb);
            float yCerc = Math.Min(ya, yb);
            g.DrawEllipse(p, maxleft - raza, maxtop - raza, max_dist, max_dist);
        }
    }
}
