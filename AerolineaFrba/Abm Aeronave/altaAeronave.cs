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
        public altaAeronave(string fecha, string aeroVieja, string modelo, string tipoServ, string fabricante, string kgs, string butacas, bool reemplazo, bool total)
        {
            InitializeComponent();
            mod = modelo;
            tServ = tipoServ;
            fab = fabricante;
            kg = kgs;
            butaca = butacas;
            reemplazar = reemplazo;
            tot = total;
            aero = aeroVieja;
            fec = fecha;
        }

        bool reemplazar, tot;
        string mod, tServ, fab, kg, butaca, aero, fec;
        int aeroNueva;

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
        bool unico = true;

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool textbox = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            bool combobox = this.Controls.OfType<ComboBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (!textbox && !combobox)
            {
                if (!reemplazar)
                {
                    try
                    {
                        consultarUnico("SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula='" + textBox4.Text + "'");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    if (unico)
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
                }
                else
                {
                    try
                    {
                        consultarUnico("SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula='" + textBox4.Text + "'");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    if (unico)
                    {
                        try
                        {
                            ejecutar();
                            reemplazarAero();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan datos a ingresar");
            }
        }

        void ejecutar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = "EXEC ASSASSINS.InsertAeronave @aeroMat=@aeroMat, @aeroMod=@aeroMod, @aeroKG=@aeroKG, @aeroFab=@aeroFab"+
                ", @aeroButPas=@aeroButPas, @aeroButVen=@aeroButVen, @tipoServ=@tipoServ, @aeroFechaAlta=@aeroFechaAlta, @aeroHab=@aeroHab";

                comando.Parameters.AddWithValue("@aeroMat", textBox4.Text);
                comando.Parameters.AddWithValue("@aeroMod", Int32.Parse(comboBox2.Text));
                comando.Parameters.AddWithValue("@aeroKG", Int32.Parse(textBox9.Text));
                comando.Parameters.AddWithValue("@aeroFab", Int32.Parse(comboBox3.Text));
                comando.Parameters.AddWithValue("@aeroButPas", Int32.Parse(textBox7.Text));
                comando.Parameters.AddWithValue("@aeroButVen", Int32.Parse(textBox8.Text));
                comando.Parameters.AddWithValue("@tipoServ", Int32.Parse(comboBox1.Text));
                comando.Parameters.AddWithValue("@aeroFechaAlta", textBox1.Text);
                comando.Parameters.AddWithValue("@aeroHab", 1);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void altaAeronave_Load(object sender, EventArgs e)
        {
            if (!reemplazar)
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
            else
            {
                comboBox2.Text = mod;
                comboBox3.Text = fab;
                comboBox1.Text = tServ;
                textBox9.Text = kg;
                textBox7.Text = butaca;
                textBox8.Text = butaca;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
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

        void reemplazarAero()
        {
            consultarMatricula();

                string query2 = "EXEC ASSASSINS.ReemplazarAero @aeroVieja=@aeroNum, @aeroNueva=@aeroNueva, @fecha=@fechaReset"+
                ", @total=@total";
                SqlConnection conexion2 = new SqlConnection(Properties.Settings.Default.dbConnection);
                SqlCommand comando2 = new SqlCommand(query2, conexion2);

                comando2.Parameters.AddWithValue("@fechaReset", DateTime.Parse(fec));
                comando2.Parameters.AddWithValue("@total", tot);
                comando2.Parameters.AddWithValue("@aeroNum", Int32.Parse(aero));
                comando2.Parameters.AddWithValue("@aeroNueva", aeroNueva);

                conexion2.Open();
                comando2.ExecuteNonQuery();
                conexion2.Close();
        }
        void consultarUnico(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                    MessageBox.Show("Ya existe una aeronave con esa matricula");
                    unico = false;
            }
            conexion.Close();
        }

        void consultarMatricula()
        {
            try
            {
                string query = "SELECT Aeronave_Numero FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula='" + textBox4.Text + "'";
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    aeroNueva = (int)leer.GetSqlInt32(0);
                }
                conexion.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
    }
}
