namespace AerolineaFrba.Abm_Rol
{
    partial class abmRol
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
            this.buttonModificacionRol = new System.Windows.Forms.Button();
            this.buttonBajaRol = new System.Windows.Forms.Button();
            this.buttonAltaRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "ABM de Roles";
            // 
            // buttonModificacionRol
            // 
            this.buttonModificacionRol.Location = new System.Drawing.Point(254, 135);
            this.buttonModificacionRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModificacionRol.Name = "buttonModificacionRol";
            this.buttonModificacionRol.Size = new System.Drawing.Size(73, 31);
            this.buttonModificacionRol.TabIndex = 11;
            this.buttonModificacionRol.Text = "Modificación";
            this.buttonModificacionRol.UseVisualStyleBackColor = true;
            this.buttonModificacionRol.Click += new System.EventHandler(this.buttonModificacionRol_Click);
            // 
            // buttonBajaRol
            // 
            this.buttonBajaRol.Location = new System.Drawing.Point(160, 135);
            this.buttonBajaRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBajaRol.Name = "buttonBajaRol";
            this.buttonBajaRol.Size = new System.Drawing.Size(69, 31);
            this.buttonBajaRol.TabIndex = 10;
            this.buttonBajaRol.Text = "Baja";
            this.buttonBajaRol.UseVisualStyleBackColor = true;
            this.buttonBajaRol.Click += new System.EventHandler(this.buttonBajaRol_Click);
            // 
            // buttonAltaRol
            // 
            this.buttonAltaRol.Location = new System.Drawing.Point(61, 135);
            this.buttonAltaRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAltaRol.Name = "buttonAltaRol";
            this.buttonAltaRol.Size = new System.Drawing.Size(69, 31);
            this.buttonAltaRol.TabIndex = 9;
            this.buttonAltaRol.Text = "Alta";
            this.buttonAltaRol.UseVisualStyleBackColor = true;
            this.buttonAltaRol.Click += new System.EventHandler(this.buttonAltaRol_Click);
            // 
            // abmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(387, 244);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonModificacionRol);
            this.Controls.Add(this.buttonBajaRol);
            this.Controls.Add(this.buttonAltaRol);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "abmRol";
            this.Text = "ABM de Roles";
            this.Load += new System.EventHandler(this.abmRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonModificacionRol;
        private System.Windows.Forms.Button buttonBajaRol;
        private System.Windows.Forms.Button buttonAltaRol;
    }
}