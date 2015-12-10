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
    public partial class abmAeronave : Form
    {
        public abmAeronave()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAltaAero_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.altaAeronave abrir = new Abm_Aeronave.altaAeronave("","","","","",false,false);
            abrir.Show();
            this.Hide();
        }

        private void buttonBajaAero_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.modificacionListadoAeronave abrir = new Abm_Aeronave.modificacionListadoAeronave();
            abrir.Show();
            this.Hide();
        }

        private void buttonModificacionAero_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.modificacionListadoAeronave abrir = new Abm_Aeronave.modificacionListadoAeronave();
            abrir.Show();
            this.Hide();
        }

        private void abmAeronave_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.modificacionListadoAeronave abrir = new Abm_Aeronave.modificacionListadoAeronave();
            abrir.Show();
            this.Hide();
        }
    }
}
