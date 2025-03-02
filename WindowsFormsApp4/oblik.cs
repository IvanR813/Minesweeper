using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public abstract class Oblik
    {
        public int x, y, a, b;
        public Oblik(int x, int y, int a, int b)
        {
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }
        public abstract void Crtaj(Graphics g);
    }
}
