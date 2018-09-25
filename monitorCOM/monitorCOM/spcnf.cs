using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace monitorCOM
{
    public partial class spcnf : Form
    {
        
        public COMVIEWER.easyportcnf res;
        public spcnf(COMVIEWER.easyportcnf config)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            Text = config.PortName;
            cb_baud.SelectedItem = config.BaudRate.ToString(); 
            cb_bits.SelectedItem = config.dataBits.ToString();
            cb_hs.SelectedIndex = (int)config.handshake;
            cb_par.SelectedIndex = (int)config.parity;
            cb_parada.SelectedIndex = (int)config.stopbits;
            writeTO.Value = config.writetimeout;
            readTO.Value = config.readtimeout;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res = new COMVIEWER.easyportcnf(Text, int.Parse((string)cb_baud.SelectedItem), int.Parse((string)cb_bits.SelectedItem), (Parity)cb_par.SelectedIndex, (StopBits)cb_parada.SelectedIndex, (Handshake)cb_hs.SelectedIndex, (int)writeTO.Value, (int)readTO.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        private void spcnf_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
