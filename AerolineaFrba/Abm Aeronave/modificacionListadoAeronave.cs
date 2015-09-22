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
    public partial class modificacionListadoAeronave : Form
    {
        public modificacionListadoAeronave()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Aeronave.modifAeronaves abrir = new Abm_Aeronave.modifAeronaves();
            abrir.Show();
        }
    }
}
