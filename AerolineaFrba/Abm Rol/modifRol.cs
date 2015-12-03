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
            this.checkBox2.Visible = true;
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (SqlCommand comando = connection.CreateCommand())
                {
                    if (checkBox2.Visible == true)
                    {
                        comando.CommandText = "UPDATE ASSASSINS.Ruta SET Rol_Habilitado=@habilitado";

                        comando.Parameters.AddWithValue("@habilitado", checkBox2.Checked);
                    }
                    else
                    {
                        comando.CommandText = "UPDATE ASSASSINS.Ruta SET Rol_Nombre=@rolNombre, Func_Nombre= @funcNombre"+
                        "WHERE Rol_ID=@rolID";

                        comando.Parameters.AddWithValue("@rolID", textBox2.Text);
                        comando.Parameters.AddWithValue("@rolNombre", textBox1.Text);
                        comando.Parameters.AddWithValue("@funcNombre", comboBox1.Text);
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
    }
}
