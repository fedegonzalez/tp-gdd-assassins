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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class listadoAeronaves : Form
    {
        public listadoAeronaves(generacionViaje form)
        {
            InitializeComponent();
            _form1 = form;
        }

        public generacionViaje _form1;

        string query;

        private void listadoAeronaves_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Habilitado=1";

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
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _form1.aeronave = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            this.Hide();
        }
    }
}
