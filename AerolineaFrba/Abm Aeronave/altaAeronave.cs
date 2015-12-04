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
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
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
                comando.CommandText = "EXEC ASSASSINS.InsertAeronave @aeroMat=@aeroMat, @aeroMod=@aeroMod, @aeroKG=@aeroKG, @aeroFab=@aeroFab, @aeroButPas=@aeroButPas, @aeroButVen=@aeroButVen, @tipoServ=@tipoServ, @aeroFechaAlta=@aeroFechaAlta, @aeroHab=@aeroHab";

                comando.Parameters.AddWithValue("@aeroMat", textBox4.Text);
                comando.Parameters.AddWithValue("@aeroMod", comboBox2.Text);
                comando.Parameters.AddWithValue("@aeroKG", textBox9.Text);
                comando.Parameters.AddWithValue("@aeroFab", comboBox3.Text);
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
            query = "select TipoServ_Nombre from ASSASSINS.Tipo_Servicio";
            try
            {
                cargarComboBox(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            query = "select Modelo_Nombre from ASSASSINS.Modelo";
            try
            {
                cargarComboBoxModelo(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            query = "select Fabricante_Nombre from ASSASSINS.Fabricante";
            try
            {
                cargarComboBoxFabricante(query);
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

        void cargarComboBoxModelo(string query)
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

        void cargarComboBoxFabricante(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBox3.Items.Add(leer[0]);
            }
            conexion.Close();
        }
    }
}
