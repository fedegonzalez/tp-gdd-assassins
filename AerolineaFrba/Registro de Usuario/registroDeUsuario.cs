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

namespace AerolineaFrba.Registro_de_Usuario
{
    public partial class registroDeUsuario : Form
    {
        public registroDeUsuario()
        {
            InitializeComponent();
        }

        private void registroDeUsuario_Load(object sender, EventArgs e)
        {

        }

        bool ok = false;
        bool flag = true;
        string query;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text.Length > 0 && textPass.Text.Length > 0)
            {
                query = "EXEC ASSASSINS.SelectUsuario @Username = '" + textUsuario.Text + "' , @Password = '" + textPass.Text + "'";
                string query2 = "SELECT Usuario_Habilitado FROM ASSASSINS.USUARIO WHERE Usuario_Username='" + textUsuario.Text + "'";

                try
                {
                    consultarHabilitado(query2);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                if (flag)
                {
                    try
                    {
                        consultarUsuario(query);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                if (ok == true)
                {
                    MessageBox.Show("Bienvenido al sistema");
                    query = "update ASSASSINS.Usuario set Usuario_Intentos=0 where Usuario_Username='" + textUsuario.Text + "'";
                    try
                    {
                        ejecutar(query);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    inicioAdministrador abrir = new inicioAdministrador();
                    abrir.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
        }

        void ejecutar(string query)
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                comando.CommandText = query;

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }

        }

        void consultarUsuario(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {

                if (leer.GetSqlBoolean(5) == true)
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    MessageBox.Show("El usuario esta deshabilitado");
                }
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
                ejecutar("update ASSASSINS.Usuario set Usuario_Intentos=Usuario_Intentos+1 where Usuario_Username='" + textUsuario.Text + "'");
                consultarIntentos("SELECT * FROM ASSASSINS.Usuario WHERE Usuario_Username='" + textUsuario.Text + "'");
            }
            conexion.Close();
        }

        void consultarIntentos(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                if (leer.GetSqlInt32(4) >= 3)
                {
                    ejecutar("update ASSASSINS.Usuario set Usuario_Habilitado=0 where Usuario_Username='" + textUsuario.Text + "'");
                }
            }
            conexion.Close();
        }

        void consultarHabilitado(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                if (leer.GetSqlBoolean(0) == false)
                {
                    MessageBox.Show("El usuario esta deshabilitado");
                    ok = false;
                    flag = false;
                }
            }
            conexion.Close();
        }
    }
}