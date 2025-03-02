using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Smajli : Oblik
    {
        public Smajli(int x, int y, int a, int b)
          : base(x, y, a, b)
        {
        }
        public override void Crtaj(Graphics g)
        {
            Pen olovka = new Pen(Color.Black, a / 25);
            SolidBrush cetka = new SolidBrush(Color.Yellow);
            SolidBrush crnaCetka = new SolidBrush(Color.Black);
            g.FillEllipse(cetka, x, y, a, a);
            g.DrawBezier(olovka, x + 12, y + 35, x + 21, y + 45, x + 29, y + 45, x + 38, y + 35);
            g.DrawEllipse(olovka, x, y, a, a);
            g.FillEllipse(crnaCetka, x + 12, y + 15, a / 6, a / 6);
            g.FillEllipse(crnaCetka, x + 31, y + 15, a / 6, a / 6);
        }
        public void Umro(Graphics g)
        {
            Pen olovka = new Pen(Color.Black, a / 25);
            SolidBrush cetka = new SolidBrush(Color.Yellow);
            g.FillEllipse(cetka, x, y, a, a);
            g.DrawBezier(olovka, x + 12, y + 40, x + 21, y + 30, x + 29, y + 30, x + 38, y + 40);
            g.DrawEllipse(olovka, x, y, a, a);
            g.DrawLine(olovka, x + 12, y + 15, x + 18, y + 21);
            g.DrawLine(olovka, x + 12, y + 21, x + 18, y + 15);
            g.DrawLine(olovka, x + 31, y + 15, x + 37, y + 21);
            g.DrawLine(olovka, x + 31, y + 21, x + 37, y + 15);
        }
        public void Pobeda(Graphics g)
        {
            Pen olovka = new Pen(Color.Black, a / 25);
            SolidBrush cetka = new SolidBrush(Color.Yellow);
            SolidBrush crnaCetka = new SolidBrush(Color.Black);
            g.FillEllipse(cetka, x, y, a, a);
            g.DrawBezier(olovka, x + 12, y + 35, x + 21, y + 45, x + 29, y + 45, x + 38, y + 35);
            g.DrawEllipse(olovka, x, y, a, a);
            g.FillEllipse(crnaCetka, x + 5, y + 12, 20, 12);
            g.FillEllipse(crnaCetka, x + 25, y + 12, 20, 12);
        }
    }
}
