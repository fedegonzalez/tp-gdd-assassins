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

        string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
        string query;

        private void modificacionListadoRuta_Load(object sender, EventArgs e)
        {
            query = "select Ruta_ID from ASSASSINS.Ruta";
            try
            {
                cargarComboBox(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void textBoxParteRol_TextChanged(object sender, EventArgs e)
        {

        }

        void cargarComboBox(string query)
        {
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
