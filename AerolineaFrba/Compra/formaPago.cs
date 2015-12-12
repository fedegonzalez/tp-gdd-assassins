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

namespace AerolineaFrba.Compra
{
    public partial class formaPago : Form
    {
        public formaPago(int viajeID, int[] dnis, bool soloTarjeta)
        {
            InitializeComponent();
            viaje = viajeID;
            tarjeta = soloTarjeta;
            dni = new int[dnis.Length]; 
            Array.Copy(dnis, dni, dnis.Length);
        }

        bool tarjeta;
        int viaje;
        int[] dni;
        string datosTotales;

        private void formaPago_Load(object sender, EventArgs e)
        {
            if (tarjeta)
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "Tarjeta de Credito";
                comboBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ASSASSINS.Cliente WHERE Cliente_DNI='" + textBox4.Text + "'";

            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    textBox2.Text = leer.GetString(1);
                    textBox3.Text = leer.GetString(2);
                    textBox6.Text = leer.GetString(4);
                    textBox5.Text = leer.GetSqlDecimal(5).ToString();
                    textBox7.Text = leer.GetString(6);
                    textBox1.Text = leer.GetSqlDateTime(7).ToString();
                }
                conexion.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Tarjeta de Credito")
            {
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox12.ReadOnly = false;
                textBox14.ReadOnly = false;
            }

            if (comboBox1.Text == "Efectivo")
            {
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox12.ReadOnly = true;
                textBox14.ReadOnly = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            datosTotales = "";
            for (int i = 0; i <= dni.Length - 1; i++)
            {
                if (i != 0)
                {
                    datosTotales += ",";
                }

                datosTotales += dni[i].ToString();
            }

            try
            {
                comprar();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        void comprar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = "EXEC ASSASSINS.LOQUEQUIERAS @DATOS=@DATOS, @viaje=@viaje";

                comando.Parameters.AddWithValue("@DATOS", datosTotales);
                comando.Parameters.AddWithValue("@DATOS", viaje);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
