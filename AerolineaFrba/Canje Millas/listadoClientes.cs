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

namespace AerolineaFrba.Canje_Millas
{
    public partial class listadoClientes : Form
    {
        public listadoClientes()
        {
            InitializeComponent();
        }

        string query;

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM ASSASSINS.Cliente WHERE Cliente_DNI=" + textBoxRol.Text;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Canje_Millas.canjeMillas abrir = new Canje_Millas.canjeMillas();
            abrir.Show();
            abrir.idText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
        }
    }
}
