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
    public partial class datosDelCliente : Form
    {
        public datosDelCliente(int viajeID, int cantPas, int kg, int[] dnis, int[] butacas, bool primeraVez, bool soloTarjeta)
        {
            InitializeComponent();
            viaje = viajeID;
            tarjeta = soloTarjeta;
            cantPasajeros = cantPas;
            cantKGS = kg;
            if (primeraVez)
            {
                dni = new int[cantPasajeros];
                butaca = new int[cantPasajeros];
            }
            else
            {
                dni = new int[dnis.Length];
                butaca = new int[dnis.Length];
            }
            if (dnis != null && butacas != null)
            {
                Array.Copy(dnis, dni, dnis.Length);
                Array.Copy(butacas, butaca, butacas.Length);
            }
        }

        bool tarjeta;
        int viaje, cantPasajeros, cantKGS;
        int[] dni;
        int[] butaca;

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cantPasajeros--;
            if (textBox4.Text != "" && comboBox2.Text != "")
            {
                dni[cantPasajeros] = int.Parse(textBox4.Text);
                butaca[cantPasajeros] = int.Parse(comboBox2.Text);

                if (cantPasajeros > 0)
                {
                    try
                    {
                        cliente();
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    Compra.datosDelCliente abrir = new Compra.datosDelCliente(viaje, cantPasajeros, cantKGS, dni, butaca, false, tarjeta);
                    abrir.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        cliente();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    Compra.formaPago abrirPago = new Compra.formaPago(viaje, dni, tarjeta);
                    abrirPago.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hay datos faltantes");
            }
        }

        private void datosDelCliente_Load(object sender, EventArgs e)
        {
            string query = "SELECT b.Butaca_Nro FROM ASSASSINS.Butaca b, ASSASSINS.Viaje v WHERE "+
            "b.Aeronave_Numero=v.Aeronave_Numero AND b.Butaca_ID NOT IN (SELECT Butaca_ID FROM ASSASSINS.Pasaje WHERE"+
            " Viaje_ID=" + viaje + ") AND v.Viaje_ID=" + viaje;
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
                comboBox2.Items.Add(leer[0]);
            }
            conexion.Close();
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

        void cliente()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = "EXEC ASSASSINS.CompraPasaje @nombre=@nombre, @apellido=@apellido, " +
                "@dni=@dni, @direccion=@direccion, @telefono=@telefono, @mail=@mail, @fechanacimiento=@fechanacimiento";

                comando.Parameters.AddWithValue("@nombre", textBox2.Text);
                comando.Parameters.AddWithValue("@apellido", textBox3.Text);
                comando.Parameters.AddWithValue("@dni", textBox4.Text);
                comando.Parameters.AddWithValue("@direccion", textBox6.Text);
                comando.Parameters.AddWithValue("@telefono", textBox5.Text);
                comando.Parameters.AddWithValue("@mail", textBox7.Text);
                comando.Parameters.AddWithValue("@fechanacimiento", textBox1.Text);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
