using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class inicioCliente : Form
    {
        public inicioCliente()
        {
            InitializeComponent();
        }

        private void buttonCompra_Click(object sender, EventArgs e)
        {
            Compra.compra abrirCliente = new Compra.compra(true);
            abrirCliente.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta_Millas.consultaMillas abrirCliente = new Consulta_Millas.consultaMillas();
            abrirCliente.Show();
            this.Hide();
        }

        private void buttonCanje_Click(object sender, EventArgs e)
        {
            
        }
    }
}
