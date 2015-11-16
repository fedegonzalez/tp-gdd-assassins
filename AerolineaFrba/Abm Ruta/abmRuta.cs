using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class abmRuta : Form
    {
        public abmRuta()
        {
            InitializeComponent();
        }

        private void buttonAltaRut_Click(object sender, EventArgs e)
        {
            Abm_Ruta.altaRuta abrir = new Abm_Ruta.altaRuta();
            abrir.Show();
            this.Hide();
        }

        private void buttonBajaRut_Click(object sender, EventArgs e)
        {
            Abm_Ruta.modificacionListadoRuta abrir = new Abm_Ruta.modificacionListadoRuta();
            abrir.Show();
            this.Hide();
        }

        private void buttonModificacionRut_Click(object sender, EventArgs e)
        {
            Abm_Ruta.modificacionListadoRuta abrir = new Abm_Ruta.modificacionListadoRuta();
            abrir.Show();
            this.Hide();
        }

        private void abmRuta_Load(object sender, EventArgs e)
        {

        }
    }
}
