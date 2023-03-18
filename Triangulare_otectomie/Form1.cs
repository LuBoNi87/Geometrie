using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Triangulare_otectomie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        List<Point> points = new List<Point>();
        List<Tuple<int, int, int>> triangles = new List<Tuple<int, int, int>>();
        int contor = 0;
        bool drawingMode = true;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            buttonFinish_Draw.Enabled = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (drawingMode)
            {
                Pen pen = new Pen(Color.Black, 3);
                Point aux = new Point(e.X, e.Y);
                Pen linie = new Pen(Color.DarkBlue, 2);
                g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
                contor++;
                g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
                if (points.Count != 0)
                {
                    g.DrawLine(linie, aux, points[points.Count - 1]);
                }
                points.Add(aux);
            }
        }

        private void buttonFinish_Draw_Click(object sender, EventArgs e)
        {
            if (drawingMode)
            {
                Graphics g = panel1.CreateGraphics();
                Pen linie = new Pen(Color.DarkBlue, 2);
                g.DrawLine(linie, points[0], points[points.Count - 1]);
                    buttonFinish_Draw.Enabled = false;
                drawingMode = false;
                buttonTriangulare.Enabled = true;
            }
        }

        private void buttonTriangulare_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen penTR = new Pen(Color.Black, 2);
            List<Point> puncteTriangulare = new List<Point>(points);
            int n = puncteTriangulare.Count;
            int newLabelY = label1.Location.Y + 20;
            while (n > 3)
            {
                for (int i = 0; i < n - 2; i++)
                {
                    if (IsDiagonal(puncteTriangulare, i, i + 2))
                    {
                        IdentificareTriunghi(newLabelY, puncteTriangulare, i);
                        newLabelY += 20;
                        g.DrawLine(penTR, puncteTriangulare[i], puncteTriangulare[i + 2]);
                        puncteTriangulare.RemoveAt(i + 1);
                        n--;
                        break;
                    }
                }
            }
            IdentificareTriunghi(newLabelY, puncteTriangulare, 0);

            buttonTricolorare.Enabled = true;
            buttonArie.Enabled = true;
        }
        private bool IsDiagonal(List<Point> puncte, int i, int j)
        {
            bool intersectie = false;
            for (int k = 0; k < puncte.Count - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(puncte[i], puncte[j], puncte[k], puncte[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            if (i != puncte.Count - 1 && i != 0 && j != puncte.Count - 1 && j != 0 && se_intersecteaza(puncte[i], puncte[j], puncte[puncte.Count - 1], puncte[0]))
            {
                intersectie = true;
            }
            if (!intersectie && se_afla_in_interiorul_poligonului(puncte, i, j))
            {
                return true;
            }
            return false;
        }
        private void IdentificareTriunghi(int labelY, List<Point> puncteTriangulare, int i)
        {
            Label labelTriangle = new Label();
            labelTriangle.Parent = panel1;
            labelTriangle.Location = new Point(label1.Location.X, labelY);
            labelTriangle.Text = "";
            labelTriangle.AutoSize = true;
            this.Controls.Add(labelTriangle);
            int varful1 = 0, varful2 = 0, varful3 = 0;
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i].X && points[j].Y == puncteTriangulare[i].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString() + ", ";
                    varful1 = j;
                    break;
                }
            }
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i + 1].X && points[j].Y == puncteTriangulare[i + 1].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString() + ", ";
                    varful2 = j;
                    break;
                }
            }
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i + 2].X && points[j].Y == puncteTriangulare[i + 2].Y)
                {
                    labelTriangle.Text = labelTriangle.Text + (j).ToString();
                    varful3 = j;
                    break;
                }
            }
            triangles.Add(new Tuple<int, int, int>(varful1, varful2, varful3));
        }
        private int ValoareDeterminant(Point a, Point b, Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool se_afla_in_interiorul_poligonului(List<Point> puncte, int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : puncte.Count - 1;
            int pi_urm = (pi < puncte.Count - 1) ? pi + 1 : 0;
            if ((este_varf_convex(puncte, pi) && intoarcere_spre_stanga(puncte, pi, pj, pi_urm) && intoarcere_spre_stanga(puncte, pi, pi_ant, pj)) || (este_varf_reflex(puncte, pi) && !(intoarcere_spre_dreapta(puncte, pi, pj, pi_urm) && intoarcere_spre_dreapta(puncte, pi, pi_ant, pj))))
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_dreapta(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) < 0)
            {
                return true;
            }
            return false;
        }

        private bool este_varf_reflex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(puncte, p_ant, p, p_urm);
        }

        private bool este_varf_convex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(puncte, p_ant, p, p_urm);
        }

        private bool se_intersecteaza(Point s1, Point s2, Point p1, Point p2)
        {
            if (ValoareDeterminant(p2, p1, s1) * ValoareDeterminant(p2, p1, s2) <= 0 && ValoareDeterminant(s2, s1, p1) * ValoareDeterminant(s2, s1, p2) <= 0)
            {
                return true;
            }
            return false;
        }

        private void buttonTricolorare_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen[] pens = new Pen[] { new Pen(Color.Blue, 3), new Pen(Color.Green, 3), new Pen(Color.Red, 3) };
            List<Tuple<int, int>> varfuriMarcate = new List<Tuple<int, int>>();
            for (int i = triangles.Count - 1; i >= 0; i--)
            {
                int colored1 = EsteColorat(triangles[i].Item1, varfuriMarcate);
                int colored2 = EsteColorat(triangles[i].Item2, varfuriMarcate);
                int colored3 = EsteColorat(triangles[i].Item3, varfuriMarcate);
                if (colored1 == -1 && colored2 == -1 && colored3 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, 0));
                    g.DrawEllipse(pens[0], points[triangles[i].Item1].X - 5, points[triangles[i].Item1].Y - 5, 10, 10);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, 1));
                    g.DrawEllipse(pens[1], points[triangles[i].Item2].X - 5, points[triangles[i].Item2].Y - 5, 10, 10);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, 2));
                    g.DrawEllipse(pens[2], points[triangles[i].Item3].X - 5, points[triangles[i].Item3].Y - 5, 10, 10);
                }
                else if (colored1 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, UrmatoareaCuloare(colored2, colored3)));
                    g.DrawEllipse(pens[UrmatoareaCuloare(colored2, colored3)], points[triangles[i].Item1].X - 5, points[triangles[i].Item1].Y - 5, 10, 10);
                }
                else if (colored2 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, UrmatoareaCuloare(colored1, colored3)));
                    g.DrawEllipse(pens[UrmatoareaCuloare(colored1, colored3)], points[triangles[i].Item2].X - 5, points[triangles[i].Item2].Y - 5, 10, 10);
                }
                else if (colored3 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, UrmatoareaCuloare(colored1, colored2)));
                    g.DrawEllipse(pens[UrmatoareaCuloare(colored1, colored2)], points[triangles[i].Item3].X - 5, points[triangles[i].Item3].Y - 5, 10, 10);
                }
            }
        }

        private int EsteColorat(int punct, List<Tuple<int, int>> varfuriMarcate)
        {
            for (int i = 0; i < varfuriMarcate.Count; i++)
            {
                if (varfuriMarcate[i].Item1 == punct)
                {
                    return varfuriMarcate[i].Item2;
                }
            }
            return -1;
        }

        private int UrmatoareaCuloare(int a, int b)
        {
            if ((a == 0 && b == 1) || (a == 1 && b == 0))
            {
                return 2;
            }
            if ((a == 0 && b == 2) || (a == 2 && b == 0))
            {
                return 1;
            }
            if ((a == 1 && b == 2) || (a == 2 && b == 1))
            {
                return 0;
            }
            return -1;
        }
        private void buttonArie_Click(object sender, EventArgs e)
        {
            double arieTotala = 0;
            for (int i = 0; i < triangles.Count; i++)
            {
                arieTotala += ArieTriunghi(points[triangles[i].Item1].X, points[triangles[i].Item1].Y, points[triangles[i].Item2].X, points[triangles[i].Item2].Y, points[triangles[i].Item3].X, points[triangles[i].Item3].Y);
            }
            labelArie.Text = arieTotala.ToString();
        }

        private double ArieTriunghi(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x1 * y3 - x2 * y1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}