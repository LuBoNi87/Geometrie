using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema2_triunghi
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
            int n = r.Next(3,10);
            float raza = 1;
            Pen p = new Pen(Color.Black, 3);
            float[] x = new float[n];
            float[] y = new float[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = r.Next(10, panel1.Width);
                y[i] = r.Next(10, panel1.Height);
                g.DrawEllipse(p, x[i] - raza, y[i] - raza, raza * 2, raza * 2);
            }
            float aria_min = 9999;
            float aria = 0;
            float x1 = 0, x2 = 0, x3 = 0;
            float y1 = 0, y2 = 0, y3 = 0;
            for (int i = 0; i < n-2; i++)
            {
                for (int j = i+1; j < n-1; j++)
                {
                    for (int k = j+1; k < n; k++)
                    {
                        aria = Math.Abs((x[i] * y[j] + x[j] * y[k] + x[k] * y[i] - y[j] * x[k] - y[k] * x[i] - y[i] * x[j]) / 2);
                        if (aria < aria_min)
                        {
                            aria_min = aria;
                            x1= x[i];
                            y1 = y[i];
                            x2= x[j];
                            y2 = y[j];
                            x3 = x[k];
                            y3 = y[k];
                        }
                    }
                }
            }
            g.DrawLine(p, x1,y1, x2,y2);
            g.DrawLine(p, x1, y1, x3, y3);
            g.DrawLine(p, x3, y3, x2, y2);

        }
    }
}
//x1 y1 1
//x2 y2 1
//x3 y3 1
// A = (x1*y2 + x2*y3 + x3*y1 - y2*x3 - y3*x1 - y1*x2)/2;
