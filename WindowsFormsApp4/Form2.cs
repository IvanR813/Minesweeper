using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        private int x;
        private int y;
        private int b;
        public readonly int sirinap;
        public readonly int duzinap;
        Zadnja_ploca zp;
        Graphics g;
        bool[,] matrica;
        bool[,] imabroj;
        Cvet[,] cv;
        Polja[,] po;
        Bomba[,] bo;
        Zvezda[,] zv;
        Zastavica[,] za;
        Upitnik[,] up;
        int brojmina;
        int pobeda_brojac;
        bool[,] otvaranje;
        Random r = new Random();
        List<Polja> polja = new List<Polja>();
        List<Cvet> cvece = new List<Cvet>();
        List<Bomba> bomba = new List<Bomba>();
        List<Polja> bez_mina_okolo = new List<Polja>();
        List<Zvezda> zvezda = new List<Zvezda>();
        bool kliknuto;
        bool poraz = false;
        int vreme;
        Timer timer;
        int velicina;
        int trackbar;
        string vrstabombe = "";
        readonly int maxduzina = Screen.PrimaryScreen.WorkingArea.Width;
        readonly int maxsirina = Screen.PrimaryScreen.WorkingArea.Height;
        int sirinaodmape = 150;
        int duzinaodmape = 27;
        bool nacrtano = false;
        int zastavice_brojac;
        private ToolTip toolTip = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();
        bool prikaziToolTip;
        Smajli sm;
        string ime;
        Form1 prvaForma;
        Kraj_igre kraj_igre_forma;
        bool prva_igra = true;
        Pobeda pobeda;
        public Form2(int track, int sirina, int duzina, int brojminaf1, string vrstabombe, bool toolTip, string ime, Form1 prvaForma)
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            trackbar = track;
            sirinap = sirina;
            duzinap = duzina;
            sirinaodmape += sirinap * track;
            duzinaodmape += duzinap * track;
            if (sirinaodmape > maxsirina)
            {
                sirinaodmape = 150;
                sirinap = 0;
                while ((sirinaodmape += track) < maxsirina)
                {
                    sirinap++;
                }
                MessageBox.Show("Nije bilo moguce postaviti toliko redova na vasem ekranu. Ako je moguce, pokusajte smanjiti velicinu polja, ako ne, smanjite broj redova. Broj redova je umanjen na najveci moguci i sada iznosi " + sirinap.ToString());
            }
            if (duzinaodmape > maxduzina)
            {
                duzinaodmape = 27;
                duzinap = 0;
                while ((duzinaodmape += track) < maxduzina)
                {
                    duzinap++;
                }
                MessageBox.Show("Nije bilo moguce postaviti toliko kolona na vasem ekranu. Ako je moguce, pokusajte smanjiti velicinu polja, ako ne, smanjite broj kolona. Broj kolona je umanjen na najveci moguci i sada iznosi " + duzinap.ToString());
            }
            this.Size = new System.Drawing.Size(duzinaodmape, sirinaodmape);
            this.BackColor = Color.LightBlue;
            timer = new Timer();
            timer.Interval = 1000;
            brojmina = brojminaf1;
            if (sirinap * duzinap < brojmina)
            {
                MessageBox.Show("Broj mina je umanjen sa " + brojmina + " na " + (sirinap * duzinap - 1) + " jer je to najveci moguci broj mina.");
                brojmina = sirinap * duzinap - 1;
            }

            this.vrstabombe = vrstabombe;
            label1.Text = "Vreme";
            timer1.Interval = 1000;
            label2.Text = "0";
            label3.Text = "Zastavice";
            label1.Location = new Point(duzinaodmape / 4 - 20, 20);
            label2.Location = new Point(duzinaodmape / 4 - 20, 40);
            label3.Location = new Point(3 * duzinaodmape / 4 - 20, 20);
            label4.Location = new Point(3 * duzinaodmape / 4 - 20, 40);
            this.MouseMove += Form2_MouseMove;
            prikaziToolTip = toolTip;
            sm = new Smajli(duzinaodmape / 2 - 35, 20, 50, 50);
            this.ime = ime;
            this.Text = ime + " brani Sarajevo";
            this.prvaForma = prvaForma;
            kraj_igre_forma = new Kraj_igre(prvaForma, this);
            pobeda = new Pobeda(prvaForma);
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (nacrtano == false)
            {
                sm.Crtaj(g);
                x = 0;
                y = 100;
                zp = new Zadnja_ploca(x, y, duzinap * velicina, sirinap * velicina);
                zp.Crtaj(g);
                x = 5;
                y = 105;
                for (int i = 0; i < sirinap; i++)
                {
                    x = 5;
                    for (int j = 0; j < duzinap; j++)
                    {
                        if (matrica[i, j])
                        {
                            po[i, j] = new Polja(x, y, velicina, b, 0, true);
                        }
                        else po[i, j] = new Polja(x, y, velicina, b, 0, false);
                        po[i, j].Crtaj(g);
                        po[i, j].Okvir(g);
                        polja.Add(po[i, j]);
                        x += velicina;
                    }
                    y += velicina;
                }
            }
            nacrtano = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            vreme++;
            label2.Text = vreme.ToString();
        }

        private int Broj_oko(int i, int j)
        {
            if (i < 0 || j < 0 || i >= sirinap || j >= duzinap)
            { return 0; }
            if (po[i, j].oko != 0)
                return po[i, j].oko;
            if (i != 0 && j != 0)
                if (matrica[i - 1, j - 1])
                    po[i, j].oko++;
            if (i != 0)
                if (matrica[i - 1, j])
                    po[i, j].oko++;
            if (i != 0 && j != duzinap - 1)
                if (matrica[i - 1, j + 1])
                    po[i, j].oko++;
            if (j != 0)
                if (matrica[i, j - 1])
                    po[i, j].oko++;
            if (j != duzinap - 1)
                if (matrica[i, j + 1])
                    po[i, j].oko++;
            if (i != sirinap - 1 && j != 0)
                if (matrica[i + 1, j - 1])
                    po[i, j].oko++;
            if (i != sirinap - 1)
                if (matrica[i + 1, j])
                    po[i, j].oko++;
            if (i != sirinap - 1 && j != duzinap - 1)
                if (matrica[i + 1, j + 1])
                    po[i, j].oko++;
            if (po[i, j].oko == 0)
            {
                po[i, j].oko = -1;
            }
            return po[i, j].oko;
        }
        private void Zameni(int i, int j)
        {
            cvece.Remove(cv[i, j]);
            bomba.Remove(bo[i, j]);
            zvezda.Remove(zv[i, j]);
            matrica[i, j] = false;
            x = 5;
            y = 105;
            while (true)
            {
                int rand = r.Next(sirinap * duzinap);
                int ni = rand % sirinap;
                int nj = rand / sirinap;

                if (!matrica[ni, nj] && (ni != i || nj != j))
                {
                    matrica[ni, nj] = true;
                    bo[ni, nj] = new Bomba(nj * velicina + x + velicina / 2, ni * velicina + y + velicina / 2, velicina / 3, b);
                    cv[ni, nj] = new Cvet(nj * velicina + x + velicina / 2, ni * velicina + y + velicina / 2, velicina / 3, b);
                    bomba.Add(bo[ni, nj]);
                    cvece.Add(cv[ni, nj]);
                    //MessageBox.Show("Mina je uspešno pomerena sa " + i + " " + j + " na " + ni + " " + nj);
                    return;
                }
            }
        }
        private void Pobeda()
        {
            if (pobeda_brojac == brojmina)
            {
                timer1.Stop();
                for (int i = 0; i < sirinap; i++)
                {
                    for (int j = 0; j < duzinap; j++)
                    {

                        if (zv[i, j] != null)
                        {
                            po[i, j].Crtaj(g);
                            zv[i, j].Crtaj(g);
                        }
                    }
                }
                for (int ii = 0; ii < sirinap; ii++)
                {
                    for (int jj = 0; jj < duzinap; jj++)
                    {
                        po[ii, jj].x = -100;
                        po[ii, jj].y = -100;
                    }
                }
                sm.Pobeda(g);
                if(prva_igra)
                {
                    Rezultati rezultati = new Rezultati();
                    if (duzinap == 9 && sirinap == 9 && brojmina == 10)
                        rezultati.Sacuvaj(ime, vreme, "lako");
                    else if (duzinap == 16 && sirinap == 16 && brojmina == 40)
                        rezultati.Sacuvaj(ime, vreme, "srednje");
                    else if (duzinap == 30 && sirinap == 16 && brojmina == 99)
                        rezultati.Sacuvaj(ime, vreme, "tesko");
                    //MessageBox.Show("Prva igra!");
                }
                //MessageBox.Show("Nije prva igra :(");
                pobeda.Show();
            }
        }
        private void Otvori_polje(int i, int j, Graphics g)
        {
            if (i < 0 || j < 0 || i >= sirinap || j >= duzinap || otvaranje[i, j])
            { return; }

            otvaranje[i, j] = true;
            if (Broj_oko(i, j) != -1 && !imabroj[i, j])
            {

                imabroj[i, j] = true;
                po[i, j].Crtaj(g);
                if (po[i, j].stanje == 1)
                {
                    zastavice_brojac++;
                    za[i, j] = null;
                    zv[i, j] = null;
                    label4.Text = zastavice_brojac.ToString();
                }
                Pobeda();
                pobeda_brojac--;
                return;
            }
            po[i, j].Crtaj(g);
            if (po[i, j].stanje == 1)
            {
                zv[i, j] = null;
                za[i,j] = null;
                zastavice_brojac++;
                label4.Text = zastavice_brojac.ToString();
            }
            Pobeda();
            if (po[i, j].oko > 0)
                return;
            pobeda_brojac--;
            for (int ii = -1; ii <= 1; ii++)
            {
                for (int jj = -1; jj <= 1; jj++)
                {
                    if (ii != 0 || jj != 0)
                    {
                        int ni = i + ii;
                        int nj = j + jj;
                        Otvori_polje(ni, nj, g);
                    }
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            x = 0;
            y = 0;
            b = 0;
            velicina = trackbar;
            kliknuto = false;
            poraz = false;
            vreme = 0;
            vreme = 0;
            bomba.Clear();
            cvece.Clear();
            polja.Clear();
            otvaranje = new bool[sirinap, duzinap];
            matrica = new bool[sirinap, duzinap];
            imabroj = new bool[sirinap, duzinap];
            int preostalo = brojmina;
            int brojpolja = sirinap * duzinap;
            zastavice_brojac = brojmina;
            label4.Text = zastavice_brojac.ToString();
            pobeda_brojac = brojpolja;
            if (brojmina >= brojpolja)
            {
                MessageBox.Show("Broj mina mora biti manji od ukupnog broja polja! Ponovo unesite podatke!");
                this.Close();
                return;
            }
            timer1.Start();
            cv = new Cvet[sirinap, duzinap];
            po = new Polja[sirinap, duzinap];
            bo = new Bomba[sirinap, duzinap];
            za = new Zastavica[sirinap, duzinap];
            zv = new Zvezda[sirinap, duzinap];
            up = new Upitnik[sirinap, duzinap];
            int proba_pozicija;
            x = 0;
            y = 0;
            zp = new Zadnja_ploca(x, y, duzinap * velicina, sirinap * velicina);
            zp.Crtaj(g);
            x = 105;
            y = 5;
            while (true)
            {
                proba_pozicija = r.Next(brojpolja);
                int j = proba_pozicija / sirinap;
                int i = proba_pozicija % sirinap;
                if (!matrica[i, j])
                {
                    matrica[i, j] = true;
                    preostalo--;
                    bo[i, j] = new Bomba(j * velicina + y + velicina / 2, i * velicina + x + velicina / 2, velicina / 3, b);
                    cv[i, j] = new Cvet(j * velicina + y + velicina / 2, i * velicina + x + velicina / 2, velicina / 3, b);
                    bomba.Add(bo[i, j]);
                    cvece.Add(cv[i, j]);
                }
                y = 5;
                if (preostalo == 0)
                    break;
            }
            for (int i = 0; i < sirinap; i++)
            {
                x = 5;
                for (int j = 0; j < duzinap; j++)
                {
                    if (matrica[i, j])
                    {
                        po[i, j] = new Polja(x, y, velicina, b, 0, true);
                    }
                    else po[i, j] = new Polja(x, y, velicina, b, 0, false);
                    po[i, j].Crtaj(g);
                    polja.Add(po[i, j]);
                    x += velicina;
                }
                y += velicina;
            }
        }

        public void Restartovano()
        {
            g = CreateGraphics();
            vreme = 0;
            timer1.Start();
            pobeda_brojac = sirinap * duzinap;
            prva_igra = false;
            otvaranje = new bool[sirinap, duzinap];
            imabroj = new bool[sirinap, duzinap];
            label2.Text = "0";
            y = 105;
            zp.Crtaj(g);
            zastavice_brojac = brojmina;
            label4.Text = zastavice_brojac.ToString();
            for (int i = 0; i < sirinap; i++)
            {
                x = 5;
                for (int j = 0; j < duzinap; j++)
                {
                    if (matrica[i, j])
                    {
                        po[i, j] = new Polja(x, y, velicina, b, 0, true);
                    }
                    else po[i, j] = new Polja(x, y, velicina, b, 0, false);
                    po[i, j].Crtaj(g);
                    po[i, j].Okvir(g);
                    polja.Add(po[i, j]);
                    x += velicina;
                }
                y += velicina;
            }
            sm.Crtaj(g);
        }
        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            bez_mina_okolo.Clear();
            int iks = e.X;
            int ips = e.Y;

            Graphics g = CreateGraphics();
            for (int i = 0; i < sirinap; i++)
            {
                for (int j = 0; j < duzinap; j++)
                {
                    if (iks > po[i, j].x && iks < po[i, j].x + velicina && ips > po[i, j].y && ips < po[i, j].y + velicina && e.Button == MouseButtons.Left && po[i, j].stanje == 0)
                    {
                        if (po[i, j].oko == 0)
                        {
                            if (!kliknuto && matrica[i, j])
                            {
                                if(prva_igra == true)
                                    Zameni(i, j);
                            }
                            if (matrica[i, j])
                            {
                                timer1.Stop();
                                for (int ii = 0; ii < sirinap; ii++)
                                {
                                    for (int jj = 0; jj < duzinap; jj++)
                                    {
                                        if (po[ii, jj].stanje != 0)
                                        {
                                            po[ii, jj].Crtaj(g);
                                        }
                                        po[ii, jj].x = -100;
                                        po[ii, jj].y = -100;
                                    }
                                }
                                if (vrstabombe.Equals("mina"))
                                {
                                    bo[i, j].Nagazena_mina(g, velicina);
                                    sm.Umro(g);
                                    bo[i, j].Crtaj(g);
                                    foreach (Bomba b in bomba)
                                    {
                                        b.Crtaj(g);
                                    }
                                    kraj_igre_forma.Show();
                                    poraz = true;
                                }
                                else if (vrstabombe.Equals("cvet"))
                                {
                                    cv[i, j].Nagazen_cvet(g, velicina);
                                    sm.Umro(g);
                                    cv[i, j].Crtaj(g);
                                    foreach (Cvet c in cvece)
                                    {
                                        c.Crtaj(g);
                                    }
                                    kraj_igre_forma.Show();
                                    kraj_igre_forma.OnCloseRequested += () =>
                                    {
                                        
                                    };
                                    poraz = true;
                                }
                            }
                            else
                            {
                                Broj_oko(i, j);
                                po[i, j].Crtaj(g);
                                if (!imabroj[i, j])
                                    pobeda_brojac--;
                                imabroj[i, j] = true;
                                Pobeda();
                            }
                            if (po[i, j].oko == -1)
                            {
                                pobeda_brojac++;
                                bez_mina_okolo.Add(po[i, j]);
                                Otvori_polje(i, j, g);
                                Pobeda();
                            }
                        }
                        kliknuto = true;
                    }
                    else if (iks > po[i, j].x && iks < po[i, j].x + velicina && ips > po[i, j].y && ips < po[i, j].y + velicina && e.Button == MouseButtons.Right)
                    {
                        po[i, j].stanje++;
                        if (!(imabroj[i, j] || otvaranje[i, j]))
                        {
                            if (po[i, j].stanje == 1)
                            {
                                zastavice_brojac--;
                                label4.Text = zastavice_brojac.ToString();
                                po[i, j].Pocetno_polje(g);
                                if (velicina < 30)
                                {
                                    za[i, j] = new Zastavica(j * velicina + 3 * velicina / 4, 100 + i * velicina + 3 * velicina / 4, velicina, b);
                                    zv[i, j] = new Zvezda(j * velicina + 3 * velicina / 4, 100 + i * velicina + 3 * velicina / 4, velicina, b);
                                
                                }
                                else
                                {
                                    za[i, j] = new Zastavica(j * velicina + 2 * velicina / 3, 100 + i * velicina + 2 * velicina / 3, velicina, b);
                                    if(velicina < 35)
                                        zv[i, j] = new Zvezda(j * velicina + 2 * velicina / 3, 100 + i * velicina + 2 * velicina / 3, velicina, b);
                                    else
                                        zv[i, j] = new Zvezda(j * velicina + 2 * velicina / 3 - 1, 100 + i * velicina + 2 * velicina / 3, velicina, b);
                                }
                                za[i, j].Crtaj(g);
                            }
                            else if (po[i, j].stanje == 2)
                            {
                                zastavice_brojac++;
                                za[i, j] = null;
                                zv[i, j] = null;
                                label4.Text = zastavice_brojac.ToString();
                                po[i, j].Pocetno_polje(g);
                                if (velicina < 30)
                                {
                                    up[i, j] = new Upitnik(j * velicina + 3 * velicina / 5, 100 + i * velicina + 3 * velicina / 5, velicina, b);
                                }
                                else
                                {
                                    up[i, j] = new Upitnik(j * velicina + 3 * velicina / 5, 100 + i * velicina + velicina / 2, velicina, b);
                                }
                                up[i, j].Crtaj(g);
                            }
                            else
                            {
                                po[i, j].Pocetno_polje(g);
                                po[i, j].stanje = 0;
                                up[i, j] = null;
                            }
                        }
                    }
                }
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= duzinaodmape / 2 - 35 && e.X < duzinaodmape / 2 - 35 + 50 && e.Y >= 20 && e.Y <= 70)
            {
                toolTip.SetToolTip(this, ime);
            }
            else
                toolTip.Hide(this);
            if(prikaziToolTip)
            {
                if (e.Y > 105)
                {
                    int kolona = 1 + (e.X - 5) / velicina;
                    int red = 1 + (e.Y - 105) / velicina;
                    if (kolona > duzinap)
                        kolona = duzinap;
                    if(red > sirinap)
                        red = sirinap;
                    toolTip2.SetToolTip(this, red.ToString() + " " + kolona.ToString());
                }
                else
                    toolTip2.Hide(this);
            }
        }
    }
}