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
    public partial class modifRuta : Form
    {
        public modifRuta()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }

        private void modifRuta_Load(object sender, EventArgs e)
        {

        }

        public string idText
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ejecutar();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void ejecutar()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnection))
            using (SqlCommand comando = connection.CreateCommand())
            {
                if (checkBox1.Checked == true)
                {
                    comando.CommandText = "UPDATE ASSASSINS.Ruta SET Ruta_Habilitado=0 WHERE Ruta_ID=@rutaID";

                    comando.Parameters.AddWithValue("@rutaID", textBox1.Text);
                }
                else
                {
                    comando.CommandText = "EXEC ASSASSINS.UpdateRuta @rutaID=@rutaID, @rutaCod=@rutaCod, @precioBaseKG=@precioBaseKG,"+
                    "@precioBasePas=@precioBasePas, @rutaOrigen=@rutaOrigen, @rutaDestino=@rutaDestino, @tipoServ=@tipoServ";

                    comando.Parameters.AddWithValue("@rutaID", textBox1.Text);
                    comando.Parameters.AddWithValue("@rutaCod", textBox2.Text);
                    comando.Parameters.AddWithValue("@precioBasePas", textBox5.Text);
                    comando.Parameters.AddWithValue("@precioBaseKG", textBox6.Text);
                    comando.Parameters.AddWithValue("@rutaOrigen", comboBox1.Text);
                    comando.Parameters.AddWithValue("@rutaDestino", comboBox2.Text);
                    comando.Parameters.AddWithValue("@tipoServ", comboBox3.Text);
                }

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
