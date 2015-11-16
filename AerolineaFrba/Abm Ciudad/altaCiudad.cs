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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class altaCiudad : Form
    {
        public altaCiudad()
        {
            InitializeComponent();
        }

        private void altaCiudad_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                    using (SqlCommand comando = connection.CreateCommand())
                    {
                        comando.CommandText = "INSERT INTO ASSASSINS.Ciudad (Ciudad_Nombre) VALUES (@ciudad_nombre)";

                        comando.Parameters.AddWithValue("@ciudad_nombre", textBox1.Text);

                        connection.Open();
                        comando.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        
    }
}
