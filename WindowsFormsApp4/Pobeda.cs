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
    public partial class Pobeda : Form
    {
        private Form1 parentForm;
        public Pobeda(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void Pobeda_Load(object sender, EventArgs e)
        {
            label1.Text = "Pobedio si!";
            button1.Text = "Zapocni novu igru";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.RestartGame();
            this.Close();
        }
    }
}
