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


namespace AerolineaFrba.Devolucion
{
    public partial class devolucion : Form
    {
        public devolucion()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            
        }

        private String obtenerCodigoDevolucion(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = comando.ExecuteReader();

            String number = "";

            while (reader.Read())
            {
                number = reader.GetSqlValue(0).ToString();
            }

            MessageBox.Show("number" + number);

                if("".Equals(number)){
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    number = new String(stringChars);
                }

                MessageBox.Show("number" + number);

                reader.Close();
                conexion.Close();

                return number;
        }

        void ejecutar(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String NumeroCompra = textBox2.Text.ToString();
            String Motivo = textBox4.Text.ToString();
            String queryEstadoPasaje = "";
            String queryEstadoEncomienda = "";
            String encomiendaid = textBox5.Text;
            String pasajeid = textBox3.Text;

            if ((pasajeid != "" || encomiendaid != "") && NumeroCompra != "" && textBox1.Text != "" && Motivo != "")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                    using (SqlCommand comando = connection.CreateCommand())
                    {
                        if (pasajeid != "")
                        {
                            String CodigoDevolucion = obtenerCodigoDevolucion("select Codigo_Devolucion from ASSASSINS.Devolucion_Pasaje where PNR = " + NumeroCompra);


                            comando.CommandText = "INSERT INTO ASSASSINS.Devolucion_Pasaje (Pasaje_ID,PNR,Fecha_Devolucion,Motivo,Codigo_Devolucion)"
                                + "VALUES (@codigoPasaje, @pnr, @fecha,@motivo,@codigodevolucion)";

                            comando.Parameters.AddWithValue("@fecha", textBox1.Text);
                            comando.Parameters.AddWithValue("@pnr", NumeroCompra);
                            comando.Parameters.AddWithValue("@codigoPasaje", textBox3.Text);
                            comando.Parameters.AddWithValue("@motivo", Motivo);
                            comando.Parameters.AddWithValue("@codigodevolucion", CodigoDevolucion);

                            connection.Open();
                            comando.ExecuteNonQuery();
                            connection.Close();

                            queryEstadoPasaje = "update ASSASSINS.Pasaje set Pasaje_Estado=0 where Pasaje_ID = " + textBox3.Text;

                            ejecutar(queryEstadoPasaje);
                        }
                        if (encomiendaid != "")
                        {

                            String CodigoDevolucion = obtenerCodigoDevolucion("select Codigo_Devolucion from ASSASSINS.Devolucion_Encomienda where PNR = " + NumeroCompra);

                            comando.CommandText = "INSERT INTO ASSASSINS.Devolucion_Encomienda (Encomienda_ID,PNR,Fecha_Devolucion,Motivo,Codigo_Devolucion)"
           + "VALUES (@codigoEncomieda, @pnrEncomienda, @fechaEncomienda,@motivoEncomienda,@codigodevolucion)";

                            comando.Parameters.AddWithValue("@fechaEncomienda", textBox1.Text);
                            comando.Parameters.AddWithValue("@pnrEncomienda", NumeroCompra);
                            comando.Parameters.AddWithValue("@codigoEncomieda", encomiendaid);
                            comando.Parameters.AddWithValue("@motivoEncomienda", Motivo);
                            comando.Parameters.AddWithValue("@codigodevolucion", CodigoDevolucion);

                            connection.Open();
                            comando.ExecuteNonQuery();
                            connection.Close();

                            queryEstadoEncomienda = "update ASSASSINS.Encomienda set Encomienda_Estado=0 where Encomienda_ID = " + encomiendaid;

                            ejecutar(queryEstadoPasaje);
                        }

                        MessageBox.Show("Devolución Exitosa");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
            else {
                MessageBox.Show("El campo Codigo Pasaje, Codigo Encomienda, Codigo de Compra, Fecha, Motivo no puede ser vacio");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
