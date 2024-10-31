using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rum_rum
{
    public partial class Form1 : Form
    {
        delegate void setTextDelegate(string val);
        public SerialPort ardPort { get; }
        public Form1()
        {
            InitializeComponent();
            ardPort = new SerialPort();
            ardPort.PortName = "COM3";
            ardPort.BaudRate = 9600;
            ardPort.DataBits = 8;
            ardPort.ReadTimeout = 500;
            ardPort.WriteTimeout = 500;
            ardPort.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);

        }

        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = ardPort.ReadLine();
            typeTxt(data);
        }

        void typeTxt(string val)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new setTextDelegate(typeTxt), val);
                }
                catch { }
            }
            else tempLabel.Text = val;
        }

        private void bttnConnect_Click(object sender, EventArgs e)
        {
            bttnDisconnect.Enabled = true;
            try
            {
                if (!ardPort.IsOpen) ardPort.Open();

                if (int.TryParse(tbTempLimit.Text, out int temperatureLimit))
                {
                    string limitString = temperatureLimit.ToString();
                    ardPort.Write(limitString);
                }
                else
                {
                    MessageBox.Show("check your numeric value added to the limit text box");
                }
                connectLabel.Text = "connection stablished";
                connectLabel.ForeColor = Color.Lime;

            }
            catch
            {
                MessageBox.Show("check your commnication port");
            }
        }

        void bttnDisconnect_Click (object sender, EventArgs e)
        {
            bttnConnect.Enabled = true;
            //bttnDisconnect.Enabled = false;
            if (ardPort.IsOpen) { ardPort.Close(); }
            connectLabel.Text = "Disconnected";
            connectLabel.ForeColor = Color.Red;
            tempLabel.Text = "0.0";
        }
    }
}
