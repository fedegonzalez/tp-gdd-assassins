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

        string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
        decimal intentos = 0;
        bool ok = false;
        string query;

        private void button1_Click(object sender, EventArgs e) // AGREGAR INTENTOS_FALLIDOS !!!
        {
            if (textUsuario.Text.Length > 0 && textPass.Text.Length > 0)
            {
                query = "select * from ASSASSINS.Usuario where Usuario_Username='" + textUsuario.Text + "'";

                System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
                byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(textPass.Text);
                byte[] cryString = sha256.ComputeHash(sha256Bytes);
                string sha256Str = string.Empty;
                for (int i = 0; i < cryString.Length; i++)
                {
                    sha256Str += cryString[i].ToString("X");
                }
                query = query + " and password='" + sha256Str + "'";

                try
                {
                    Consultar(query);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                if (ok == true)
                {
                    MessageBox.Show("Bienvenido al sistema");
                    query = "update ASSASSINS.Usuario set Usuario_intentos_fallidos=0 where Usuario_Username='" + textUsuario.Text + "'";
                    try
                    {
                        ejecutar(query);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }      
                }
                else
                {
                    intentos = intentos + 1;
                    MessageBox.Show("Fallo de login");
                    query = "update ASSASSINS.Usuario set Usuario_intentos_fallidos=Usuario_intentos_fallidos+1 where Usuario_Username='" + textUsuario.Text + "'";
                    try
                    {
                        ejecutar(query);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }

                }

            }
            else
            {
                intentos = intentos + 1;
                MessageBox.Show("Debe ingresar los 2 campos");
                query = "update ASSASSINS.Usuario set Usuario_intentos_fallidos=Usuario_intentos_fallidos+1 where Usuario_Username='" + textUsuario.Text + "'";
                try
                {
                    ejecutar(query);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
            if (intentos == 3)
            {
                button1.Enabled = false;
                MessageBox.Show("Ha sobrepasado la cantidad permitida de intentos de login");
                query = "update ASSASSINS.Usuario set Usuario_Habilitado=false where Usuario_Username='" + textUsuario.Text + "'";
                try
                {
                    ejecutar(query);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
        void ejecutar(string query)
        {
            SqlConnection conexion = new SqlConnection(conex);
            DataSet dataset = new DataSet();
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);

            conexion.Open();
            adapter.Fill(dataset);
            conexion.Close();
        }

        void Consultar(string query)
        {
            SqlConnection conexion = new SqlConnection(conex);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {

                if (leer.GetBoolean(4) == true && leer.GetDecimal(5) < 3) // Habría que poner a lo último intentos_fallidos
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    MessageBox.Show("El usuario esta deshabilitado");

                }
            }
            conexion.Close();
        }
    }
}
