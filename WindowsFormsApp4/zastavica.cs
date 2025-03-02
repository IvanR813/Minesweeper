using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Zastavica : Oblik
    {
        public Zastavica(int x, int y, int a, int b)
            : base(x, y, a, b)
        {
        }
        public override void Crtaj(Graphics g)
        {
            Pen olovkacrna = new Pen(Color.Black, a/10);
            SolidBrush cetkacrvena = new SolidBrush(Color.Red);
            g.DrawLine(olovkacrna, x, y - a / 6, x, y + a / 4);
            olovkacrna.Width = a / 8;
            g.DrawLine(olovkacrna, x - a / 6, y + a / 4, x + a / 6, y + a / 4);
            g.DrawLine(olovkacrna, x - a / 3, y + 5 * a / 16, x + a / 3, y + 5 * a / 16);
            olovkacrna.Width = a / 10;
            Point[] p = new Point[3];
            if(a <= 40)
            {
                p[0] = new Point(x + a / 15, y);
                p[1] = new Point(x + a / 15, y - 2 * a / 5);
            }
            else
            {
                p[0] = new Point(x + a / 20, y);
                p[1] = new Point(x + a / 20, y - 2 * a / 5);
            }
            p[2] = new Point(x - a / 3, y - a / 5);
            g.FillPolygon(cetkacrvena, p);
        }
    }
}