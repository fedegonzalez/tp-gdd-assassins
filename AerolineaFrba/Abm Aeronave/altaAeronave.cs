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
    public partial class altaAeronave : Form
    {
        public altaAeronave()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        string query;

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ejecutar(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void ejecutar(string query)
        {

        }

        private void altaAeronave_Load(object sender, EventArgs e)
        {

        }
    }
}
