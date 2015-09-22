using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class registroDeUsuario : Form
    {
        public registroDeUsuario()
        {
            InitializeComponent();
        }

        private void registroDeUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicioAdministrador abrir = new inicioAdministrador();
            abrir.Show();
            this.Hide();
        }
    }
}
