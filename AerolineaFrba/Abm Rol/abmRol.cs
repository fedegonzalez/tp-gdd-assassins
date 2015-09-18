using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class abmRol : Form
    {
        public abmRol()
        {
            InitializeComponent();
        }

        private void buttonModificacionRol_Click(object sender, EventArgs e)
        {
            Abm_Rol.modificacionRol abrir = new Abm_Rol.modificacionRol();
            abrir.Show();
            this.Hide();
        }

        private void buttonAltaRol_Click(object sender, EventArgs e)
        {
            Abm_Rol.altaRol abrir = new Abm_Rol.altaRol();
            abrir.Show();
            this.Hide();
        }

        private void buttonBajaRol_Click(object sender, EventArgs e)
        {
            Abm_Rol.bajaRol abrir = new Abm_Rol.bajaRol();
            abrir.Show();
            this.Hide();
        }
    }
}
