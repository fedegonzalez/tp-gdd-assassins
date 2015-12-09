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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class generacionViaje : Form
    {
        public generacionViaje()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendarFS.Visible = true;
            monthCalendarFLE.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = true;
            monthCalendarFS.Visible = false;
            dateTimePicker3.Visible = true;
            dateTimePicker1.Visible = false;
        }

        private void monthCalendarFS_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendarFS.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        private void monthCalendarFLE_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendarFLE.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker3.Value.TimeOfDay;
        }

        private void generacionViaje_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void buttonGenerarViaje_Click(object sender, EventArgs e)
        {
            bool textbox = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            TimeSpan diff = DateTime.Parse(textBox3.Text) - DateTime.Parse(textBox1.Text);
            if (!textbox)
            {
                if (DateTime.Parse(textBox1.Text) > DateTime.Now && diff.TotalHours > 0 && diff.TotalHours < 24)
                {
                    if (consultarTipoServ("SELECT * FROM ASSASSINS.Ruta_Aeronave WHERE Ruta_ID=" + textBox6.Text + " AND Aeronave_Numero=" + textBox4.Text))
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                            using (SqlCommand comando = connection.CreateCommand())
                            {
                                comando.CommandText = "INSERT INTO ASSASSINS.Viaje (Ruta_ID, Aeronave_Numero, Viaje_Fecha_Salida, "
                                + "Viaje_Fecha_Llegada_Estimada) VALUES (@rutaID, @aeroNum, @salida, @llegadaEstimada)";

                                comando.Parameters.AddWithValue("@rutaID", textBox6.Text);
                                comando.Parameters.AddWithValue("@aeroNum", textBox4.Text);
                                comando.Parameters.AddWithValue("@salida", textBox1.Text);
                                comando.Parameters.AddWithValue("@llegadaEstimada", textBox3.Text);

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
                        MessageBox.Show("La Ruta y la Aeronave no tienen el mismo tipo de servicio");
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de salida debe ser posterior a hoy\nLa fecha estimada debe ser posterior a la de salida y menor a 24 horas");
                }
            }
            else
            {
                MessageBox.Show("Faltan datos");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = monthCalendarFS.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay; 
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = monthCalendarFLE.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker3.Value.TimeOfDay;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.listadoRutas abrir = new Generacion_Viaje.listadoRutas(this);
            abrir.Show();
        }

        public string aeronave
        {
            get
            {
                return this.textBox4.Text;
            }
            set
            {
                this.textBox4.Text = value;
            }
        }

        public string ruta
        {
            get
            {
                return this.textBox6.Text;
            }
            set
            {
                this.textBox6.Text = value;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.listadoAeronaves abrir = new Generacion_Viaje.listadoAeronaves(this);
            abrir.Show();
        }

        bool consultarTipoServ(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                conexion.Close();
                return true;
            }
            else
            {
                conexion.Close();
                return false;
            }
        }

    }
}
