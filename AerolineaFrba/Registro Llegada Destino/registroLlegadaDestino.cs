using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class registroLlegadaDestino : Form
    {
        public registroLlegadaDestino()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        private void registroLlegadaDestino_Load(object sender, EventArgs e)
        {

        }
    }
}
