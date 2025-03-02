using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Zvezda:Oblik
    {
        public Zvezda(int x, int y, int a, int b)
           : base(x, y, a, b)
        {
        }
        public override void Crtaj(System.Drawing.Graphics g)
        {
            a += a/10;
            Pen olovka = new Pen(Color.Black, 1);
            SolidBrush cetka = new SolidBrush(Color.Yellow);
            Point[] p = new Point[10];
            p[0] = new Point(x, y - 3 * a / 8);
            p[1] = new Point(x + a / 8, y - a / 6);
            p[2] = new Point(x + 5 * a / 16, y - a / 8);
            p[3] = new Point(x + a / 8, y + a / 12);
            p[4] = new Point(x + 2 * a / 9, y + 5 * a / 16);
            p[5] = new Point(x, y + 3 * a / 16);
            p[6] = new Point(x - 2 * a / 9, y + 5 * a / 16);
            p[7] = new Point(x - a / 8, y + a / 12);
            p[8] = new Point(x - 5 * a / 16, y - a / 8);
            p[9] = new Point(x - a / 8, y - a / 6);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x, y - 3 * a / 8, x + a / 8, y - a / 6);
            path.AddLine(x + a / 8, y - a / 6, x + 5 * a / 16, y - a / 8);
            path.AddLine(x + 5 * a / 16, y - a / 8, x + 2 * a / 11, y + a / 12);
            path.AddLine(x + 2*a / 11, y + a / 12, x + 2 * a / 9, y + 5 * a / 16);
            path.AddLine(x + 2 * a / 9, y + 5 * a / 16, x, y + 7 * a / 32);
            path.AddLine(x, y + 7 * a / 32, x - 2 * a / 9, y + 5 * a / 16);
            path.AddLine(x - 2 * a / 9, y + 5 * a / 16, x - 2 * a / 11, y + a / 12);
            path.AddLine(x - 2 * a / 11, y + a / 12, x - 5 * a / 16, y - a / 8);
            path.AddLine(x - 5 * a / 16, y - a / 8, x - a / 8, y - a / 6);
            path.AddLine(x - a / 8, y - a / 6, x, y - 3 * a / 8);
            g.FillPath(cetka, path);
            g.DrawPath(olovka, path);
        }
    }
}
