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

        string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
        string query;

        private void modificacionListadoAeronave_Load(object sender, EventArgs e)
        {
            query = "select Aeronave_Matricula from ASSASSINS.Aeronave";
            try
            {
                cargarComboBox(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            } 
            
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
