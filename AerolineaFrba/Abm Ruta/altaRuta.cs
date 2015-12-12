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
            bool textbox = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            bool combobox = this.Controls.OfType<ComboBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (!textbox && !combobox)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                    using (SqlCommand comando = connection.CreateCommand())
                    {
                        comando.CommandText = "EXEC ASSASSINS.InsertRuta @rutaCod=@rutaCod, @precioBaseKG=@rutaPrecioBaseKG"
                        + "@precioBasePas=@rutaPrecioBaseKG, @rutaOrigen=@rutaCiudadOrigen, @rutaDestino=@rutaCiudadDestino";

                        comando.Parameters.AddWithValue("@rutaCod", textBox1.Text);
                        comando.Parameters.AddWithValue("@rutaPrecioBasePas", textBox5.Text);
                        comando.Parameters.AddWithValue("@rutaPrecioBaseKG", textBox6.Text);
                        comando.Parameters.AddWithValue("@rutaCiudadOrigen", comboBox1.Text.Substring(2));
                        comando.Parameters.AddWithValue("@rutaCiudadDestino", comboBox2.Text.Substring(2));
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
            else
            {
                MessageBox.Show("Faltan datos");
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
