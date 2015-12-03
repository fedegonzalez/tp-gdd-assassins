using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class modifAeronaves : Form
    {
        public modifAeronaves()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            monthCalendar1.Visible = false;
        }

        private void modifAeronaves_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string idText
        {
            get
            {
                return this.textBox2.Text;
            }
            set
            {
                this.textBox2.Text = value;
            }
        }
    }
}
