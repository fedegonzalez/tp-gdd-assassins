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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class consultaMillas : Form
    {
        public consultaMillas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string query;

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    query = "SELECT Cliente_Millas FROM ASSASSINS.Cliente WHERE Cliente_DNI=" + textBox1.Text;

                    SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();
                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read())
                    {
                        label3.Text = "Usted tiene " + leer.GetSqlDecimal(0) + " millas.";
                        label3.Visible = true;
                    }

                    conexion.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI");
            }

        }

        private void consultaMillas_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
