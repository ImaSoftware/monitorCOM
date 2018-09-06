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
namespace monitorCOM
{
    public partial class COMVIEWER : Form
    {
        List<easyPort> MisPuertos;
        DataTable puertosView;
        class easyPort
        {
            public int id = -1;
            public enum status { Error, Open, Closed }
            public int baudrate = 24000;
            public string portName = "";
            public SerialPort spSoft;
            public DateTime ultWrite;
            public status estado;
            public string mesaje = "";
            public easyPort(int xid, string xName = "COM1", int xbaudRate = 9600) {
                id = xid;
                portName = xName;
                spSoft = new SerialPort();
                spSoft.ReadTimeout = 10000;
                spSoft.PortName = xName;
                spSoft.BaudRate = xbaudRate;
                spSoft.DataBits = 8;
                spSoft.StopBits = StopBits.One;

            }
            public void readPort() {
                
                string lectura = "";
                if (this.estado != status.Open) {
                    this.mesaje = "El puerto no está Abierto";
                    return;
                }
                try
                {
                    try
                    {
                        lectura = spSoft.ReadLine();
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
                    this.closePort();
                }
               
                MessageBox.Show(lectura);
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

                MisPuertos.Add(new easyPort(i, nm));
                i += 1;
            }
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
    }
}
