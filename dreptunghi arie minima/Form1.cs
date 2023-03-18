using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dreptunghi_arie_minima
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
            int n = r.Next(100);
            float raza = 1;
            Pen p = new Pen(Color.Black, 3);
            float xa = panel1.Width, ya = panel1.Height;
            float xb = 0, yb = 0;
            for (int i = 0; i < n; i++)
            {
                float x1 = r.Next(10, panel1.Width);
                float y1 = r.Next(10, panel1.Height);
                g.DrawEllipse(p, x1 - raza, y1 - raza, raza * 2, raza * 2);
                if(x1-raza<xa)
                    xa = x1-raza;
                if(y1-raza<ya)
                    ya = y1-raza;
                if(x1-raza>xb)
                    xb = x1-raza;
                if(y1-raza > yb)
                    yb = y1-raza;
            }
            g.DrawRectangle(p, xa, ya, xb-xa, yb-ya);
        }
    }
}
