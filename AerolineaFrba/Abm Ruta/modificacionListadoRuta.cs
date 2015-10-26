using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class modificacionListadoRuta : Form
    {
        public modificacionListadoRuta()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Ruta.modifRuta abrir = new Abm_Ruta.modifRuta();
            abrir.Show();
        }

        private void modificacionListadoRuta_Load(object sender, EventArgs e)
        {
            string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
            string query = "select Ruta_ID from ASSASSINS.Ruta";
            SqlConnection conexion = new SqlConnection(conex);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBoxRol.Items.Add(leer[0]);
            }
            conexion.Close();
        }
    }
}
