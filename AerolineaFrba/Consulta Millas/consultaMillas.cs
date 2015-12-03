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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class consultaMillas : Form
    {
        public consultaMillas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string query;

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                query = "SELECT m.* FROM ASSASSINS.Millas m, ASSASSINS.Cliente c WHERE m.Cliente_ID=c.Cliente_ID"+
                " AND c.Cliente_DNI=" + textBox1.Text + " AND DATEDIFF (day , m.Fecha , getdate())<365";

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
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI");
            }

        }

        private void consultaMillas_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
