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
    public partial class altaRuta : Form
    {
        public altaRuta()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (SqlCommand comando = connection.CreateCommand())
                {
                    comando.CommandText = "INSERT INTO ASSASSINS.Ruta (Ruta_ID, Ruta_Precio_BasePasaje, Ruta_Precio_BaseKG,Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Habilitado) VALUES (@rutaID, @rutaPrecioBasePas, @rutaPrecioBaseKG,@rutaCiudadOrigen, @rutaCiudadDestino, @rutaHabilitado)";

                    comando.Parameters.AddWithValue("@rutaID", textBox1.Text);
                    comando.Parameters.AddWithValue("@rutaPrecioBasePas", textBox5.Text);
                    comando.Parameters.AddWithValue("@rutaPrecioBaseKG", textBox6.Text);
                    comando.Parameters.AddWithValue("@rutaCiudadOrigen", textBox3.Text);
                    comando.Parameters.AddWithValue("@rutaCiudadDestino", textBox4.Text);
                    comando.Parameters.AddWithValue("@rutaHabilitado", 1);

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

        private void altaRuta_Load(object sender, EventArgs e)
        {

        }

    }
}
