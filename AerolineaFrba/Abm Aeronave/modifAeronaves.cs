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
    public partial class modifAeronaves : Form
    {
        public modifAeronaves()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            monthCalendar1.Visible = false;
        }

        private void modifAeronaves_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string idText
        {
            get
            {
                return this.textBox2.Text;
            }
            set
            {
                this.textBox2.Text = value;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
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

        void ejecutar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                if (checkBox1.Checked == true)
                {
                    comando.CommandText = "UPDATE ASSASSINS.Aeronave SET Aeronave_Fecha_Baja_Definitiva=getdate(),"+
                    "Aeronave_Habilitado=0 WHERE Aeronave_Numero=@aeroNum";

                    comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);
                }
                else
                {
                    comando.CommandText = "UPDATE ASSASSINS.Aeronave SET Aeronave_Matricula=@aeroMat, Aeronave_Modelo=@aeroMod,"
                + "Aeronave_KG_Capacidad=@aeroKG, Aeronave_Fabricante=@aeroFab, Aeronave_Butacas_Pasillo=@aeroButPas," +
                "Aeronave_Butacas_Ventana=@aeroButVen, TipoServ_ID=@tipoServ, Aeronave_Fecha_Reinicio_Servicio=@aeroFechaRein," +
                "Aeronave_Habilitado=0, Aeronave_Fecha_Fuera_Servicio=getdate() WHERE Aeronave_Numero=@aeroNum)";

                    comando.Parameters.AddWithValue("@aeroMat", textBox4.Text);
                    comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);
                    comando.Parameters.AddWithValue("@aeroMod", textBox3.Text);
                    comando.Parameters.AddWithValue("@aeroKG", textBox9.Text);
                    comando.Parameters.AddWithValue("@aeroFab", textBox6.Text);
                    comando.Parameters.AddWithValue("@aeroButPas", textBox7.Text);
                    comando.Parameters.AddWithValue("@aeroButVen", textBox8.Text);
                    comando.Parameters.AddWithValue("@tipoServ", comboBox1.Text);
                    comando.Parameters.AddWithValue("@aeroFechaRein", textBox1.Text);
                    comando.Parameters.AddWithValue("@aeroHab", checkBox1.Checked);
                }

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label2.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                checkBox1.Checked = false;
            }

            if (checkBox2.Checked == false)
            {
                label2.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
