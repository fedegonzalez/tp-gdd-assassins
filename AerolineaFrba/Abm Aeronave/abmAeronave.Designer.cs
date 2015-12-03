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
            this.buttonModificacionAero = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAltaAero
            // 
            this.buttonAltaAero.Location = new System.Drawing.Point(85, 151);
            this.buttonAltaAero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAltaAero.Name = "buttonAltaAero";
            this.buttonAltaAero.Size = new System.Drawing.Size(92, 38);
            this.buttonAltaAero.TabIndex = 0;
            this.buttonAltaAero.Text = "Alta";
            this.buttonAltaAero.UseVisualStyleBackColor = true;
            this.buttonAltaAero.Click += new System.EventHandler(this.buttonAltaAero_Click);
            // 
            // buttonModificacionAero
            // 
            this.buttonModificacionAero.Location = new System.Drawing.Point(325, 151);
            this.buttonModificacionAero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModificacionAero.Name = "buttonModificacionAero";
            this.buttonModificacionAero.Size = new System.Drawing.Size(98, 38);
            this.buttonModificacionAero.TabIndex = 4;
            this.buttonModificacionAero.Text = "Modificación";
            this.buttonModificacionAero.UseVisualStyleBackColor = true;
            this.buttonModificacionAero.Click += new System.EventHandler(this.buttonModificacionAero_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "ABM de Aeronaves";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 151);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Baja";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // abmAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(516, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModificacionAero);
            this.Controls.Add(this.buttonAltaAero);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "abmAeronave";
            this.Text = "ABM de Aeronaves";
            this.Load += new System.EventHandler(this.abmAeronave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAltaAero;
        private System.Windows.Forms.Button buttonModificacionAero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}