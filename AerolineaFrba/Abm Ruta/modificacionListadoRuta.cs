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
    public partial class modificacionListadoRuta : Form
    {
        public modificacionListadoRuta()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Ruta.modifRuta abrir = new Abm_Ruta.modifRuta();
            abrir.Show();
            abrir.idText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            this.Hide();
        }

        string query;

        public string idText
        {
            get
            {
                return this.textBoxSelecRol.Text;
            }
            set
            {
                this.textBoxSelecRol.Text = value;
            }
        }

        private void modificacionListadoRuta_Load(object sender, EventArgs e)
        {

        }

        private void textBoxParteRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Ruta.modificacionListadoRuta2 abrir = new Abm_Ruta.modificacionListadoRuta2();
            abrir.Show();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxRol.Text != "" && textBoxSelecRol.Text == "")
            {
                query = "SELECT * FROM ASSASSINS.Ruta WHERE Ruta_ID=" + textBoxRol.Text;
            }
            else
            {
                query = "SELECT * FROM ASSASSINS.Ruta WHERE Ruta_ID=" + textBoxSelecRol.Text;
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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxRol.Text = "";
            textBoxSelecRol.Text = "";
        }
    }
}
