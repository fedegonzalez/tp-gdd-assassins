namespace AerolineaFrba
{
    partial class Inicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accesoAAdministradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalKioscoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accesoAAdministradoresToolStripMenuItem,
            this.terminalKioscoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(598, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accesoAAdministradoresToolStripMenuItem
            // 
            this.accesoAAdministradoresToolStripMenuItem.Name = "accesoAAdministradoresToolStripMenuItem";
            this.accesoAAdministradoresToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.accesoAAdministradoresToolStripMenuItem.Text = "Acceso a Administradores";
            this.accesoAAdministradoresToolStripMenuItem.Click += new System.EventHandler(this.accesoAAdministradoresToolStripMenuItem_Click);
            // 
            // terminalKioscoToolStripMenuItem
            // 
            this.terminalKioscoToolStripMenuItem.Name = "terminalKioscoToolStripMenuItem";
            this.terminalKioscoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.terminalKioscoToolStripMenuItem.Text = "Terminal Kiosco";
            this.terminalKioscoToolStripMenuItem.Click += new System.EventHandler(this.terminalKioscoToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(598, 386);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Inicio";
            this.Text = "Sistema de Pasajes";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accesoAAdministradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminalKioscoToolStripMenuItem;
    }
}