namespace AerolineaFrba.Abm_Ruta
{
    partial class abmRuta
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonModificacionRut = new System.Windows.Forms.Button();
            this.buttonBajaRut = new System.Windows.Forms.Button();
            this.buttonAltaRut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "ABM de Rutas";
            // 
            // buttonModificacionRut
            // 
            this.buttonModificacionRut.Location = new System.Drawing.Point(250, 133);
            this.buttonModificacionRut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModificacionRut.Name = "buttonModificacionRut";
            this.buttonModificacionRut.Size = new System.Drawing.Size(73, 31);
            this.buttonModificacionRut.TabIndex = 15;
            this.buttonModificacionRut.Text = "Modificación";
            this.buttonModificacionRut.UseVisualStyleBackColor = true;
            this.buttonModificacionRut.Click += new System.EventHandler(this.buttonModificacionRut_Click);
            // 
            // buttonBajaRut
            // 
            this.buttonBajaRut.Location = new System.Drawing.Point(157, 133);
            this.buttonBajaRut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBajaRut.Name = "buttonBajaRut";
            this.buttonBajaRut.Size = new System.Drawing.Size(69, 31);
            this.buttonBajaRut.TabIndex = 14;
            this.buttonBajaRut.Text = "Baja";
            this.buttonBajaRut.UseVisualStyleBackColor = true;
            this.buttonBajaRut.Click += new System.EventHandler(this.buttonBajaRut_Click);
            // 
            // buttonAltaRut
            // 
            this.buttonAltaRut.Location = new System.Drawing.Point(57, 133);
            this.buttonAltaRut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAltaRut.Name = "buttonAltaRut";
            this.buttonAltaRut.Size = new System.Drawing.Size(69, 31);
            this.buttonAltaRut.TabIndex = 13;
            this.buttonAltaRut.Text = "Alta";
            this.buttonAltaRut.UseVisualStyleBackColor = true;
            this.buttonAltaRut.Click += new System.EventHandler(this.buttonAltaRut_Click);
            // 
            // abmRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(387, 244);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonModificacionRut);
            this.Controls.Add(this.buttonBajaRut);
            this.Controls.Add(this.buttonAltaRut);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "abmRuta";
            this.Text = "ABM de Rutas";
            this.Load += new System.EventHandler(this.abmRuta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonModificacionRut;
        private System.Windows.Forms.Button buttonBajaRut;
        private System.Windows.Forms.Button buttonAltaRut;
    }
}