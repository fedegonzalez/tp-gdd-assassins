namespace AerolineaFrba.Abm_Aeronave
{
    partial class abmAeronave
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
            this.buttonAltaAero = new System.Windows.Forms.Button();
            this.buttonBajaAero = new System.Windows.Forms.Button();
            this.buttonModificacionAero = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAltaAero
            // 
            this.buttonAltaAero.Location = new System.Drawing.Point(85, 151);
            this.buttonAltaAero.Name = "buttonAltaAero";
            this.buttonAltaAero.Size = new System.Drawing.Size(92, 38);
            this.buttonAltaAero.TabIndex = 0;
            this.buttonAltaAero.Text = "Alta";
            this.buttonAltaAero.UseVisualStyleBackColor = true;
            this.buttonAltaAero.Click += new System.EventHandler(this.buttonAltaAero_Click);
            // 
            // buttonBajaAero
            // 
            this.buttonBajaAero.Location = new System.Drawing.Point(216, 151);
            this.buttonBajaAero.Name = "buttonBajaAero";
            this.buttonBajaAero.Size = new System.Drawing.Size(92, 38);
            this.buttonBajaAero.TabIndex = 3;
            this.buttonBajaAero.Text = "Baja";
            this.buttonBajaAero.UseVisualStyleBackColor = true;
            this.buttonBajaAero.Click += new System.EventHandler(this.buttonBajaAero_Click);
            // 
            // buttonModificacionAero
            // 
            this.buttonModificacionAero.Location = new System.Drawing.Point(349, 151);
            this.buttonModificacionAero.Name = "buttonModificacionAero";
            this.buttonModificacionAero.Size = new System.Drawing.Size(97, 38);
            this.buttonModificacionAero.TabIndex = 4;
            this.buttonModificacionAero.Text = "Modificación";
            this.buttonModificacionAero.UseVisualStyleBackColor = true;
            this.buttonModificacionAero.Click += new System.EventHandler(this.buttonModificacionAero_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "ABM de Aeronaves";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // abmAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(516, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModificacionAero);
            this.Controls.Add(this.buttonBajaAero);
            this.Controls.Add(this.buttonAltaAero);
            this.Name = "abmAeronave";
            this.Text = "ABM de Aeronaves";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAltaAero;
        private System.Windows.Forms.Button buttonBajaAero;
        private System.Windows.Forms.Button buttonModificacionAero;
        private System.Windows.Forms.Label label1;
    }
}