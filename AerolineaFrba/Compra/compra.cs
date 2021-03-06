﻿using System;
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
        public compra(bool soloTarjeta)
        {
            InitializeComponent();
            tarjeta = soloTarjeta;
        }

        bool tarjeta;

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
            Compra.listadoViajes abrir = new Compra.listadoViajes(this, textBox1.Text, comboBox1.Text, comboBox2.Text);
            abrir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pasaje, encomienda;
            bool isNumeric = int.TryParse(textBox2.Text, out pasaje);
            bool isNumeric2 = int.TryParse(textBox3.Text, out encomienda);
            int butacas = int.Parse(label4.Text);
            int kgs = int.Parse(label9.Text);

            if (isNumeric && isNumeric2)
            {
                if (butacas>pasaje && kgs>encomienda)
                {
                    int viaje = Int32.Parse(textBox4.Text);

                    Compra.datosDelCliente abrir = new Compra.datosDelCliente(viaje, pasaje, encomienda, null, null, true, tarjeta);
                    abrir.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("No hay tantos pasajes/kgs disponibles");
                } 
            }
            else
            {
                MessageBox.Show("Por favor, ingrese números");
            }
        }

        public string viaje
        {
            get
            {
                return this.textBox4.Text;
            }
            set
            {
                this.textBox4.Text = value;
            }
        }

        public string butaca
        {
            get
            {
                return this.label4.Text;
            }
            set
            {
                this.label4.Text = value;
            }
        }

        public string kg
        {
            get
            {
                return this.label9.Text;
            }
            set
            {
                this.label9.Text = value;
            }
        }

        private void compra_Load(object sender, EventArgs e)
        {
            string query = "select Ciudad_Nombre from ASSASSINS.Ciudad";
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.dbConnection);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
            {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                button3.Enabled = true;
            }

            if (textBox3.Text == "" || textBox2.Text == "")
            {
                button3.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                button3.Enabled = true;
            }
            
            if (textBox3.Text == "" || textBox2.Text == "")
            {
                button3.Enabled = false;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
