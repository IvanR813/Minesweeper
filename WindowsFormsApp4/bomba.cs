using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Bomba : Oblik
    {
        public Bomba(int x, int y, int a, int b)
            : base(x, y, a, b)
        {
        }
        public override void Crtaj(System.Drawing.Graphics g)
        {
            Pen olovka = new Pen(Color.Black, 2);
            SolidBrush cetka = new SolidBrush(Color.Black);
            g.FillEllipse(cetka, x - a / 2, y - a / 2, a, a);
            g.DrawLine(olovka, x - a, y - a, x + a, y + a);
            g.DrawLine(olovka, x - a, y + a, x + a, y - a);
            g.DrawLine(olovka, x - a, y, x + a, y);
            g.DrawLine(olovka, x, y - a, x, y + a);
        }
        public void Nagazena_mina(Graphics g, int velicina)
        {
            SolidBrush cetka = new SolidBrush(Color.Red);
            g.FillRectangle(cetka, x - velicina / 2, y - velicina / 2, velicina, velicina);
        }
    }
}
