using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp4
{
    class Cvet : Oblik
    {
        public Cvet(int x, int y, int a, int b)
            : base(x, y, a, b)
        {
        }
        public override void Crtaj(Graphics g)
        {
            Color bojazasredinucvetova = Color.Green;
            Color bojazaljubicicu = Color.FromArgb(150, Color.Red);
            SolidBrush cetka = new SolidBrush(Color.Violet);
            Pen olovka = new Pen(Color.FromArgb(255, Color.DarkBlue), 2);
            Pen olovka1 = new Pen(Color.GreenYellow, 1);
            Point[] p9 = new Point[8];
            p9[0] = new Point(x, y - a / 4);
            p9[1] = new Point(x + a / 2 - a / 8, y + a / 4 + a / 16);
            p9[2] = new Point(x + a / 2, y + a / 2 + a / 4 + a / 16);
            p9[3] = new Point(x + a / 4, y + a);
            p9[4] = new Point(x, y + a + a / 8 + a / 32);
            p9[5] = new Point(x - a / 4, y + a);
            p9[6] = new Point(x - a / 2, y + a / 2 + a / 4);
            p9[7] = new Point(x - a / 2 + a / 8, y + a / 4);
            g.FillClosedCurve(cetka, p9);
            GraphicsPath path = new GraphicsPath();
            path.AddClosedCurve(p9);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
            {
                CenterPoint = new PointF(x, y),
                CenterColor = Color.MediumPurple
            };
            Color[] colors = { Color.FromArgb(255, Color.DarkViolet) };
            Color[] colors1 = { Color.GreenYellow };

            path.AddClosedCurve(p9);

            pthGrBrush.CenterPoint = new PointF(x, y);
            pthGrBrush.CenterColor = bojazaljubicicu;
            pthGrBrush.SurroundColors = colors;
            g.FillClosedCurve(pthGrBrush, p9);

            g.DrawClosedCurve(olovka, p9);
            Color bojazaljubicicucrna = Color.FromArgb(35, Color.Black);
            SolidBrush crnacetka = new SolidBrush(bojazaljubicicucrna);
            p9[1] = new Point(x + a / 2 - a / 4 - a / 2, y + a / 4 + a / 16);
            p9[2] = new Point(x - a / 4, y + a / 2 + a / 4);
            p9[3] = new Point(x + a / 8, y + a);
            g.FillClosedCurve(crnacetka, p9);
            p9[1] = new Point(x + a / 2 - a / 8, y + a / 4 + a / 16);
            p9[2] = new Point(x + a / 2, y + a / 2 + a / 4 + a / 16);
            p9[3] = new Point(x + a / 4, y + a);
            p9[4] = new Point(x, y + a + a / 8 - a / 16);
            p9[5] = new Point(x + a / 4 + a / 16, y + a - a / 4);
            p9[6] = new Point(x + a / 4 + a / 16, y + a / 2 + a / 8);
            p9[7] = new Point(x + a / 8 + a / 16, y + a / 4 + a / 16);
            g.FillClosedCurve(crnacetka, p9);
            Point[] p10 = new Point[8];
            p10[0] = new Point(x, y - a / 4);
            p10[1] = new Point(x + a - a / 8, y - a / 2 + a / 8);
            p10[2] = new Point(x + a + a / 8 + a / 16, y - a / 16);
            p10[3] = new Point(x + a + a / 4, y);
            p10[4] = new Point(x + a + a / 4, y + a / 16);
            p10[5] = new Point(x + a / 2 + a / 4 + a / 8, y + a / 2);
            p10[6] = new Point(x + a / 4, y + a / 4 + a / 16);
            p10[7] = new Point(x + a / 8, y + a / 8 + a / 16);
            g.FillClosedCurve(cetka, p10);
            path = new GraphicsPath();
            path.AddClosedCurve(p10);
            pthGrBrush = new PathGradientBrush(path)
            {
                CenterPoint = new PointF(x, y),
                CenterColor = bojazaljubicicu,
                SurroundColors = colors
            };
            g.FillClosedCurve(pthGrBrush, p10);
            g.DrawClosedCurve(olovka, p10);
            p10[5] = new Point(x + a / 2 + a / 4 + a / 8 + a / 4, y + a / 4 + a / 8 + a / 8 + a / 16 - a / 2);
            p10[6] = new Point(x + a / 2 + a / 4, y + a / 4 + a / 16 - a / 2);
            p10[7] = new Point(x + a / 8, y + a / 8);
            g.FillClosedCurve(crnacetka, p10);
            Point[] p11 = new Point[8];
            p11[0] = new Point(x, y - a / 4);
            p11[1] = new Point(x - a + a / 8, y - a / 2 + a / 8);
            p11[2] = new Point(x - a - a / 8 - a / 16, y - a / 16);
            p11[3] = new Point(x - a - a / 4, y);
            p11[4] = new Point(x - a - a / 8 - a / 8, y + a / 16);
            p11[5] = new Point(x - a / 2 - a / 4 - a / 8, y + a / 2);
            p11[6] = new Point(x - a / 4, y + a / 4 + a / 16);
            p11[7] = new Point(x - a / 8, y + a / 8 + a / 16);
            g.FillClosedCurve(cetka, p11);
            path = new GraphicsPath();
            path.AddClosedCurve(p11);
            pthGrBrush = new PathGradientBrush(path)
            {
                CenterPoint = new PointF(x, y),
                CenterColor = bojazaljubicicu,
                SurroundColors = colors
            };
            g.FillClosedCurve(pthGrBrush, p11);
            g.DrawClosedCurve(olovka, p11);
            p11[5] = new Point(x - a / 2 - a / 4 - a / 8 - a / 4, y + a / 4 + a / 8 + a / 8 + a / 16 - a / 2);
            p11[6] = new Point(x - a / 2 - a / 4, y + a / 4 + a / 16 - a / 2);
            p11[7] = new Point(x - a / 8, y + a / 8);
            g.FillClosedCurve(crnacetka, p11);
            Point[] p12 = new Point[7];
            p12[0] = new Point(x, y - a / 4);
            p12[1] = new Point(x + a / 2 + a / 4, y - a / 4 - a / 16 - a / 8);
            p12[2] = new Point(x + a, y - a / 2 - a / 8 - a / 16);
            p12[3] = new Point(x + a - a / 16, y - a / 2 - a / 4 - a / 8 - a / 8);
            p12[4] = new Point(x + a - a / 4, y - a - a / 8 - a / 8);
            p12[5] = new Point(x + a / 2 - a / 8, y - 3 * a / 4 - a / 4 - a / 8 - a / 32);
            p12[6] = new Point(x + a / 16, y - a);
            g.FillClosedCurve(cetka, p12);
            path = new GraphicsPath();
            path.AddClosedCurve(p12);
            pthGrBrush = new PathGradientBrush(path)
            {
                CenterPoint = new PointF(x, y - a / 8),
                CenterColor = bojazaljubicicu,
                SurroundColors = colors
            };
            g.FillClosedCurve(pthGrBrush, p12);
            g.DrawClosedCurve(olovka, p12);
            p12[1] = new Point(x + a / 2 - a / 8, y - a / 4 - a / 16 - a / 8 - a / 2);
            p12[2] = new Point(x + a - a / 8, y - a / 2 - a / 8 - a / 16 - a / 4 - a / 8);
            g.FillClosedCurve(crnacetka, p12);
            Point[] p13 = new Point[7];
            p13[0] = new Point(x, y - a / 4);
            p13[1] = new Point(x - a / 2 - a / 4, y - a / 4 - a / 16 - a / 8);
            p13[2] = new Point(x - a, y - a / 2 - a / 8 - a / 16);
            p13[3] = new Point(x - a + a / 16, y - a / 2 - a / 4 - a / 8 - a / 4);
            p13[4] = new Point(x - a + a / 4 - a / 8, y - a - a / 8);
            p13[5] = new Point(x - a / 2, y - 3 * a / 4 - a / 4 - a / 8 - a / 16);
            p13[6] = new Point(x - a / 16, y - a);
            g.FillClosedCurve(cetka, p13);
            path = new GraphicsPath();
            path.AddClosedCurve(p13);
            pthGrBrush = new PathGradientBrush(path)
            {
                CenterPoint = new PointF(x, y - a / 8),
                CenterColor = bojazaljubicicu,
                SurroundColors = colors
            };
            g.FillClosedCurve(pthGrBrush, p13);
            g.DrawClosedCurve(olovka, p13);
            p13[1] = new Point(x - a / 2 + a / 8, y - a / 4 - a / 16 - a / 8 - a / 2);
            p13[2] = new Point(x - a + a / 8, y - a / 2 - a / 8 - a / 16 - a / 4 - a / 8);
            g.FillClosedCurve(crnacetka, p13);
            Point[] p14 = new Point[6];
            p14[0] = new Point(x, y - a / 4 - a / 8);
            p14[1] = new Point(x + a / 8 + a / 16, y - a / 8 - a / 16);
            p14[2] = new Point(x + a / 8 + a / 16, y + a / 8 + a / 16);
            p14[3] = new Point(x, y + a / 4 + a / 8);
            p14[4] = new Point(x - a / 8 - a / 16, y + a / 8 + a / 16);
            p14[5] = new Point(x - a / 8 - a / 16, y - a / 8 - a / 16);
            cetka.Color = Color.LightGray;
            g.FillPolygon(cetka, p14);
            path = new GraphicsPath();
            path.AddClosedCurve(p14);
            pthGrBrush = new PathGradientBrush(path)
            {
                CenterColor = bojazasredinucvetova,
                SurroundColors = colors1
            };
            g.FillClosedCurve(pthGrBrush, p14);
            g.DrawPolygon(olovka1, p14);
        }
        public void Nagazen_cvet(Graphics g, int velicina)
        {
            SolidBrush cetka = new SolidBrush(Color.MediumVioletRed);
            g.FillRectangle(cetka, x - velicina / 2, y - velicina / 2, velicina, velicina);
        }
    }
}
