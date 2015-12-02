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
    public partial class altaAeronave : Form
    {
        public altaAeronave()
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
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        string query;

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                ejecutar(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void ejecutar(string query)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = "INSERT INTO ASSASSINS.Aeronave (Aeronave_Matricula, Aeronave_Modelo, Aeronave_KG_Capacidad, Aeronave_Fabricante, Aeronave_Butacas_Pasillo, Aeronave_Butacas_Ventana, TipoServ_ID, Aeronave_Fecha_Alta, Aeronave_Habilitado)"
                +"VALUES (@aeroMat, @aeroMod, @aeroKG, @aeroFab, @aeroButPas, @aeroButVen, @tipoServ, @aeroFechaAlta, @aeroHab)";

                comando.Parameters.AddWithValue("@aeroMat", textBox4.Text);
                comando.Parameters.AddWithValue("@aeroMod", textBox3.Text);
                comando.Parameters.AddWithValue("@aeroKG", textBox9.Text);
                comando.Parameters.AddWithValue("@aeroFab", textBox6.Text);
                comando.Parameters.AddWithValue("@aeroButPas", textBox7.Text);
                comando.Parameters.AddWithValue("@aeroButVen", textBox8.Text);
                comando.Parameters.AddWithValue("@tipoServ", comboBox1.Text);
                comando.Parameters.AddWithValue("@aeroFechaAlta", textBox1.Text);
                comando.Parameters.AddWithValue("@aeroHab", 1);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void altaAeronave_Load(object sender, EventArgs e)
        {
            query = "select TipoServ_ID from ASSASSINS.Tipo_Servicio";
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
    }
}
