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

namespace AerolineaFrba.Compra
{
    public partial class listadoViajes : Form
    {
        public listadoViajes(Compra.compra form, string fecha, string origen, string destino)
        {
            InitializeComponent();
            _form1 = form;
            fechasql = fecha;
            cOrigen = origen;
            cDestino = destino;
        }

        public compra _form1;
        string fechasql;
        string cOrigen;
        string cDestino;

        private void listadoViajes_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ASSASSINS.Viaje";

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
            _form1.viaje = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            this.Hide();
        }
    }
}
