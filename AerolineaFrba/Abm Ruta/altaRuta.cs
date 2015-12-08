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
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (SqlCommand comando = connection.CreateCommand())
                {
                    comando.CommandText = "INSERT INTO ASSASSINS.Ruta (Ruta_Codigo, Ruta_Precio_BasePasaje, Ruta_Precio_BaseKG, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Habilitado)"
                        +"VALUES (@rutaCod, @rutaPrecioBasePas, @rutaPrecioBaseKG, @rutaCiudadOrigen, @rutaCiudadDestino, @rutaHabilitado)";

                    comando.Parameters.AddWithValue("@rutaCod", textBox1.Text);
                    comando.Parameters.AddWithValue("@rutaPrecioBasePas", textBox5.Text);
                    comando.Parameters.AddWithValue("@rutaPrecioBaseKG", textBox6.Text);
                    comando.Parameters.AddWithValue("@rutaCiudadOrigen", comboBox1.Text);
                    comando.Parameters.AddWithValue("@rutaCiudadDestino", comboBox2.Text);
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

        string query;

        private void altaRuta_Load(object sender, EventArgs e)
        {
            query = "SELECT Ciudad_Nombre FROM ASSASSINS.Ciudad";
            try
            {
                cargarComboBox(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            query = "SELECT Ciudad_Nombre FROM ASSASSINS.Ciudad";
            try
            {
                cargarComboBox2(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        void cargarComboBox(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBox1.Items.Add(leer[0]);
            }
            conexion.Close();
        }
        void cargarComboBox2(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBox2.Items.Add(leer[0]);
            }
            conexion.Close();
        }
    }
}
