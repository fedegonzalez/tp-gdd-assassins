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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class modificacionListadoRuta2 : Form
    {
        public modificacionListadoRuta2()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxRol.Text = "";
            textBox1.Text = "";
        }

        string query;

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxRol.Text != "" && textBox1.Text != "")
            {
                query = "select r.* from assassins.ruta r, assassins.ciudad c1, assassins.ciudad c2 " +
                "where r.Ruta_Ciudad_Origen=c1.Ciudad_ID and r.Ruta_Ciudad_Destino=c2.Ciudad_ID " +
                "and c1.Ciudad_Nombre like '%" + textBoxRol.Text + "%' and c2.Ciudad_Nombre like '%" + textBox1.Text + "%'";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Ruta.modificacionListadoRuta abrir = new Abm_Ruta.modificacionListadoRuta();
            abrir.Show();
            abrir.idText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            this.Hide();
        }
    }
}
