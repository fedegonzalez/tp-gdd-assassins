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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class registroLlegadaDestino : Form
    {
        public registroLlegadaDestino()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        string query;

        private void registroLlegadaDestino_Load(object sender, EventArgs e)
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
            query = "SELECT Aeronave_Matricula FROM ASSASSINS.Aeronave";
            try
            {
                cargarComboBox3(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool textbox = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            bool combobox = this.Controls.OfType<ComboBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (!textbox && !combobox)
            {
                try
                {
                    ejecutar();
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

        void ejecutar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = "";

                comando.Parameters.AddWithValue("@aeroMat", comboBox2.Text);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
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
        void cargarComboBox3(string query)
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
