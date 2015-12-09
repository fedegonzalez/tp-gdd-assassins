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
            monthCalendarFL.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendarFL.Visible = true;
            monthCalendarFLE.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker2.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = true;
            monthCalendarFS.Visible = false;
            monthCalendarFL.Visible = false;
            dateTimePicker3.Visible = true;
            dateTimePicker2.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void monthCalendarFS_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendarFS.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay;
        }

        private void monthCalendarFL_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendarFL.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker2.Value.TimeOfDay;
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
            monthCalendarFL.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            monthCalendarFLE.Visible = false;
            monthCalendarFL.Visible = false;
            monthCalendarFS.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
        }

        private void buttonGenerarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (SqlCommand comando = connection.CreateCommand())
                {
                    comando.CommandText = "INSERT INTO ASSASSINS.Viaje (Ruta_ID, Aeronave_Numero, Viaje_Fecha_Salida, Viaje_Fecha_Llegada, "
                    + "Viaje_Fecha_Llegada_Estimada) VALUES (@rutaID, @aeroNum, @salida, @llegada, @llegadaEstimada)";

                    comando.Parameters.AddWithValue("@rutaID", textBox6.Text);
                    comando.Parameters.AddWithValue("@aeroNum", textBox4.Text);
                    comando.Parameters.AddWithValue("@salida", textBox1.Text);
                    comando.Parameters.AddWithValue("@llegada", textBox2.Text);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = monthCalendarFS.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker1.Value.TimeOfDay; 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = monthCalendarFL.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker2.Value.TimeOfDay;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = monthCalendarFLE.SelectionRange.Start.Date.ToShortDateString() + " " + dateTimePicker3.Value.TimeOfDay;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.listadoRutas abrir = new Generacion_Viaje.listadoRutas();
            abrir.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Generacion_Viaje.listadoAeronaves abrir = new Generacion_Viaje.listadoAeronaves();
            abrir.Show();
        }

    }
}
