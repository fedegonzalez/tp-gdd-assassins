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

        bool flag = false;

        public void set()
        {
            flag = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Rol.modifRol abrir = new Abm_Rol.modifRol();
            abrir.Show();
            abrir.idText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            if (flag) abrir.block();
        }

        string query;
        
        private void modificacionListadoRol_Load(object sender, EventArgs e)
        {
            query = "select * from ASSASSINS.Rol";
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
