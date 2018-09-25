namespace monitorCOM
{
    partial class spcnf
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_baud = new System.Windows.Forms.ComboBox();
            this.cb_bits = new System.Windows.Forms.ComboBox();
            this.cb_par = new System.Windows.Forms.ComboBox();
            this.cb_parada = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_hs = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.readTO = new System.Windows.Forms.NumericUpDown();
            this.writeTO = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.readTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeTO)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bits por segundo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bits de datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bits de Parada";
            // 
            // cb_baud
            // 
            this.cb_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_baud.FormattingEnabled = true;
            this.cb_baud.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cb_baud.Location = new System.Drawing.Point(103, 12);
            this.cb_baud.Name = "cb_baud";
            this.cb_baud.Size = new System.Drawing.Size(121, 21);
            this.cb_baud.TabIndex = 1;
            // 
            // cb_bits
            // 
            this.cb_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_bits.FormattingEnabled = true;
            this.cb_bits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cb_bits.Location = new System.Drawing.Point(103, 49);
            this.cb_bits.Name = "cb_bits";
            this.cb_bits.Size = new System.Drawing.Size(121, 21);
            this.cb_bits.TabIndex = 2;
            // 
            // cb_par
            // 
            this.cb_par.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_par.FormattingEnabled = true;
            this.cb_par.Items.AddRange(new object[] {
            "Ninguno",
            "Par ",
            "Impar",
            "Marca",
            "Espacio"});
            this.cb_par.Location = new System.Drawing.Point(103, 86);
            this.cb_par.Name = "cb_par";
            this.cb_par.Size = new System.Drawing.Size(121, 21);
            this.cb_par.TabIndex = 3;
            // 
            // cb_parada
            // 
            this.cb_parada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_parada.FormattingEnabled = true;
            this.cb_parada.Items.AddRange(new object[] {
            "ninguno",
            "uno",
            "dos",
            "uno_y_medio"});
            this.cb_parada.Location = new System.Drawing.Point(103, 123);
            this.cb_parada.Name = "cb_parada";
            this.cb_parada.Size = new System.Drawing.Size(121, 21);
            this.cb_parada.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Handshake";
            // 
            // cb_hs
            // 
            this.cb_hs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_hs.FormattingEnabled = true;
            this.cb_hs.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.cb_hs.Location = new System.Drawing.Point(103, 160);
            this.cb_hs.Name = "cb_hs";
            this.cb_hs.Size = new System.Drawing.Size(121, 21);
            this.cb_hs.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Read Timeout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Write Timeout";
            // 
            // readTO
            // 
            this.readTO.Location = new System.Drawing.Point(103, 197);
            this.readTO.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.readTO.Name = "readTO";
            this.readTO.Size = new System.Drawing.Size(121, 20);
            this.readTO.TabIndex = 6;
            // 
            // writeTO
            // 
            this.writeTO.Location = new System.Drawing.Point(103, 234);
            this.writeTO.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.writeTO.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.writeTO.Name = "writeTO";
            this.writeTO.Size = new System.Drawing.Size(121, 20);
            this.writeTO.TabIndex = 7;
            this.writeTO.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // spcnf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 311);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.writeTO);
            this.Controls.Add(this.readTO);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_hs);
            this.Controls.Add(this.cb_parada);
            this.Controls.Add(this.cb_par);
            this.Controls.Add(this.cb_bits);
            this.Controls.Add(this.cb_baud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "spcnf";
            this.ShowIcon = false;
            this.Text = "Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.spcnf_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.readTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeTO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_baud;
        private System.Windows.Forms.ComboBox cb_bits;
        private System.Windows.Forms.ComboBox cb_par;
        private System.Windows.Forms.ComboBox cb_parada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_hs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown readTO;
        private System.Windows.Forms.NumericUpDown writeTO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}