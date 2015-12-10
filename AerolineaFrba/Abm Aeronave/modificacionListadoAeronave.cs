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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class modificacionListadoAeronave : Form
    {
        public modificacionListadoAeronave()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Abm_Aeronave.modifAeronaves abrir = new Abm_Aeronave.modifAeronaves();
            abrir.Show();
            int butacas = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value)
            + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value);
            abrir.idText = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            abrir.matricula = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            abrir.fabricante = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            abrir.modelo = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            abrir.tipoServ = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            abrir.kgs = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            abrir.cantButacas = butacas.ToString();
            this.Hide();
        }

        string query;

        private void modificacionListadoAeronave_Load(object sender, EventArgs e)
        {
            query = "select Aeronave_Matricula from ASSASSINS.Aeronave";
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxParteRol.Text = "";
            textBoxRol.Text = "";
            comboBoxRol.Text = "";
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxParteRol.Text != "" && textBoxRol.Text == "" && comboBoxRol.Text == "")
            {
                query = "SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula like '%" + textBoxParteRol.Text + "%'";
            }
            else if (textBoxParteRol.Text == "" && textBoxRol.Text != "" && comboBoxRol.Text == "")
            {
                query = "SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula ='" + textBoxRol.Text + "'";
            }
            else
            {
                query = "SELECT * FROM ASSASSINS.Aeronave WHERE Aeronave_Matricula ='" + comboBoxRol.Text + "'";
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
