namespace AerolineaFrba
{
    partial class inicioAdministrador
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAeronaves = new System.Windows.Forms.Button();
            this.buttonCiudades = new System.Windows.Forms.Button();
            this.buttonRoles = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAeronaves
            // 
            this.buttonAeronaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAeronaves.Location = new System.Drawing.Point(84, 161);
            this.buttonAeronaves.Name = "buttonAeronaves";
            this.buttonAeronaves.Size = new System.Drawing.Size(104, 48);
            this.buttonAeronaves.TabIndex = 0;
            this.buttonAeronaves.Text = "Aeronaves";
            this.buttonAeronaves.UseVisualStyleBackColor = true;
            this.buttonAeronaves.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCiudades
            // 
            this.buttonCiudades.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCiudades.Location = new System.Drawing.Point(222, 161);
            this.buttonCiudades.Name = "buttonCiudades";
            this.buttonCiudades.Size = new System.Drawing.Size(104, 48);
            this.buttonCiudades.TabIndex = 1;
            this.buttonCiudades.Text = "Ciudades";
            this.buttonCiudades.UseVisualStyleBackColor = true;
            this.buttonCiudades.Click += new System.EventHandler(this.buttonCiudades_Click);
            // 
            // buttonRoles
            // 
            this.buttonRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRoles.Location = new System.Drawing.Point(360, 161);
            this.buttonRoles.Name = "buttonRoles";
            this.buttonRoles.Size = new System.Drawing.Size(104, 48);
            this.buttonRoles.TabIndex = 2;
            this.buttonRoles.Text = "Roles";
            this.buttonRoles.UseVisualStyleBackColor = true;
            this.buttonRoles.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(499, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Rutas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese en la sección que necesite";
            // 
            // inicioAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(704, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRoles);
            this.Controls.Add(this.buttonCiudades);
            this.Controls.Add(this.buttonAeronaves);
            this.Name = "inicioAdministrador";
            this.Text = "Sistema de Pasajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAeronaves;
        private System.Windows.Forms.Button buttonCiudades;
        private System.Windows.Forms.Button buttonRoles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

