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
using System.Data.SqlTypes;

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
        }

        private void altaRol_Load(object sender, EventArgs e)
        {
        }

      private void buttonGuardar_Click(object sender, EventArgs e)
        {
            altaDeRol();
        }

      void altaDeRol()
      {
              using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
              using (SqlCommand comando = connection.CreateCommand())
              {
                  comando.CommandText = "INSERT INTO ASSASSINS.Rol (Rol_Nombre, Rol_Habilitado) VALUES" +
                      "(@rolNombre, @rolHabilitado)";

                  comando.Parameters.AddWithValue("@rolNombre", textBox1.Text);
                  comando.Parameters.AddWithValue("@rolHabilitado", 1);

                  connection.Open();
                  comando.ExecuteNonQuery();
                  connection.Close();
              }
      }

    }
}
