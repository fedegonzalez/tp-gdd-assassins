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
    public partial class altaRol : Form
    {
        public altaRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            comboBox1.Text = "";
        }

        string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
        string query;

        private void altaRol_Load(object sender, EventArgs e)
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
            SqlConnection conexion = new SqlConnection(conex);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBox1.Items.Add(leer[0]);
            }
            conexion.Close();
        }
    }
}
