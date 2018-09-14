using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;

namespace monitorCOM
{
    public partial class COMVIEWER : Form
    {
        List<easyPort> MisPuertos;
        DataTable puertosView;
        class easyPort
        {
           
           
            public delegate void ActualizarEventHandler(Object sender);
            public event ActualizarEventHandler Actualizar;
            public int id = -1;
            public enum status { Error, Open, Closed }
            public int baudrate = 2400;
            public string portName = "";
            public SerialPort spSoft;
            public DateTime ultWrite;
            public status estado;
            public string mesaje = "";
            public Timer timerTabla = new Timer();
            public BackgroundWorker pbw = new BackgroundWorker();
            public easyPort(int xid, string xName = "COM1", int xbaudRate = 2400) {
                id = xid;
                timerTabla.Interval= Convert.ToInt32(Properties.Settings.Default.tiempo);
                timerTabla.Tick += new EventHandler (LeerTabla);
                pbw.DoWork += new DoWorkEventHandler(miBw_DoWork);
                pbw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(miBw_WorkComplete);
                portName = xName;
                spSoft = new SerialPort();
                spSoft.PortName = xName;
                spSoft.BaudRate = xbaudRate;
                spSoft.Parity = Parity.None;
                spSoft.DataBits = 8;
                spSoft.StopBits = StopBits.One ;
                spSoft.Handshake = Handshake.None;
                spSoft.ReadTimeout = 500;
                spSoft.WriteTimeout = 500;
            }
            public void Play() {
                timerTabla.Stop();
                timerTabla.Interval = Convert.ToInt32(Properties.Settings.Default.tiempo);
                timerTabla.Start();
            }
            public void Stop()
            {
                timerTabla.Stop();
            }
            private void LeerTabla(Object sender, EventArgs e) {
                if (pbw.IsBusy) { return; }
                pbw.RunWorkerAsync();
            }
            private void miBw_WorkComplete(object sender, RunWorkerCompletedEventArgs e) {
                Actualizar(this);
            }

            private void miBw_DoWork(object sender, DoWorkEventArgs e)
            {
               string  miconnstr = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
                try
                {
                    using (SqlConnection cn = new SqlConnection(miconnstr))
                    {
                        string sqlLee = @"select ESTACION_R from MONITORCOM_C where ESTACION_W = @miMaquina and PUERTO = @portname and  Leer = cast(1 as bit)";
                        SqlCommand cmd = new SqlCommand(sqlLee, cn);
                        cmd.Parameters.Add("@miMaquina", SqlDbType.VarChar);
                        cmd.Parameters["@miMaquina"].Value = Environment.MachineName;
                        cmd.Parameters.Add("@portname", SqlDbType.VarChar);
                        cmd.Parameters["@portname"].Value = this.portName;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        cn.Open();
                        da.Fill(dt);
                        cn.Close();
                        if (dt.Rows.Count > 0)
                        {
                            if (this.estado != status.Open)
                                this.openPort();
                            this.readPort();
                            decimal valor = 0;
                            Decimal.TryParse(this.mesaje.Substring(1,8), out valor);
                            foreach (DataRow dr in dt.Rows) {
                                string sqlWrite = @"Update MONITORCOM_C set lectura = @val_leido, Leer = cast(0 as bit) where ESTACION_R = @estacion and ESTACION_W = @miMaquina and PUERTO = @portname and  Leer = cast(1 as bit)";
                                cmd = new SqlCommand(sqlWrite, cn);
                                cmd.Parameters.Add("@estacion", SqlDbType.VarChar);
                                cmd.Parameters["@estacion"].Value = dr[0].ToString().Trim();
                                cmd.Parameters.Add("@miMaquina", SqlDbType.VarChar);
                                cmd.Parameters["@miMaquina"].Value = Environment.MachineName;
                                cmd.Parameters.Add("@portname", SqlDbType.VarChar);
                                cmd.Parameters["@portname"].Value = this.portName;
                                cmd.Parameters.Add("@val_leido", SqlDbType.Decimal);
                                cmd.Parameters["@val_leido"].Value = valor;
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                        }
                    }
                  
                }
                catch (Exception ex)
                {
                    this.mesaje = ex.Message;
                    this.Stop();
                }

            }

            public void readPort() {
                
                if (this.estado != status.Open) {
                    this.mesaje = "El puerto no está Abierto";
                    return;
                }
                try
                {
                    try
                    {
                        this.mesaje= spSoft.ReadLine();
                        this.ultWrite = DateTime.Now;
                        
                    }
                    catch (TimeoutException ex)
                    {
                        this.mesaje = ex.Message; this.estado = status.Error;
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    this.mesaje = ex.Message; this.estado = status.Error;
                    //this.closePort();
                }
               
                
            }
            public void openPort()
            {
                try
                {
                    this.spSoft.Open();
                }
                catch (Exception ex)
                {
                    this.mesaje = ex.Message;
                    this.estado = easyPort.status.Error;
                    this.closePort();
                }
                this.estado = easyPort.status.Open;
            }
            public void closePort() {
                try
                {
                    this.spSoft.Close();
                }
                catch (Exception ex)
                {
                    this.mesaje = ex.Message;
                    this.estado = easyPort.status.Error;
                    this.closePort();
                }
                this.estado = easyPort.status.Closed;
            }

        }
        public COMVIEWER()
        {
            InitializeComponent();
            leeSeriales();
        }
        void leeSeriales() {
            MisPuertos = new List<easyPort>();
            string[] ps_Names = SerialPort.GetPortNames();
            int i = 0;
            foreach (string nm in ps_Names)
            {
                easyPort pA = new easyPort(i, nm);
                pA.Actualizar += new easyPort.ActualizarEventHandler(unPuertoLee);
                MisPuertos.Add(pA);
                i += 1;
            }
            ActualizaGRID();
        }
        void unPuertoLee(Object sender) {
            ActualizaGRID();
        }
        void ActualizaGRID() {
            puertosView = new DataTable();
            puertosView.Columns.Add("Id"); puertosView.Columns.Add("Nombre"); puertosView.Columns.Add("Status");
            puertosView.Columns.Add("UltimaEscritura"); puertosView.Columns.Add("mensaje");
            foreach ( easyPort sp in MisPuertos) {
                puertosView.Rows.Add(sp.id, sp.portName, sp.estado.ToString(), sp.ultWrite.ToLongTimeString(), sp.mesaje);
            }
            dgvPuertos.DataSource = puertosView;
            dgvPuertos.Update();
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            DataRowView dvr = (DataRowView)dgvPuertos.SelectedRows[0].DataBoundItem;
            MisPuertos[Convert.ToInt32(dvr.Row["Id"])].openPort();
            ActualizaGRID();
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            DataRowView dvr = (DataRowView)dgvPuertos.SelectedRows[0].DataBoundItem;
            MisPuertos[Convert.ToInt32(dvr.Row["Id"])].closePort();
            ActualizaGRID();
        }

        private void btnReadPort_Click(object sender, EventArgs e)
        {
            DataRowView dvr = (DataRowView)dgvPuertos.SelectedRows[0].DataBoundItem;
            MisPuertos[Convert.ToInt32(dvr.Row["Id"])].readPort();
            ActualizaGRID();
        }

        private void b_play_Click(object sender, EventArgs e)
        {
            foreach (easyPort sp in MisPuertos)
            {
                sp.Play();
            }
        }

        private void b_stop_Click(object sender, EventArgs e)
        {
            foreach (easyPort sp in MisPuertos)
            {
                sp.Stop();
            }
        }
    }
}
