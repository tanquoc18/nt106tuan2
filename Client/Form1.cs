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
        private Socket clientSocket = null;
        private static int _buff_size = 2048;
        private delegate void SafeCallDelegate(string text, Control obj);
        private Thread recvThread = null;

        public Form1()
        {
            InitializeComponent();
            clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress serverIp = IPAddress.Parse(PathServer.Text);
                int serverPort = int.Parse(PathPort.Text);
                IPEndPoint serverEp = new IPEndPoint(serverIp, serverPort);
                clientSocket.Connect(serverEp);
                HienThi.Text += "Connected to " + serverEp.ToString();
                this.Text = "Connected to " + serverEp.ToString();
                recvThread = new Thread(() => this.readingClientSocket());
                recvThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket client = (Socket)AR.AsyncState;
            int sent = client.EndSend(AR);
            if (sent > 0)
            {
                UpdateTextThreadSafe("Message sent to server!", HienThi);
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(Go.Text);
                byte[] dataWithHeader = new byte[data.Length + 1];
                dataWithHeader[0] = 0;
                Buffer.BlockCopy(data, 0, dataWithHeader, 1, data.Length);
                clientSocket.BeginSend(dataWithHeader, 0, dataWithHeader.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);
                UpdateTextThreadSafe("You: " + Go.Text, HienThi);
                Go.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private List<byte> fileBuffer = new List<byte>();

        private void readingClientSocket()
        {
            byte[] buffer = new byte[_buff_size];
            while (clientSocket != null && clientSocket.Connected)
            {
                int bRead = clientSocket.Receive(buffer, _buff_size, SocketFlags.None);
                if (bRead > 0)
                {
                    if (buffer[0] == 0) 
                    {
                        string receivedStr = Encoding.UTF8.GetString(buffer, 1, bRead - 1);
                        UpdateTextThreadSafe("Message from server: " + receivedStr, HienThi);
                    }
                    else if (buffer[0] == 1)
                    {
                        HandleFileReceiving(buffer.Skip(1).Take(bRead - 1).ToArray());
                    }
                    else if (buffer[0] == 2) 
                    {
                        string fileName = Encoding.UTF8.GetString(buffer, 1, bRead - 1);
                        UpdateTextThreadSafe("Receiving file: " + fileName, HienThi);
                    }
                }
            }
        }


        private void HandleFileReceiving(byte[] receivedChunk)
        {
            fileBuffer.AddRange(receivedChunk);
            if (receivedChunk.Length < 1024)
            {
                string filePath = "received_file_" + DateTime.Now.Ticks + ".dat";
                System.IO.File.WriteAllBytes(filePath, fileBuffer.ToArray());  
                fileBuffer.Clear(); 
                UpdateTextThreadSafe("File received and saved as: " + filePath, HienThi);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileData = System.IO.File.ReadAllBytes(filePath);
                SendFile(fileData);
            }
        }

        private void SendFile(byte[] fileData)
        {
            try
            {
                int packetSize = 1024;  
                int totalPackets = (int)Math.Ceiling((double)fileData.Length / packetSize);
                string fileName = "file_" + DateTime.Now.Ticks + ".dat";
                byte[] fileNameData = Encoding.UTF8.GetBytes(fileName);
                byte[] fileNameWithHeader = new byte[fileNameData.Length + 1];
                fileNameWithHeader[0] = 2; 
                Buffer.BlockCopy(fileNameData, 0, fileNameWithHeader, 1, fileNameData.Length);

                clientSocket.Send(fileNameWithHeader);  

                for (int i = 0; i < totalPackets; i++)
                {
                    int currentPacketSize = Math.Min(packetSize, fileData.Length - (i * packetSize));
                    byte[] dataWithHeader = new byte[currentPacketSize + 1];
                    dataWithHeader[0] = 1;  
                    Buffer.BlockCopy(fileData, i * packetSize, dataWithHeader, 1, currentPacketSize);
                    clientSocket.Send(dataWithHeader);
                }
                UpdateTextThreadSafe("You sent file: " + fileName, HienThi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending file: " + ex.Message);
            }
        }




        private void UpdateTextThreadSafe(string text, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateTextThreadSafe);
                control.Invoke(d, new object[] { text, control });
            }
            else
            {
                if (control is RichTextBox)
                {
                    ((RichTextBox)control).AppendText("\r\n" + text);
                    ((RichTextBox)control).ScrollToCaret();
                }
                else
                {
                    control.Text = text;
                }
            }
        }
    }
}
