using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class generacionViaje : Form
    {
        public generacionViaje()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendarFS.Visible = true;
            monthCalendarFLE.Visible = false;
            monthCalendarFL.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendarFL.Visible = true;
            monthCalendarFLE.Visible = false;
            monthCalendarFS.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = true;
            monthCalendarFS.Visible = false;
            monthCalendarFL.Visible = false;
        }

        private void monthCalendarFS_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendarFS.SelectionRange.Start.Date.ToShortDateString();
        }

        private void monthCalendarFL_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendarFL.SelectionRange.Start.Date.ToShortDateString();
        }

        private void monthCalendarFLE_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendarFLE.SelectionRange.Start.Date.ToShortDateString();
        }

        private void generacionViaje_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFL.Visible = false;
            monthCalendarFS.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFL.Visible = false;
            monthCalendarFS.Visible = false;
        }

    }
}
