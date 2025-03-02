using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Zadnja_ploca : Oblik
    {
        public Zadnja_ploca(int x, int y, int a, int b)
            : base(x, y, a, b)
        {
        }
        public override void Crtaj(System.Drawing.Graphics g)
        {
            Pen olovka = new Pen(Color.Black, 2);
            SolidBrush cetka = new SolidBrush(Color.Gray);
            g.FillRectangle(cetka, x - 5, y - 5, a + 15, b + 15);
            g.DrawRectangle(olovka, x - 5, y - 5, a + 15, b + 15);
        }
    }
}
