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

namespace AerolineaFrba.Canje_Millas
{
    public partial class canjeMillas : Form
    {
        public canjeMillas()
        {
            InitializeComponent();
        }

        bool ok = false;

        private void button2_Click(object sender, EventArgs e)
        {
            bool textbox = this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text));
            if (!textbox)
            {
                try
                {
                    consultar();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                if (ok == true)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                        using (SqlCommand comando = connection.CreateCommand())
                        {

                            comando.CommandText = "EXEC ASSASSINS.CanjeMillas @clieID=@clieID, @prodID=@prodID, @fecha=@fecha, @cant=@cantidad";

                            comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                            comando.Parameters.AddWithValue("@clieID", textBox1.Text);
                            comando.Parameters.AddWithValue("@prodID", textBox4.Text);
                            comando.Parameters.AddWithValue("@cantidad", textBox3.Text);

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
            else
            {
                MessageBox.Show("Faltan datos");
            }
        }

        void consultar()
        {
            string query = "SELECT Stock, Precio_Millas FROM ASSASSINS.Productos WHERE Productos_ID=" + textBox4.Text;
            string query2 = "SELECT SUM(Millas) FROM ASSASSINS.Millas WHERE Cliente_ID=" + textBox1.Text;

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlConnection conexion2 = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlCommand comando2 = new SqlCommand(query2, conexion2);
            conexion.Open();
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();
            SqlDataReader leer2 = comando2.ExecuteReader();

            if (leer.Read() == true && leer2.Read() == true)
            {

                if (leer.GetSqlDecimal(0) < Convert.ToDecimal(textBox3.Text))
                {
                    ok = false;
                    MessageBox.Show("No hay suficiente stock");
                }
                else if (leer.GetSqlDecimal(1) * Convert.ToDecimal(textBox3.Text) > leer2.GetSqlDecimal(0))
                {
                    ok = false;
                    MessageBox.Show("No tiene suficientes millas");
                }
                else
                {
                    ok = true;
                }
            }
            conexion.Close();
            conexion2.Close();
        }

                public string idText
                {
                    get
                    {
                        return this.textBox1.Text;
                    }
                    set
                    {
                        this.textBox1.Text = value;
                    }
                }

                public string prod
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

        private void button4_Click(object sender, EventArgs e)
        {
            Canje_Millas.listadoClientes abrir = new Canje_Millas.listadoClientes(this);
            abrir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Canje_Millas.listadoProductos abrir = new Canje_Millas.listadoProductos(this);
            abrir.Show();
        }
    }
}
