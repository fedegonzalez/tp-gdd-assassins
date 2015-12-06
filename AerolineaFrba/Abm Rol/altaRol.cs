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
            comboBox1.Text = "";
        }

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
            verificarRol();
        }

      void altaDeRol()
      {
          try
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
          catch (Exception err)
          {
              MessageBox.Show(err.Message);
          }
          try
          {
              using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
              using (SqlCommand comando = connection.CreateCommand())
              {
                  comando.CommandText = "INSERT INTO ASSASSINS.Rol_Funcionalidad(Func_ID, Rol_ID) VALUES ((SELECT Func_ID FROM ASSASSINS.Funcionalidad" +
                  "WHERE Func_Nombre=@funcNombre), (SELECT Func_ID FROM ASSASSINS.Funcionalidad WHERE Rol_Nombre=@rolNombre))";

                  comando.Parameters.AddWithValue("@funcNombre", comboBox1.Text);
                  comando.Parameters.AddWithValue("@rolNombre", textBox1.Text);

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

      void verificarRol()
      {
          query = "SELECT * FROM ASSASSINS.Rol WHERE Rol_Nombre='" + textBox1.Text + "'";
          try
          {
              SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
              SqlCommand comando = new SqlCommand(query, conexion);
              conexion.Open();
              SqlDataReader leer = comando.ExecuteReader();

              if (leer.Read() == true)
              {
                  insertarRolExistente();
              }
              else
              {
                  altaDeRol();
              }
              conexion.Close();
          }
          catch (Exception err)
          {
              MessageBox.Show(err.Message);
          }
      }

      void insertarRolExistente()
      {
          try
          {
              using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
              using (SqlCommand comando = connection.CreateCommand())
              {
                  comando.CommandText = "EXEC ASSASSINS.InsertRol_Funcionalidad @Func_Nombre=@funcNombre, @Rol_Nombre=@rolNombre";

                  comando.Parameters.AddWithValue("@funcNombre", comboBox1.Text);
                  comando.Parameters.AddWithValue("@rolNombre", textBox1.Text);

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
