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
    public partial class compra : Form
    {
        public compra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Compra.datosDelCliente abrir = new Compra.datosDelCliente();
            abrir.Show();
            this.Hide();
        }

        private void compra_Load(object sender, EventArgs e)
        {
            string conex = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
            string query = "select Ciudad_Nombre from ASSASSINS.Ciudad";
            SqlConnection conexion = new SqlConnection(conex);
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                comboBox1.Items.Add(leer[0]);
                comboBox2.Items.Add(leer[0]);
            }
            conexion.Close();
        }
    }
}
