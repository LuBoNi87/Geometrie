using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulare_Poligon_Monoton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        List<Point> points = new List<Point>();
        List<Tuple<int, int>> diagonals = new List<Tuple<int, int>>();
        List<List<int>> polygons = new List<List<int>>();

        int contor = 0;
        bool drawingMode = true;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            buttonFinishUp.Enabled = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
                Pen pen = new Pen(Color.Black, 3);
                Point aux = new Point(e.X, e.Y);
                Pen linie = new Pen(Color.Black, 2);
                g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
                contor++;
                g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
                if (points.Count != 0)
                {
                    g.DrawLine(linie, aux, points[points.Count - 1]);
                }
                points.Add(aux);

        }

        private void buttonFinishUp_Click(object sender, EventArgs e)
        {
            if (drawingMode)
            {
                Graphics g = panel1.CreateGraphics();
                Pen linie = new Pen(Color.Black, 2);
                g.DrawLine(linie, points[0], points[points.Count - 1]);
                buttonFinishUp.Enabled = false;
                drawingMode = false;
                buttonPartiton.Enabled = true;
            }
        }
        private void buttonPartiton_Click(object sender, EventArgs e)
        {
            buttonSavePolygons.Enabled = true;
            buttonPartiton.Enabled = false;
            Graphics g = panel1.CreateGraphics();
            Pen penPart = new Pen(Color.DarkBlue, 2);
            float[] dashValues = { 3, 2, 3, 2 };
            penPart.DashPattern = dashValues;
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (este_varf_reflex(points, i))
                {
                    if (i == 0)
                    {
                        if (este_sub(i, (points.Count - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (points.Count - 1)) && este_deasupra(i, (i + 1)))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                    else if (i == points.Count - 1)
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, 0))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, 0))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                    else
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, (i + 1)))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, points[i], points[index]);
                            diagonals.Add(new Tuple<int, int>(i, index));
                        }
                    }
                }
            }
        }

        private int UnVarfDeasupraVarfului(int i)
        {
            int minIndex = -1;
            for (int index = 0; index < points.Count; index++)
            {
                if (este_deasupra(i, index) && IsDiagonal(points, i, index))
                {
                    if (minIndex == -1)
                    {
                        minIndex = index;
                    }
                    else
                    {
                        if (points[index].Y > points[minIndex].Y)
                        {
                            minIndex = index;
                        }
                    }
                }
            }
            return minIndex;
        }

        private int UnVarfSubVarful(int i)
        {
            int maxIndex = -1;
            for (int index = 0; index < points.Count; index++)
            {
                if (este_sub(i, index) && IsDiagonal(points, i, index))
                {
                    if (maxIndex == -1)
                    {
                        maxIndex = index;
                    }
                    else
                    {
                        if (points[index].Y < points[maxIndex].Y)
                        {
                            maxIndex = index;
                        }
                    }
                }
            }
            return maxIndex;
        }

        private bool este_sub(int i, int j)
        {
            if (points[j].Y > points[i].Y || (points[j].Y == points[i].Y && points[j].X < points[i].X))
            {
                return true;
            }
            return false;
        }

        private bool este_deasupra(int i, int j)
        {
            if (points[j].Y < points[i].Y || (points[j].Y == points[i].Y && points[j].X < points[i].X))
            {
                return true;
            }
            return false;
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

        private void buttonSavePolygons_Click(object sender, EventArgs e)
        {

            buttonTriangulate.Enabled = true;
            buttonSavePolygons.Enabled = false;
            int[] determinantPoligoane = new int[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                determinantPoligoane[i] = 1;
            }
            for (int i = 0; i < diagonals.Count - 1; i++)
            {
                if (diagonals[i].Item1 < diagonals[i].Item2)
                {
                    List<int> poligon = new List<int>();
                    poligon.Add(diagonals[i].Item2);
                    for (int j = diagonals[i].Item2 + 1; j < points.Count; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    for (int j = 0; j < diagonals[i].Item1; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    poligon.Add(diagonals[i].Item1);
                    polygons.Add(poligon);
                }
                else
                {
                    List<int> poligon = new List<int>();
                    poligon.Add(diagonals[i].Item1);
                    poligon.Add(diagonals[i].Item2);
                    for (int j = diagonals[i].Item2 + 1; j < diagonals[i].Item1; j++)
                    {
                        if (determinantPoligoane[j] == 1)
                        {
                            determinantPoligoane[j] = 0;
                            poligon.Add(j);
                        }
                    }
                    polygons.Add(poligon);
                }
            }
            List<int> poligonFinal = new List<int>();
            for (int j = 0; j < points.Count; j++)
            {
                if (determinantPoligoane[j] == 1)
                {
                    determinantPoligoane[j] = 0;
                    poligonFinal.Add(j);
                }
            }
            polygons.Add(poligonFinal);
            for (int i = 0; i < polygons.Count; i++)
            {
                string result = "";
                for (int j = 0; j < polygons[i].Count; j++)
                {
                    result += polygons[i][j] + " ";
                }
                listBoxPoligoane.Items.Add(result);
            }
        }

        private bool intersecteazaAlteDiagonale(List<Point> punctePoligonCurent, List<Tuple<int, int>> diagonale, int i, int j)
        {
            bool intersectie = false;
            for (int k = 0; k < diagonale.Count; k++)
            {
                if (i != diagonale[k].Item1 && i != diagonale[k].Item2 && j != diagonale[k].Item1 && j != diagonale[k].Item2 && se_intersecteaza(punctePoligonCurent[i], punctePoligonCurent[j], punctePoligonCurent[diagonale[k].Item1], punctePoligonCurent[diagonale[k].Item2]))
                {
                    intersectie = true;
                    break;
                }
            }
            return intersectie;
        }

        private void buttonTriangulate_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen penTriang = new Pen(Color.Red, 2);
            for (int i = 0; i < polygons.Count; i++)
            {
                List<int> varfuriPoligonCurent = new List<int>();
                for (int j = 0; j < polygons[i].Count; j++)
                {
                    varfuriPoligonCurent.Add(polygons[i][j]);
                }
                List<Point> punctePoligonCurent = new List<Point>();
                for (int k = 0; k < varfuriPoligonCurent.Count; k++)
                {
                    punctePoligonCurent.Add(points[varfuriPoligonCurent[k]]);
                }
                List<Tuple<int, int>> diagonale = new List<Tuple<int, int>>();
                if (punctePoligonCurent.Count < 3)
                {
                    return;
                }
                List<int> lantA = new List<int>();
                List<int> lantOrdonat = OrdonareLexicografica(punctePoligonCurent);
                List<int> lantOrdonatOriginale = new List<int>();
                for (int k = 0; k < lantOrdonat.Count; k++)
                {
                    lantOrdonatOriginale.Add(varfuriPoligonCurent[lantOrdonat[k]]);
                }
                List<int> lantB = new List<int>();
                for (int f = 0; f < lantOrdonat.Count; f++)
                {
                    lantB.Add(lantOrdonat[f]);
                }
                lantA.Add(lantB[0]);
                int p = lantB[0];
                p++;
                int ultimulPunct = lantB[lantB.Count - 1];
                while (p != ultimulPunct)
                {
                    if (p == lantOrdonat.Count)
                        p = 0;
                    lantA.Add(p);
                    lantB.Remove(p);
                    p++;
                }
                lantA.Add(ultimulPunct);

                List<int> stivaVf = new List<int>();

                stivaVf.Add(lantOrdonat[0]);
                stivaVf.Add(lantOrdonat[1]);


                int ultimulVarfSters = 0;
                for (int l = 2; l < lantOrdonat.Count - 1; l++)
                {
                    if (lantA.Contains(lantOrdonat[l]) && lantB.Contains(lantOrdonat[stivaVf.Count - 1])
                        || lantB.Contains(lantOrdonat[l]) && lantA.Contains(lantOrdonat[stivaVf.Count - 1]))
                    {
                        for (int n = 0; n < stivaVf.Count; n++)
                        {
                            if (IsDiagonal(punctePoligonCurent, lantOrdonat[l], lantOrdonat[n]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[l], lantOrdonat[n]))
                            {
                                g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[l]], punctePoligonCurent[lantOrdonat[n]]);
                                diagonale.Add(new Tuple<int, int>(lantOrdonat[l], lantOrdonat[n]));
                            }
                        }
                        stivaVf.Clear();
                        stivaVf.Add(lantOrdonat[l]);
                        stivaVf.Add(lantOrdonat[l - 1]);
                    }
                    else
                    {
                        ultimulVarfSters = stivaVf[stivaVf.Count - 1];
                        stivaVf.RemoveAt(stivaVf.Count - 1);
                        List<int> toRemove = new List<int>();
                        for (int n = 0; n < stivaVf.Count; n++)
                        {
                            if (IsDiagonal(punctePoligonCurent, lantOrdonat[l], lantOrdonat[n]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[l], lantOrdonat[n]))
                            {
                                g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[l]], punctePoligonCurent[lantOrdonat[n]]);
                                diagonale.Add(new Tuple<int, int>(lantOrdonat[l], lantOrdonat[n]));
                                ultimulVarfSters = stivaVf[n];
                                toRemove.Add(lantOrdonat[n]);
                            }
                        }
                        for (int n = 0; n < toRemove.Count; n++)
                        {
                            stivaVf.Remove(toRemove[n]);
                        }
                        stivaVf.Add(ultimulVarfSters);
                        stivaVf.Add(lantOrdonat[l]);
                    }
                }
                while (stivaVf.Count > 1)
                {
                    if (IsDiagonal(punctePoligonCurent, lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]) && !intersecteazaAlteDiagonale(punctePoligonCurent, diagonale, lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]))
                    {
                        g.DrawLine(penTriang, punctePoligonCurent[lantOrdonat[lantOrdonat.Count - 1]], punctePoligonCurent[lantOrdonat[stivaVf.Count - 1]]);
                        diagonale.Add(new Tuple<int, int>(lantOrdonat[lantOrdonat.Count - 1], lantOrdonat[stivaVf.Count - 1]));
                    }
                    stivaVf.RemoveAt(stivaVf.Count - 1);
                }
            }
        }

        public List<int> OrdonareLexicografica(List<Point> laturi)
        {
            List<int> ordonat = new List<int>(); ;
            for (int i = 0; i < laturi.Count; i++)
            {
                ordonat.Add(i);
            }
            for (int i = 0; i < laturi.Count - 1; i++)
                for (int j = i + 1; j < laturi.Count; j++)
                {
                    if (laturi[ordonat[i]].Y > laturi[ordonat[j]].Y)
                    {
                        int aux = ordonat[i];
                        ordonat[i] = ordonat[j];
                        ordonat[j] = aux;
                    }
                    else
                        if (laturi[ordonat[i]].Y == laturi[ordonat[j]].Y)
                        if (laturi[ordonat[i]].X > laturi[ordonat[j]].X)
                        {
                            int aux = ordonat[i];
                            ordonat[i] = ordonat[j];
                            ordonat[j] = aux;
                        }
                }

            return ordonat;
        }
    }
}