using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace desenare_poligon
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = 0;
            Pen black_pen = new Pen(Color.Black,3);
            Pen white_pen = new Pen(Color.White,3);
            static Random random = new Random();
            static int n = random.Next(3,10);
            List<PointF> p = new List<PointF>(n);
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }
        public void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (x <= n)
            {
                if (x > 0)
                    g.DrawLine(white_pen, p[p.Count - 1], p[0]);
                x++;
                PointF aux;
                aux = PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y));
                g.DrawEllipse(black_pen, aux.X - 1, aux.Y - 1, 2, 2);
                g.DrawString(x.ToString(), new Font(FontFamily.GenericSansSerif, 10),
                  new SolidBrush(Color.Black), aux);
                p.Add(new PointF(aux.X, aux.Y));
                for (int i = 0; i < p.Count - 1; i++)
                {
                    g.DrawLine(black_pen, p[i], p[i + 1]);
                    if (i >= n)
                        break;
                    g.DrawLine(black_pen, p[p.Count - 1], p[0]);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
