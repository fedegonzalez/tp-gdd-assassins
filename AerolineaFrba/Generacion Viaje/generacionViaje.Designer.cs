namespace AerolineaFrba.Generacion_Viaje
{
    partial class generacionViaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGenerarViaje = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.monthCalendarFS = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarFL = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarFLE = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generación de Viajes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(314, 321);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(218, 22);
            this.textBox6.TabIndex = 23;
            this.textBox6.Click += new System.EventHandler(this.textBox6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ruta Aérea";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(314, 275);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(218, 22);
            this.textBox4.TabIndex = 21;
            this.textBox4.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Aeronave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha de Llegada Estimada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha de Llegada";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(93, 22);
            this.textBox1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Fecha de Salida";
            // 
            // buttonGenerarViaje
            // 
            this.buttonGenerarViaje.Location = new System.Drawing.Point(249, 382);
            this.buttonGenerarViaje.Name = "buttonGenerarViaje";
            this.buttonGenerarViaje.Size = new System.Drawing.Size(95, 34);
            this.buttonGenerarViaje.TabIndex = 24;
            this.buttonGenerarViaje.Text = "Generar";
            this.buttonGenerarViaje.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(314, 182);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(93, 22);
            this.textBox2.TabIndex = 25;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(314, 227);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(93, 22);
            this.textBox3.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 22);
            this.button1.TabIndex = 27;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 22);
            this.button2.TabIndex = 28;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(434, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 22);
            this.button3.TabIndex = 29;
            this.button3.Text = "Seleccionar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // monthCalendarFS
            // 
            this.monthCalendarFS.Location = new System.Drawing.Point(564, 29);
            this.monthCalendarFS.Name = "monthCalendarFS";
            this.monthCalendarFS.TabIndex = 30;
            this.monthCalendarFS.Visible = false;
            this.monthCalendarFS.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarFS_DateChanged);
            // 
            // monthCalendarFL
            // 
            this.monthCalendarFL.Location = new System.Drawing.Point(564, 88);
            this.monthCalendarFL.Name = "monthCalendarFL";
            this.monthCalendarFL.TabIndex = 31;
            this.monthCalendarFL.Visible = false;
            this.monthCalendarFL.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarFL_DateChanged);
            // 
            // monthCalendarFLE
            // 
            this.monthCalendarFLE.Location = new System.Drawing.Point(564, 137);
            this.monthCalendarFLE.Name = "monthCalendarFLE";
            this.monthCalendarFLE.TabIndex = 32;
            this.monthCalendarFLE.Visible = false;
            this.monthCalendarFLE.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarFLE_DateChanged);
            // 
            // generacionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(870, 439);
            this.Controls.Add(this.monthCalendarFLE);
            this.Controls.Add(this.monthCalendarFL);
            this.Controls.Add(this.monthCalendarFS);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonGenerarViaje);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "generacionViaje";
            this.Text = "Generación de Viajes";
            this.Load += new System.EventHandler(this.generacionViaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGenerarViaje;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MonthCalendar monthCalendarFS;
        private System.Windows.Forms.MonthCalendar monthCalendarFL;
        private System.Windows.Forms.MonthCalendar monthCalendarFLE;
    }
}