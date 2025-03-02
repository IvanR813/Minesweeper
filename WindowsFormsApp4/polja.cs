using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Polja : Oblik
    {
        public int oko;
        public bool bomba;
        public int stanje;
        public Polja(int x, int y, int a, int b, int oko, bool bomba)
            : base(x, y, a, b)
        {
            this.oko = oko;
            this.bomba = bomba;
        }
        public void Pocetno_polje(Graphics g)
        {
            GraphicsPath put = new GraphicsPath();
            //put.AddLine(x, y, x + a, y);
            //put.AddLine(x + a, y, x + a, y + a);
            //put.AddLine(x + a, y + a, x, y + a);
            //put.AddLine(x, y + a, x, y);
            put.AddLine(x + a / 20, y + a / 20, x + a - a / 20, y + a / 20);
            put.AddLine(x + a - a / 20, y + a / 20, x + a - a / 20, y + a - a / 20);
            put.AddLine(x + a - a / 20, y + a - a / 20, x + a / 20, y + a - a / 20);
            put.AddLine(x + a / 20, y + a - a / 20, x + a / 20, y + a / 20);
            PathGradientBrush putcetka = new PathGradientBrush(put);
            putcetka.CenterColor = Color.LightGray;
            Color[] boje = { Color.Gray };
            putcetka.SurroundColors = boje;
            g.FillPath(putcetka, put);
            
        }
        public override void Crtaj(Graphics g)
        {
            Pen olovka2 = new Pen(Color.Orange, 1);
            SolidBrush sb = new SolidBrush(Color.Black);
            SolidBrush sb2 = new SolidBrush(Color.Yellow);
            Font f = new Font("Arial", 10);
            if (oko == 0)
            {
                Pocetno_polje(g);   
            }
            if (oko != 0)
            {
                g.FillRectangle(sb2, x, y, a, a);
                g.DrawRectangle(olovka2, x, y, a, a);
            }

            if (oko > 0)
            {
                g.DrawString(oko.ToString(), f, sb, x + a / 3, y + a / 3);
            }
        }
        public void Okvir(Graphics g)
        {
            Pen olovka = new Pen(Color.Black, 2);
            GraphicsPath put = new GraphicsPath();
            put.AddLine(x, y, x + a, y);
            put.AddLine(x + a, y, x + a, y + a);
            put.AddLine(x + a, y + a, x, y + a);
            put.AddLine(x, y + a, x, y);
            g.DrawPath(olovka, put);
        }
    }
}
