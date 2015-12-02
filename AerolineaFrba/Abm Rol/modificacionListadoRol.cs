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

namespace AerolineaFrba.Abm_Rol
{
    public partial class modificacionListadoRol : Form
    {
        public modificacionListadoRol()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxParteRol.Text = "";
            textBoxRol.Text = "";
            comboBoxRol.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Rol.modifRol abrir = new Abm_Rol.modifRol();
            abrir.Show();
        }

        string query;

        private void modificacionListadoRol_Load(object sender, EventArgs e)
        {
            query = "select Rol_Nombre from ASSASSINS.Rol";
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
            query = "select Rol_Nombre from ASSASSINS.Rol";
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBoxRol.Items.Add(leer[0]);
            }
            conexion.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxParteRol.Text != "" && textBoxRol.Text == "" && comboBoxRol.Text == "")
            {
                query = "SELECT * FROM ASSASSINS.Rol WHERE Rol_Nombre like '%" + textBoxParteRol.Text + "%'";
            }
            else if (textBoxParteRol.Text == "" && textBoxRol.Text != "" && comboBoxRol.Text == "")
            {
                query = "SELECT * FROM ASSASSINS.Rol WHERE Rol_Nombre ='" + textBoxRol.Text + "'";
            }
            else
            {
                query = "SELECT * FROM ASSASSINS.Rol WHERE Rol_Nombre ='" + comboBoxRol.Text + "'";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
                using (var command = new SqlCommand(query, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    connection.Open();
                    var myTable = new DataTable();
                    adapter.Fill(myTable);
                    dataGridView1.DataSource = myTable;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
