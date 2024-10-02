using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient _client;
        private NetworkStream _sStream;
        private Thread _thread;
        private bool listen = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; 
        }

        private void txtHOSTNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCONNECT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIP.Text) || string.IsNullOrEmpty(txtHOSTNAME.Text) || string.IsNullOrEmpty(txtPORT.Text))
                return;

            try
            {
                _client = new TcpClient();
                _client.Connect(IPAddress.Parse(txtIP.Text), Convert.ToInt32(txtPORT.Text));

                if (_client.Connected)
                {
                    _sStream = _client.GetStream();
                    byte[] msg = Encoding.ASCII.GetBytes("Hello Server");
                    _sStream.Write(msg, 0, msg.Length);

                    this.groupBox1.Enabled = false;

                    listen = true;
                    _thread = new Thread(listening);
                    _thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
        }

        private void listening()
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (listen)
                {
                    if (_client.Available > 0)
                    {
                        int bytesRead = _sStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            Invoke((MethodInvoker)(() => ListMessages.Items.Add(msg)));
                        }
                    }
                    else
                    {
                        Thread.Sleep(100); 
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)(() => ListMessages.Items.Add($"Error: {ex.Message}")));
            }
        }

        private void btnSEND_Click(object sender, EventArgs e)
        {
            try
            {
                if (_client.Connected && !string.IsNullOrEmpty(txtSEND.Text))
                {
                    byte[] msg = Encoding.ASCII.GetBytes(txtSEND.Text);
                    _sStream.Write(msg, 0, msg.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send error: {ex.Message}");
            }
        }

        private void btnDISCONNECT_Click(object sender, EventArgs e)
        {
            listen = false;
            _sStream?.Close();
            _client?.Close();
            _thread?.Join(); 

            this.groupBox1.Enabled = true;
        }
    }
}
