namespace AerolineaFrba.Abm_Ciudad
{
    partial class abmCiudad
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
            this.buttonModificacionCiu = new System.Windows.Forms.Button();
            this.buttonBajaCiu = new System.Windows.Forms.Button();
            this.buttonAltaCiu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonModificacionCiu
            // 
            this.buttonModificacionCiu.Location = new System.Drawing.Point(347, 160);
            this.buttonModificacionCiu.Name = "buttonModificacionCiu";
            this.buttonModificacionCiu.Size = new System.Drawing.Size(97, 38);
            this.buttonModificacionCiu.TabIndex = 7;
            this.buttonModificacionCiu.Text = "Modificación";
            this.buttonModificacionCiu.UseVisualStyleBackColor = true;
            this.buttonModificacionCiu.Click += new System.EventHandler(this.buttonModificacionCiu_Click);
            // 
            // buttonBajaCiu
            // 
            this.buttonBajaCiu.Location = new System.Drawing.Point(223, 160);
            this.buttonBajaCiu.Name = "buttonBajaCiu";
            this.buttonBajaCiu.Size = new System.Drawing.Size(92, 38);
            this.buttonBajaCiu.TabIndex = 6;
            this.buttonBajaCiu.Text = "Baja";
            this.buttonBajaCiu.UseVisualStyleBackColor = true;
            this.buttonBajaCiu.Click += new System.EventHandler(this.buttonBajaCiu_Click);
            // 
            // buttonAltaCiu
            // 
            this.buttonAltaCiu.Location = new System.Drawing.Point(90, 160);
            this.buttonAltaCiu.Name = "buttonAltaCiu";
            this.buttonAltaCiu.Size = new System.Drawing.Size(92, 38);
            this.buttonAltaCiu.TabIndex = 5;
            this.buttonAltaCiu.Text = "Alta";
            this.buttonAltaCiu.UseVisualStyleBackColor = true;
            this.buttonAltaCiu.Click += new System.EventHandler(this.buttonAltaCiu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "ABM de Ciudades";
            // 
            // abmCiudad
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(516, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonModificacionCiu);
            this.Controls.Add(this.buttonBajaCiu);
            this.Controls.Add(this.buttonAltaCiu);
            this.Name = "abmCiudad";
            this.Text = "ABM de Ciudades";
            this.Load += new System.EventHandler(this.abmCiudad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModificacionCiu;
        private System.Windows.Forms.Button buttonBajaCiu;
        private System.Windows.Forms.Button buttonAltaCiu;
        private System.Windows.Forms.Label label2;
    }
}