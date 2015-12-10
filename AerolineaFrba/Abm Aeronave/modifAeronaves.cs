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
            comboBox1.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            monthCalendar1.Visible = false;
        }

        string query;

        private void modifAeronaves_Load(object sender, EventArgs e)
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

        public string modelo
        {
            get
            {
                return this.comboBox2.Text;
            }
            set
            {
                this.comboBox2.Text = value;
            }
        }

        public string matricula
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

        public string fabricante
        {
            get
            {
                return this.comboBox3.Text;
            }
            set
            {
                this.comboBox3.Text = value;
            }
        }

        public string tipoServ
        {
            get
            {
                return this.comboBox1.Text;
            }
            set
            {
                this.comboBox1.Text = value;
            }
        }

        public string kgs
        {
            get
            {
                return this.textBox9.Text;
            }
            set
            {
                this.textBox9.Text = value;
            }
        }

        public string cantButacas
        {
            get
            {
                return this.label8.Text;
            }
            set
            {
                this.label8.Text = value;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
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

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
                try
                {
                    ejecutar();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                if (checkBox1.Checked == true)
                {
                    if (MessageBox.Show("¿Desea cancelar los pasajes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                        using (SqlCommand comando = connection.CreateCommand())
                        {

                            comando.CommandText = "";

                            comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);

                            connection.Open();
                            comando.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    else
                    {
                        try
                        {
                            verificarAeronave(true);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
                if (checkBox2.Checked == true)
                {
                    if (MessageBox.Show("¿Desea cancelar los pasajes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            cancelar();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            verificarAeronave(false);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                }
        }

        void verificarAeronave(bool total)
        {
            query = "SELECT Aeronave_Numero FROM ASSASSINS.AERONAVE WHERE Aeronave_KG_Capacidad >= " + kgs + " AND Fabricante_ID = " + fabricante +
            " AND Modelo_ID = " + modelo + " AND TipoServ_ID = " + tipoServ + " AND Aeronave_Butacas_Pasillo+Aeronave_Butacas_Ventana >= "
            + cantButacas + " AND Aeronave_Numero <> " + Convert.ToInt32(textBox2.Text);
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                // REEMPLAZAR VIAJES CON ESTE NUMERO DE AERONAVE !!!
            }
            else
            {
                altaAeronave alta = new altaAeronave(comboBox2.Text, comboBox1.Text, comboBox3.Text, textBox9.Text, label8.Text, true, total);
                alta.Show();
            }
            conexion.Close();
        }

        void ejecutar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                if (checkBox1.Checked == true)
                {
                    comando.CommandText = "UPDATE ASSASSINS.Aeronave SET Aeronave_Habilitado=0, " +
                    "Aeronave_Fecha_Baja_Definitiva=getdate() WHERE Aeronave_Numero=@aeroNum";

                    comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);
                }
                else
                {
                    if (checkBox2.Checked == true)
                    {
                        comando.CommandText = "UPDATE ASSASSINS.Aeronave SET Aeronave_Habilitado=0 WHERE Aeronave_Numero=@aeroNum; INSERT INTO"+
                        "ASSASSINS.Baja_Servicio(Aeronave_Fecha_Fuera_Servicio, Aeronave_Fecha_Reinicio_Servicio, Aeronave_Numero) VALUES(" +
                        "getdate(), @fechaReset, @aeroNum)";
                    }
                    else
                    {
                        comando.CommandText = "EXEC ASSASSINS.UpdateAeronave @aeroNum=@aeroNum, @aeroMat=@aeroMat, @aeroMod=@aeroMod,"
                        + "@aeroKG=@aeroKG, @aeroFab=@aeroFab, @tipoServ=@tipoServ, " +
                        "@aeroHab=1 WHERE Aeronave_Numero=@aeroNum)";
                    }

                    comando.Parameters.AddWithValue("@fechaReset", textBox1.Text);
                    comando.Parameters.AddWithValue("@aeroMat", textBox4.Text);
                    comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);
                    comando.Parameters.AddWithValue("@aeroMod", comboBox2.Text);
                    comando.Parameters.AddWithValue("@aeroKG", textBox9.Text);
                    comando.Parameters.AddWithValue("@aeroFab", comboBox3.Text);
                    comando.Parameters.AddWithValue("@tipoServ", comboBox1.Text);
                }

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        void cancelar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {

                comando.CommandText = "EXEC ASSASSINS.CancelarPasajes @aeroNum=@aeroNum";

                comando.Parameters.AddWithValue("@aeroNum", textBox2.Text);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
    }
}
