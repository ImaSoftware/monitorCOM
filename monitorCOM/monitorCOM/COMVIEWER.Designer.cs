namespace monitorCOM
{
    partial class COMVIEWER
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMVIEWER));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPuertos = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_LW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgAuto = new System.Windows.Forms.ImageList(this.components);
            this.btnConfPort = new System.Windows.Forms.Button();
            this.imgBtn = new System.Windows.Forms.ImageList(this.components);
            this.btnReadPort = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_stop = new System.Windows.Forms.Button();
            this.b_play = new System.Windows.Forms.Button();
            this.maintimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblRun = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuertos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lectura de Puertos Seriales ";
            // 
            // dgvPuertos
            // 
            this.dgvPuertos.AllowUserToAddRows = false;
            this.dgvPuertos.AllowUserToDeleteRows = false;
            this.dgvPuertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuertos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Nombre,
            this.col_Status,
            this.col_LW,
            this.col_MSJ});
            this.dgvPuertos.Location = new System.Drawing.Point(15, 63);
            this.dgvPuertos.Name = "dgvPuertos";
            this.dgvPuertos.ReadOnly = true;
            this.dgvPuertos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuertos.Size = new System.Drawing.Size(895, 324);
            this.dgvPuertos.TabIndex = 2;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "Id";
            this.col_ID.HeaderText = "id";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            // 
            // col_Nombre
            // 
            this.col_Nombre.DataPropertyName = "Nombre";
            this.col_Nombre.HeaderText = "Nombre";
            this.col_Nombre.Name = "col_Nombre";
            this.col_Nombre.ReadOnly = true;
            // 
            // col_Status
            // 
            this.col_Status.DataPropertyName = "Status";
            this.col_Status.HeaderText = "Estatus";
            this.col_Status.Name = "col_Status";
            this.col_Status.ReadOnly = true;
            // 
            // col_LW
            // 
            this.col_LW.DataPropertyName = "UltimaEscritura";
            this.col_LW.HeaderText = "UltimaLectura";
            this.col_LW.Name = "col_LW";
            this.col_LW.ReadOnly = true;
            // 
            // col_MSJ
            // 
            this.col_MSJ.DataPropertyName = "mensaje";
            this.col_MSJ.HeaderText = "Mensaje";
            this.col_MSJ.Name = "col_MSJ";
            this.col_MSJ.ReadOnly = true;
            // 
            // imgAuto
            // 
            this.imgAuto.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAuto.ImageStream")));
            this.imgAuto.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAuto.Images.SetKeyName(0, "s_pause.png");
            this.imgAuto.Images.SetKeyName(1, "s_play.png");
            this.imgAuto.Images.SetKeyName(2, "s_stop.png");
            // 
            // btnConfPort
            // 
            this.btnConfPort.ImageKey = "s_conf.png";
            this.btnConfPort.ImageList = this.imgBtn;
            this.btnConfPort.Location = new System.Drawing.Point(570, 399);
            this.btnConfPort.Name = "btnConfPort";
            this.btnConfPort.Size = new System.Drawing.Size(164, 74);
            this.btnConfPort.TabIndex = 3;
            this.btnConfPort.Text = "Configurar";
            this.btnConfPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfPort.UseVisualStyleBackColor = true;
            // 
            // imgBtn
            // 
            this.imgBtn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBtn.ImageStream")));
            this.imgBtn.TransparentColor = System.Drawing.Color.Transparent;
            this.imgBtn.Images.SetKeyName(0, "s_conf.png");
            this.imgBtn.Images.SetKeyName(1, "s_read.png");
            this.imgBtn.Images.SetKeyName(2, "s_close.png");
            this.imgBtn.Images.SetKeyName(3, "s_open.png");
            // 
            // btnReadPort
            // 
            this.btnReadPort.ImageKey = "s_read.png";
            this.btnReadPort.ImageList = this.imgBtn;
            this.btnReadPort.Location = new System.Drawing.Point(744, 399);
            this.btnReadPort.Name = "btnReadPort";
            this.btnReadPort.Size = new System.Drawing.Size(164, 74);
            this.btnReadPort.TabIndex = 4;
            this.btnReadPort.Text = "Leer";
            this.btnReadPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReadPort.UseVisualStyleBackColor = true;
            this.btnReadPort.Click += new System.EventHandler(this.btnReadPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.ImageKey = "s_close.png";
            this.btnClosePort.ImageList = this.imgBtn;
            this.btnClosePort.Location = new System.Drawing.Point(396, 399);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(164, 74);
            this.btnClosePort.TabIndex = 5;
            this.btnClosePort.Text = "Cerrar";
            this.btnClosePort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.ImageKey = "s_open.png";
            this.btnOpenPort.ImageList = this.imgBtn;
            this.btnOpenPort.Location = new System.Drawing.Point(222, 399);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(164, 74);
            this.btnOpenPort.TabIndex = 6;
            this.btnOpenPort.Text = "Abir";
            this.btnOpenPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.lblStop);
            this.groupBox1.Controls.Add(this.lblRun);
            this.groupBox1.Controls.Add(this.b_stop);
            this.groupBox1.Controls.Add(this.b_play);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automático";
            // 
            // b_stop
            // 
            this.b_stop.ImageKey = "s_stop.png";
            this.b_stop.ImageList = this.imgAuto;
            this.b_stop.Location = new System.Drawing.Point(68, 18);
            this.b_stop.Name = "b_stop";
            this.b_stop.Size = new System.Drawing.Size(56, 56);
            this.b_stop.TabIndex = 8;
            this.b_stop.UseVisualStyleBackColor = true;
            this.b_stop.Click += new System.EventHandler(this.b_stop_Click);
            // 
            // b_play
            // 
            this.b_play.ImageKey = "s_play.png";
            this.b_play.ImageList = this.imgAuto;
            this.b_play.Location = new System.Drawing.Point(6, 18);
            this.b_play.Name = "b_play";
            this.b_play.Size = new System.Drawing.Size(56, 56);
            this.b_play.TabIndex = 8;
            this.b_play.UseVisualStyleBackColor = true;
            this.b_play.Click += new System.EventHandler(this.b_play_Click);
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.BackColor = System.Drawing.Color.Black;
            this.lblRun.ForeColor = System.Drawing.Color.Lime;
            this.lblRun.Location = new System.Drawing.Point(130, 28);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(52, 13);
            this.lblRun.TabIndex = 8;
            this.lblRun.Text = "Corriendo";
            this.lblRun.Visible = false;
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStop.ForeColor = System.Drawing.Color.Red;
            this.lblStop.Location = new System.Drawing.Point(130, 52);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(50, 13);
            this.lblStop.TabIndex = 8;
            this.lblStop.Text = "Detenido";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(5, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 90);
            this.panel1.TabIndex = 8;
            // 
            // COMVIEWER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnReadPort);
            this.Controls.Add(this.btnConfPort);
            this.Controls.Add(this.dgvPuertos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "COMVIEWER";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuertos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPuertos;
        private System.Windows.Forms.ImageList imgAuto;
        private System.Windows.Forms.Button btnConfPort;
        private System.Windows.Forms.Button btnReadPort;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_stop;
        private System.Windows.Forms.Button b_play;
        private System.Windows.Forms.Timer maintimer;
        private System.Windows.Forms.ImageList imgBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_LW;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MSJ;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Panel panel1;
    }
}

