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
            this.buttonAltaAero.Location = new System.Drawing.Point(64, 123);
            this.buttonAltaAero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAltaAero.Name = "buttonAltaAero";
            this.buttonAltaAero.Size = new System.Drawing.Size(69, 31);
            this.buttonAltaAero.TabIndex = 0;
            this.buttonAltaAero.Text = "Alta";
            this.buttonAltaAero.UseVisualStyleBackColor = true;
            this.buttonAltaAero.Click += new System.EventHandler(this.buttonAltaAero_Click);
            // 
            // buttonBajaAero
            // 
            this.buttonBajaAero.Location = new System.Drawing.Point(162, 123);
            this.buttonBajaAero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBajaAero.Name = "buttonBajaAero";
            this.buttonBajaAero.Size = new System.Drawing.Size(69, 31);
            this.buttonBajaAero.TabIndex = 3;
            this.buttonBajaAero.Text = "Baja";
            this.buttonBajaAero.UseVisualStyleBackColor = true;
            this.buttonBajaAero.Click += new System.EventHandler(this.buttonBajaAero_Click);
            // 
            // buttonModificacionAero
            // 
            this.buttonModificacionAero.Location = new System.Drawing.Point(262, 123);
            this.buttonModificacionAero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModificacionAero.Name = "buttonModificacionAero";
            this.buttonModificacionAero.Size = new System.Drawing.Size(73, 31);
            this.buttonModificacionAero.TabIndex = 4;
            this.buttonModificacionAero.Text = "Modificación";
            this.buttonModificacionAero.UseVisualStyleBackColor = true;
            this.buttonModificacionAero.Click += new System.EventHandler(this.buttonModificacionAero_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "ABM de Aeronaves";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // abmAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(387, 244);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModificacionAero);
            this.Controls.Add(this.buttonBajaAero);
            this.Controls.Add(this.buttonAltaAero);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "abmAeronave";
            this.Text = "ABM de Aeronaves";
            this.Load += new System.EventHandler(this.abmAeronave_Load);
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