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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void accesoAAdministradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.registroDeUsuario abrirUsuario = new Registro_de_Usuario.registroDeUsuario();
            abrirUsuario.Show();
        }

        private void terminalKioscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicioCliente abrirKiosco = new inicioCliente();
            abrirKiosco.Show();
        }
    }
}
