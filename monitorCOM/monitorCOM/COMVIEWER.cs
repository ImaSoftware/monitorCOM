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
        DataTable port_cnf;
        public class easyportcnf
        {
            public string PortName = "";
            public int BaudRate = 2400;
            public Parity parity = Parity.None;
            public int dataBits = 8;
            public StopBits stopbits = StopBits.One;
            public Handshake handshake = Handshake.None;
            public int readtimeout = 500;
            public int writetimeout = 500;
            public easyportcnf(string pn, int br, int db, Parity par,  StopBits sb, Handshake hs, int rtime, int wtime) {
                PortName = pn;
                BaudRate = br;
                parity = par;
                dataBits = db;
                stopbits = sb;
                handshake = hs;
                readtimeout = rtime;
                writetimeout = wtime;
            }
           
        }
        class easyPort
        {
            public delegate void ActualizarEventHandler(Object sender);
            public event ActualizarEventHandler Actualizar;
            public int id = -1;
            public bool detenido=false; 
            public enum status { Undefined, Error, Open, Closed }
            public int baudrate = 2400;
            public string portName = "";
            public easyportcnf mycnf;
            public SerialPort spSoft;
            public DateTime ultWrite;
            public status estado = status.Undefined;
            public string mesaje = "";
            public Timer timerTabla = new Timer();
            public BackgroundWorker pbw = new BackgroundWorker();
            public easyPort(int xid,easyportcnf cnf) {
                id = xid;
                timerTabla.Interval = Convert.ToInt32(Properties.Settings.Default.tiempo);
                timerTabla.Tick += new EventHandler(LeerTabla);
                pbw.DoWork += new DoWorkEventHandler(miBw_DoWork);
                pbw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(miBw_WorkComplete);
                portName = cnf.PortName ;
                baudrate = cnf.BaudRate;
                mycnf = cnf;
                this.resetPort();
            }
            public void Play() {
                timerTabla.Stop();
                timerTabla.Interval = Convert.ToInt32(Properties.Settings.Default.tiempo);
                detenido = false;
                timerTabla.Start();
            }
            private void resetPort() {
                this.estado = status.Undefined;
                spSoft = new SerialPort();
                spSoft.PortName = mycnf.PortName;
                spSoft.BaudRate = mycnf.BaudRate;
                spSoft.Parity = mycnf.parity;
                spSoft.DataBits = mycnf.dataBits ;
                spSoft.StopBits = mycnf.stopbits;
                spSoft.Handshake = mycnf.handshake;
                spSoft.ReadTimeout = mycnf.readtimeout;
                spSoft.WriteTimeout = mycnf.writetimeout;
            }
            public void Stop()
            {
                timerTabla.Stop();
                detenido = true;
                this.closePort();
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
                        string sqlLee = @"select ESTACION_R, w_timeout, invertir from MONITORCOM_C where ESTACION_W = @miMaquina and PUERTO = @portname and  Leer = cast(1 as bit)";
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
                            decimal valor = 0;
                            bool salir = false;
                            int i = 0;
                            while (!salir) {
                                try {
                                    this.closePort();
                                    this.resetPort();
                                    if (this.estado != status.Open)
                                        this.openPort();
                                    this.readPort();
                                    if (this.estado != status.Error && this.mesaje.Length == 15) {
                                        //invertir el mensaje si así esta parametrizado 
                                        string sarta = "";
                                        bool xinv = (bool)dt.Rows[0]["invertir"];
                                        if (xinv)
                                        {
                                            string xmed = new string(this.mesaje.Reverse().ToArray());
                                            sarta = xmed.Substring(xmed.Length - 9, 8);
                                        }
                                        else
                                        {
                                            sarta = this.mesaje.Substring(1, 8);                                            
                                        }
                                        Decimal.TryParse(sarta, out valor);
                                        salir = true;
                                    }
                                } catch (Exception ex) {
                                    this.mesaje = ex.Message;
                                    System.Threading.Thread.Sleep(1);
                                    i += 1;
                                    if (i > Convert.ToInt32(dt.Rows[0]["w_timeout"]))
                                        salir = true;
                                }
                            }
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

            public void readPort(bool cerrar=false) {
                
                if (this.estado != status.Open) {
                    this.mesaje = "El puerto no está Abierto";
                    return;
                }
                try
                    {
                        try
                        {
                           this.mesaje = spSoft.ReadLine();
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
            leeConfig();
            leeSeriales();
        }
        void leeConfig() {
            string cFile = Environment.CurrentDirectory + "\\portconfig.xml";
            string cFile2 = Environment.CurrentDirectory + "\\portconfig.xsd";
            if (!System.IO.File.Exists(cFile)) //si no existe debemos crearlo 
            {
                //Crear el archivo
                DataTable dt = new DataTable("portconfig");
                dt.Columns.Add("portName", typeof(string));
                dt.Columns.Add("bps", typeof(int));
                dt.Columns.Add("bitslen", typeof(int));
                dt.Columns.Add("parity", typeof(int));
                dt.Columns.Add("stop", typeof(int));
                dt.Columns.Add("hs", typeof(int));
                dt.Columns.Add("read_t", typeof(int));
                dt.Columns.Add("write_t", typeof(int));
                string[] ps_Names = SerialPort.GetPortNames();
                foreach (string nm in ps_Names)
                {
                    //valores por defecto
                    dt.Rows.Add(nm, 2400, 8, (int)Parity.None, (int)StopBits.One, (int)Handshake.None, 500, 500);
                }
                dt.WriteXml(cFile);
                dt.WriteXmlSchema(cFile2);
            }
            port_cnf = new DataTable();
            port_cnf.ReadXmlSchema(cFile2);
            port_cnf.ReadXml(cFile);
        }

        Object[] BuscaConfi(string name)
        {
            Object[] ret = new Object[8] {name,2400,  8, Parity.None, StopBits.One, Handshake.None, 500,500 };
            DataRow[] a =  port_cnf.Select(string.Format("portName='{0}'", name));
            if (a.Length ==1)
            {
                ret = new Object[8] { name, a[0]["bps"], a[0]["bitslen"], a[0]["parity"], a[0]["stop"], a[0]["hs"], a[0]["read_t"], a[0]["write_t"] };
            }
            return ret;
        }

        void leeSeriales() {
            MisPuertos = new List<easyPort>();
            string[] ps_Names = SerialPort.GetPortNames();
            int i = 0;
            foreach (string nm in ps_Names)
            {
                Object[] dr = BuscaConfi(nm);
                easyportcnf confi = new easyportcnf((string)dr[0], (int)dr[1], (int)dr[2], (Parity)dr[3], (StopBits)dr[4], (Handshake)dr[5], (int)dr[6], (int)dr[7]);
                easyPort pA = new easyPort(i, confi);
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
            lblRun.Visible = true;
            lblStop.Visible = false;
            maintimer.Interval = Convert.ToInt32(Properties.Settings.Default.tiempo);
            maintimer.Start();
        }

        private void b_stop_Click(object sender, EventArgs e)
        {
            foreach (easyPort sp in MisPuertos)
            {
                sp.Stop();
            }
            lblRun.Visible = false;
            lblStop.Visible = true;
            maintimer.Stop();
        }

        private void btnConfPort_Click(object sender, EventArgs e)
        {
            spcnf confi = new spcnf(MisPuertos[Convert.ToInt32(((DataRowView)dgvPuertos.SelectedRows[0].DataBoundItem).Row["Id"])].mycnf);
            if (confi.ShowDialog() == DialogResult.OK) {
                ActualizaTabla(confi.res);
                MisPuertos[Convert.ToInt32(((DataRowView)dgvPuertos.SelectedRows[0].DataBoundItem).Row["Id"])].mycnf = confi.res;
            }
        }
        private void ActualizaTabla(easyportcnf epcnf) {
            bool reemplazo = false;
            for (int i = 0; i < port_cnf.Rows.Count; i++) {
                if (String.Equals(port_cnf.Rows[i]["portName"].ToString(), epcnf.PortName))
                {
                    port_cnf.Rows[i]["bps"] = epcnf.BaudRate;
                    port_cnf.Rows[i]["bitslen"] = epcnf.dataBits;
                    port_cnf.Rows[i]["parity"] = epcnf.parity;
                    port_cnf.Rows[i]["stop"] = epcnf.stopbits;
                    port_cnf.Rows[i]["hs"] = epcnf.handshake;
                    port_cnf.Rows[i]["read_t"] = epcnf.readtimeout;
                    port_cnf.Rows[i]["write_t"] = epcnf.writetimeout;
                    reemplazo = true;
                }
            }
            if (!reemplazo) {
                //esto deberia ser un falso positivo pero igual lo pongo por si las moscas 
                port_cnf.Rows.Add(epcnf.PortName, epcnf.BaudRate, epcnf.dataBits, epcnf.parity, epcnf.stopbits, epcnf.handshake, epcnf.readtimeout, epcnf.writetimeout);
            }
            //Actualizar archivo de configuracion
            //eliminar archivo (Se supone ya esta cargado)
            string cFile = Environment.CurrentDirectory + "\\portconfig.xml";
            System.IO.File.Delete(cFile);
            port_cnf.WriteXml(cFile);
        }

        private void maintimer_Tick(object sender, EventArgs e)
        {
            maintimer.Stop();
            foreach (easyPort sp in MisPuertos)
            {
                if (sp.detenido){ sp.Play(); }
            }
            maintimer.Interval =Convert.ToInt32(Properties.Settings.Default.tiempo);
            maintimer.Start();
        }

        private void COMVIEWER_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (easyPort sp in MisPuertos)
            {
                sp.Stop();
            }
        }
    }
}
