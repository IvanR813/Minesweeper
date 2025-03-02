using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int sirinap, duzinap;
        int brojmina;
        readonly Timer timer;
        Form2 drugaForma;
        Kraj_igre kraj_igre_forma;
        string vrstabombe;
        bool pozicijaToolTip = false;
        string ime;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Minesweeper";
            this.BackColor = Color.LightBlue;
            radioButton1.Checked = true;
            button1.Text = "Zapocni igru";
            timer = new Timer();
            timer.Interval = 1000;
            trackBar1.Value = 30;
            label6.Text = trackBar1.Value.ToString();
            label7.Text = "25";
            label8.Text = "40";
            label9.Text = "Velicina polja:";
            numericUpDown1.Minimum = 8;
            numericUpDown2.Minimum = 8;
            numericUpDown3.Minimum = 1;
            numericUpDown1.Value = 10;
            numericUpDown2.Value = 10;
            numericUpDown3.Value = 10;
            numericUpDown1.Maximum = 100;
            numericUpDown2.Maximum = 100;
            numericUpDown3.Maximum = 5000;
            checkBox1.Text = "Prikaz pozicija";
            comboBox1.Items.Add("Lako");
            comboBox1.Items.Add("Srednje");
            comboBox1.Items.Add("Tesko");
            comboBox1.Items.Add("Prilagodjeno");
            comboBox1.SelectedIndex = 0;
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar1.Value.ToString();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Refresh();
            Provera_vrednosti();
            duzinap = (int)numericUpDown1.Value;
            sirinap = (int)numericUpDown2.Value;
            brojmina = (int)numericUpDown3.Value;
            if (radioButton1.Checked)
                vrstabombe = "mina";
            else if (radioButton2.Checked)
                vrstabombe = "cvet";
            int brojpolja = sirinap * duzinap;
            if(textBox1.Text == "")
            {
                ime = "Valter";
            }
            else
            ime = textBox1.Text;
            if (checkBox1.Checked)
            {
                pozicijaToolTip = true;
            }
            else
                pozicijaToolTip = false;
            if (brojmina >= brojpolja)
            {
                MessageBox.Show("Broj mina mora biti manji od ukupnog broja polja! Ponovo unesite podatke!");
                return;
            }
            else
            {
                drugaForma?.Close();
                drugaForma = new Form2(trackBar1.Value, (int)numericUpDown2.Value, (int)numericUpDown1.Value,
                                  (int)numericUpDown3.Value, radioButton1.Checked ? "mina" : "cvet",
                                  checkBox1.Checked, string.IsNullOrEmpty(textBox1.Text) ? "Valter" : textBox1.Text, this);
                kraj_igre_forma = new Kraj_igre(this, drugaForma);
                drugaForma.Show();
            }
        }
        public void RestartGame()
        {
            drugaForma?.Close();
            drugaForma = new Form2(trackBar1.Value, (int)numericUpDown2.Value, (int)numericUpDown1.Value,
                              (int)numericUpDown3.Value, radioButton1.Checked ? "mina" : "cvet",
                              checkBox1.Checked, string.IsNullOrEmpty(textBox1.Text) ? "Valter" : textBox1.Text, this);
            kraj_igre_forma = new Kraj_igre(this, drugaForma);
            drugaForma.Show();
        }
        public void Restartuj(Form2 forma2)
        {
            forma2?.Restartovano();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (comboBox1.SelectedIndex == 0)
            {
                sirinap = 9;
                duzinap = 9;
                brojmina = 10;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                sirinap = 16;
                duzinap = 16;
                brojmina = 40;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                sirinap = 16;
                duzinap = 30;
                brojmina = 99;
            }
            else
                button2.Enabled = false;
            numericUpDown1.Value = duzinap;
            numericUpDown2.Value = sirinap;
            numericUpDown3.Value = brojmina;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Provera_vrednosti();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Provera_vrednosti();
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Provera_vrednosti();
        }
        private void Provera_vrednosti()
        {
            if (numericUpDown2.Value == 9 && numericUpDown1.Value == 9 && numericUpDown3.Value == 10)
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (numericUpDown2.Value == 16 && numericUpDown1.Value == 16 && numericUpDown3.Value == 40)
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (numericUpDown2.Value == 16 && numericUpDown1.Value == 30 && numericUpDown3.Value == 99)
            {
                comboBox1.SelectedIndex = 2;
            }
            else
            {
                if(comboBox1.Items.Count != 0)
                {
                    comboBox1.SelectedIndex = 3;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Rezultati rezultati = new Rezultati();
            if (comboBox1.SelectedIndex == 0)
                rezultati.Prikazi("lako");
            else if (comboBox1.SelectedIndex == 1)
                rezultati.Prikazi("srednje");
            else if (comboBox1.SelectedIndex == 2)
                rezultati.Prikazi("tesko");
            else
            {
                //MessageBox.Show("Ne postoje rezultati za prilagodjenu igru.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
