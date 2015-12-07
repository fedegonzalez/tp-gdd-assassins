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

namespace AerolineaFrba.Listado_Estadistico
{
    partial class listadoEstadistico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.FormattingEnabled = true;
            var itemsFechas = new[] {new { Text = "1-2016", Value = "1" },
            new { Text = "2-2016", Value = "2" },
            new { Text = "1-2017", Value = "3" },
            new { Text = "2-2017", Value = "4" }
            };
            this.comboBoxRol.Location = new System.Drawing.Point(417, 107);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRol.TabIndex = 23;
            this.comboBoxRol.DisplayMember = "Text";
            this.comboBoxRol.ValueMember = "Value";
            this.comboBoxRol.DataSource = itemsFechas;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Seleccione Semestre y Año";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 265);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(946, 473);
            this.dataGridView1.TabIndex = 25;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(358, 206);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(104, 40);
            this.buttonBuscar.TabIndex = 24;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(281, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 32);
            this.label7.TabIndex = 51;
            this.label7.Text = "Listado Estadístico";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            var items = new[] {new { Text = "Top 5 de los destinos con más pasajes comprados", Value = "1" },
            new { Text = "Top 5 de los destinos con aeronaves más vacías", Value = "2" },
            new { Text = "Top 5 de los Clientes con más puntos acumulados a la fecha", Value = "3" },
            new { Text = "Top 5 de los destinos con pasajes cancelado", Value = "4" },
            new { Text = "Top 5 de las aeronaves con mayor cantidad de días fuera de servicio", Value = "5" }
            };  
            this.comboBox1.Location = new System.Drawing.Point(417, 153);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(450, 24);
            this.comboBox1.TabIndex = 53;
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            this.comboBox1.DataSource = items;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Seleccione Listado";
            // 
            // listadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(988, 747);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonBuscar);
            this.Name = "listadoEstadistico";
            this.Text = "Listado Estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            String valueCombo = comboBox1.SelectedValue.ToString();
            String valueFecha = comboBoxRol.Text.ToString();
            String[] valuesFecha = valueFecha.Split('-');
            String semestre = valuesFecha[0];
            String año = valuesFecha[1];
            String query = "";
            int range1;
            int range2;

            if (semestre == "1")
            {
                range1 = 1;
                range2 = 6;
            }
            else
            {
                range1 = 7;
                range2 = 12;
            }

            if (valueCombo == "1")
            {
                query = "select top 5 ci.Ciudad_Nombre as Ciudad from ASSASSINS.Pasaje pas join ASSASSINS.Viaje vi on vi.Viaje_ID = pas.Viaje_ID " +
                        "join ASSASSINS.Ruta ru on vi.Ruta_ID = ru.Ruta_ID join ASSASSINS.Ciudad ci on ci.Ciudad_ID = ru.Ruta_Ciudad_Destino " + "where month(vi.Viaje_Fecha_Salida) between " + range1 + " and " + range2 + " and year(vi.Viaje_Fecha_Salida) = " + año + " group by ru.Ruta_Ciudad_Destino,ci.Ciudad_Nombre order by COUNT(*) desc";
            }
            else if (valueCombo == "2")
            {
                query = "select top 5 ci.Ciudad_Nombre as Ciudad from ASSASSINS.Viaje vi "
                +" join ASSASSINS.Aeronave aero on aero.Aeronave_Numero = vi.Aeronave_Numero"
                +" join ASSASSINS.Pasaje pas on pas.Viaje_ID = vi.Viaje_ID"
                +" join ASSASSINS.Ruta ru on vi.Ruta_ID = ru.Ruta_ID "
                +" join ASSASSINS.Ciudad ci on ci.Ciudad_ID = ru.Ruta_Ciudad_Destino "
                +"where month(vi.Viaje_Fecha_Salida) between " + range1 + " and " + range2 + " and year(vi.Viaje_Fecha_Salida) = " + año 
                + " group by ci.Ciudad_Nombre"
                +" order by COUNT(pas.Viaje_ID) asc";
            }
            else if (valueCombo == "3")
            {
                query = "select top 5 mi.Cliente_ID as cliente_ID, SUM(mi.millas) as millas, cli.Cliente_Apellido as Apellido, cli.Cliente_Nombre as Nombre, cli.Cliente_DNI as DNI from ASSASSINS.Millas mi"
                       + " join ASSASSINS.Cliente cli on cli.Cliente_ID = mi.Cliente_ID"
                       + " where month(mi.Fecha) between " + range1 + " and " + range2 + " and year(mi.Fecha) = " + año
                       + " group by mi.Cliente_ID, cli.Cliente_Apellido, cli.Cliente_Nombre, cli.Cliente_DNI"
                       + " order by SUM(mi.millas) desc";

            }
            else if (valueCombo == "4")
            {
                query = "select top 5 ci.Ciudad_Nombre as Ciudad from ASSASSINS.Viaje vi"
              + " join ASSASSINS.Pasaje pas on pas.Viaje_ID = vi.Viaje_ID"
              + " join ASSASSINS.Ruta ru on vi.Ruta_ID = ru.Ruta_ID"
              + " join ASSASSINS.Ciudad ci on ci.Ciudad_ID = ru.Ruta_Ciudad_Destino"
              + " join ASSASSINS.Devolucion_Pasaje devpas on devpas.Pasaje_ID = pas.Pasaje_ID"
              + " where month(vi.Viaje_Fecha_Salida) between " + range1 + " and " + range2 + " and year(vi.Viaje_Fecha_Salida) = " + año
              + " group by ci.Ciudad_Nombre"
              + " order by COUNT(devpas.Pasaje_ID) desc";
            }
            else if (valueCombo == "5")
            {
                query = "select  top 5 aero.Aeronave_Numero as Aeronave from ASSASSINS.Aeronave aero"
                        +" join ASSASSINS.Baja_Servicio baja on baja.Aeronave_Numero = aero.Aeronave_Numero"
                        + " where month(baja.Aeronave_Fecha_Fuera_Servicio) between " + range1 + " and " + range2 + " and year(baja.Aeronave_Fecha_Fuera_Servicio) = " + año
                        +" group by aero.Aeronave_Numero, baja.Aeronave_Fecha_Fuera_Servicio, baja.Aeronave_Fecha_Reinicio_Servicio"
                        +" order by DATEDIFF(day, baja.Aeronave_Fecha_Fuera_Servicio, baja.Aeronave_Fecha_Reinicio_Servicio) desc";
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
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}