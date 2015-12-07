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

namespace AerolineaFrba.Abm_Rol
{
    public partial class modifRol : Form
    {
        public modifRol()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        string query;

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

        public void block()
        {
            this.textBox1.Enabled = false;
            this.comboBox1.Enabled = false;
            this.checkBox2.Text = "Dar de baja";
        }

        private void modifRol_Load(object sender, EventArgs e)
        {
            query = "select Func_Nombre from ASSASSINS.Funcionalidad";
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (SqlCommand comando = connection.CreateCommand())
                {
                    if (checkBox2.Text == "Dar de baja" && checkBox2.Checked == true)
                    {
                        comando.CommandText = "UPDATE ASSASSINS.Rol SET Rol_Habilitado=0";
                    }
                    else if (checkBox2.Text == "Rehabilitar Rol" && checkBox2.Checked == true)
                    {
                        comando.CommandText = "EXEC ASSASSINS.UpdateRol @rolID=@rolID, @rolNombre=@rolNombre, @funcAgregar=@funcAgregar, @funcSacar=@funcSacar";
                        
                        comando.Parameters.AddWithValue("@rolID", textBox2.Text);
                        comando.Parameters.AddWithValue("@rolNombre", textBox1.Text);
                        comando.Parameters.AddWithValue("@funcAgregar", comboBox1.Text);
                        comando.Parameters.AddWithValue("@funcSacar", comboBox2.Text);
                    }

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT f.Func_Nombre FROM ASSASSINS.Funcionalidad f, ASSASSINS.Rol_Funcionalidad r WHERE r.Rol_ID='" + textBox2.Text
                + "' AND r.Func_ID=f.Func_ID";
            try
            {
                cargarComboBox2(query);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
