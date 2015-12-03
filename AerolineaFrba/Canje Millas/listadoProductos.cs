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
    public partial class listadoProductos : Form
    {
        public listadoProductos()
        {
            InitializeComponent();
        }

        string query;

        private void listadoProductos_Load(object sender, EventArgs e)
        {
            query = "SELECT Productos_ID, Descripcion FROM ASSASSINS.Productos WHERE Stock > 0";

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
