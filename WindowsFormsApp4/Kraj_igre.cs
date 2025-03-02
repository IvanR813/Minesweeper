using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Kraj_igre : Form
    {
        public event Action OnCloseRequested;
        private Form1 forma1;
        private Form2 forma2;
        public bool pobeda;
        public Kraj_igre(Form1 forma1, Form2 forma2)
        {
            InitializeComponent();
            label1.Text = "Izgubio si. Zelis li da Probas ponovo?";
            button1.Text = "Zapocni novu igru";
            button2.Text = "Restartuj trenutnu igru";
            button1.Click += button1_Click;
            this.Controls.Add(button1);
            this.forma1 = forma1;
            this.forma2 = forma2;
            label2.Text = "Rezultati se ne cuvaju";
            label3.Text = "za restartovanu igru";
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            forma1.RestartGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            forma2.Restartovano();
        }

        private void Kraj_igre_Load(object sender, EventArgs e)
        {

        }
    }
}
