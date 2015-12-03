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
            this.comboBoxRol.Items.AddRange(new object[] {
            "1-2016",
            "2-2016",
            "1-2017",
            "2-2017"});
            this.comboBoxRol.Location = new System.Drawing.Point(417, 107);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRol.TabIndex = 23;
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
            this.comboBox1.Items.AddRange(new object[] {
            "Top 5 de los destinos con más pasajes comprados",
            "Top 5 de los destinos con aeronaves más vacías",
            "Top 5 de los Clientes con más puntos acumulados a la fecha",
            "Top 5 de los destinos con pasajes cancelado",
            "Top 5 de las aeronaves con mayor cantidad de días fuera de servicio"});
            this.comboBox1.Location = new System.Drawing.Point(417, 153);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(225, 24);
            this.comboBox1.TabIndex = 53;
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
    }
}