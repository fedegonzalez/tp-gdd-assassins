using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class abmCiudad : Form
    {
        public abmCiudad()
        {
            InitializeComponent();
        }

        private void abmCiudad_Load(object sender, EventArgs e)
        {

        }

        private void buttonAltaCiu_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.altaCiudad abrir = new Abm_Ciudad.altaCiudad ();
            abrir.Show();
            this.Hide();
        }

        private void buttonBajaCiu_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.bajaCiudad abrir = new Abm_Ciudad.bajaCiudad();
            abrir.Show();
            this.Hide();
        }

        private void buttonModificacionCiu_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.modificacionCiudad abrir = new Abm_Ciudad.modificacionCiudad();
            abrir.Show();
            this.Hide();
        }

    }
}
