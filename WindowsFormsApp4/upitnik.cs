using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Upitnik : Oblik
    {
        public Upitnik(int x, int y, int a, int b)
           : base(x, y, a, b)
        {
        }
        public override void Crtaj(Graphics g)
        {
            Pen olovka = new Pen(Color.Black, a / 10);
            SolidBrush cetka = new SolidBrush(Color.Black);
            g.FillEllipse(cetka, x, y + 5 * a / 16, a / 6, a / 6);
            Point[] p = new Point[4];
            p[0] = new Point(x + a / 12, y + a / 4);
            p[1] = new Point(x + a / 12, y + a / 8);
            p[2] = new Point(x + a / 2, y - 4 * a / 16);
            p[3] = new Point(x - a / 8, y - a / 12);
            g.DrawBezier(olovka, p[0], p[1], p[2], p[3]);
        }
    }
}
