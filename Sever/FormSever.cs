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

namespace Sever
{
    public partial class Form1 : Form
    {
        private TcpListener _server;
        private TcpClient _client;
        private NetworkStream _netStream;
        private Thread _acceptThread;
        private bool _accept = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            IPHostEntry _host = Dns.GetHostEntry(Dns.GetHostName());
            this.txtIP.Text = "127.0.0.1"; 
            this.txtHOSTNAME.Text = _host.HostName;
            this.txtPORT.Text = "106";

            this.groupBox2.Enabled = true;
            this.btnSTART.Enabled = true;
            this.btnSTOP.Enabled = false;
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            try
            {
                _server = new TcpListener(IPAddress.Parse(this.txtIP.Text), Convert.ToInt32(this.txtPORT.Text));
                _server.Start();

                _acceptThread = new Thread(AcceptClient);
                _acceptThread.Start();

                this.groupBox2.Enabled = false;
                this.btnSTART.Enabled = false;
                this.btnSTOP.Enabled = true;
                _accept = true;

                ListMessages.Items.Add("Server started...");
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Start server error: {ex.Message}");
            }

        }

        private void AcceptClient()
        {
            try
            {
                _client = _server.AcceptTcpClient();
                _netStream = _client.GetStream();

                ListMessages.Invoke((MethodInvoker)(() => ListMessages.Items.Add("Client connected.")));

                byte[] buffer = new byte[1024];
                while (_accept)
                {
                    if (_client.Available > 0)
                    {
                        int bytesRead = _netStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            Invoke((MethodInvoker)(() => ListMessages.Items.Add("Received: " + msg)));
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
                if (_accept)
                {
                    Invoke((MethodInvoker)(() => ListMessages.Items.Add($"Error: {ex.Message}")));
                }
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            try
            {
                _accept = false;

                _netStream?.Close();
                _client?.Close();
                _server?.Stop();

                _acceptThread?.Join();

                ListMessages.Items.Add("Server stopped.");

                this.groupBox2.Enabled = true;
                this.btnSTART.Enabled = true;
                this.btnSTOP.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stop server error: {ex.Message}");
            }

        }

        private void btnSEND_Click(object sender, EventArgs e)
        {
            try
            {
                if (_client != null && _client.Connected && !string.IsNullOrEmpty(txtSEND.Text))
                {
                    byte[] msg = Encoding.ASCII.GetBytes(txtSEND.Text);
                    _netStream.Write(msg, 0, msg.Length);

                    ListMessages.Items.Add("Sent: " + txtSEND.Text);
                }
                else
                {
                    MessageBox.Show("No client connected or message is empty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send error: {ex.Message}");
            }
        }
    }
}
