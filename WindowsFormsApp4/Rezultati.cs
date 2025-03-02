using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class Rezultati
    {
        public void Sacuvaj(string ime, int vreme, string tezina)
        {
            string fajl = tezina;
            List<(string ime, int vreme)> rezultati = Ucitaj(fajl);
            rezultati.Add((ime, vreme));
            rezultati = rezultati.OrderBy(r => r.vreme).Take(10).ToList();
            using (StreamWriter sw = new StreamWriter(fajl))
            {
                foreach (var rezultat in rezultati)
                {
                    sw.WriteLine($"{rezultat.ime} {rezultat.vreme}");
                }
            }
        }
        private List<(string ime, int vreme)> Ucitaj(string fajl)
        {
            var rezultati = new List<(string, int)>();
            if (!File.Exists(fajl)) return rezultati;
            using (StreamReader sr = new StreamReader(fajl))
            {
                string red;
                while ((red = sr.ReadLine()) != null)
                {
                    var delovi = red.Split(' ');
                    if (delovi.Length == 2)
                    {
                        rezultati.Add((delovi[0], int.Parse(delovi[1])));
                    }
                }
            }
            return rezultati;
        }
        private string Putanja(string tezina)
        {
            return tezina;
        }
        public void Prikazi(string tezina)
        {
            string fajl = Putanja(tezina);
            if(!File.Exists(fajl))
            {
                MessageBox.Show("Nema rezultata za izabrani nivo.", "Rezultati");
                return;
            }
            using (StreamReader sr = new StreamReader(fajl))
            {
                string rezultati = sr.ReadToEnd();
                MessageBox.Show(rezultati, $"Rezultati - {tezina}");
            }
        }
    }
}
