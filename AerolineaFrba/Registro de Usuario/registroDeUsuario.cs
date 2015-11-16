﻿using System;
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

        static string sha256Encrypt(string password)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private void registroDeUsuario_Load(object sender, EventArgs e)
        {

        }

        decimal intentos = 0;
        bool ok = false;
        string query;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text.Length > 0 && textPass.Text.Length > 0)
            {
                query = "select * from ASSASSINS.Usuario where Usuario_Username='" + textUsuario.Text + "'";
                string sha256Str = sha256Encrypt(textPass.Text);
                query = query + " and Usuario_password='" + sha256Str + "'";

                try
                {
                    consultar(query);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
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
                }
                else
                {
                    intentos = intentos + 1;
                    MessageBox.Show("Fallo de login");
                    query = "update ASSASSINS.Usuario set Usuario_Intentos=Usuario_Intentos+1 where Usuario_Username='" + textUsuario.Text + "'";
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
                MessageBox.Show("Todos los campos son obligatorios");
            }
            if (intentos == 3)
            {
                button1.Enabled = false;
                MessageBox.Show("Ha sobrepasado la cantidad permitida de intentos de login");
                query = "update ASSASSINS.Usuario set Usuario_Habilitado=0 where Usuario_Username='" + textUsuario.Text + "'";
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
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            DataSet dataset = new DataSet();
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);

            conexion.Open();
            adapter.Fill(dataset);
            conexion.Close();
        }

        void consultar(string query)
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {

                if (leer.GetSqlBoolean(4) == true)
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
