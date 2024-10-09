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

namespace TCPPrivateChat
{
    public partial class Form1 : Form
    {
        private Socket listener = null;
        private bool started = false;
        private int _port = 11000;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];
        private Thread serverThread = null;
        private List<Socket> clientSockets = new List<Socket>();
        private delegate void SafeCallDelegate(string text, Control obj);

        public Form1()
        {
            InitializeComponent();
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public class StateObject
        {
            public Socket clientSocket = null;
            public const int BufferSize = 2048;
            public byte[] buffer = new byte[BufferSize];
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            try
            {
                if (started)
                {
                    started = false;
                    Listen.Text = "Listen";
                    listener.Close();
                    serverThread = null;
                }
                else
                {
                    serverThread = new Thread(() => this.listen());
                    serverThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listen()
        {
            listener.Bind(new IPEndPoint(IPAddress.Parse(Path.Text), _port));
            listener.Listen(10);
            started = true;
            UpdateTextThreadSafe("Stop", Listen);
            UpdateTextThreadSafe("Start listening", Hienthi);

            while (started)
            {
                Socket client = listener.Accept(); 
                clientSockets.Add(client);
                Thread clientThread = new Thread(() => this.readingClientSocket(client));
                clientThread.Start();
                UpdateTextThreadSafe(client.RemoteEndPoint.ToString() + " has joined the chat!", Hienthi);
            }
        }


        private void readingClientSocket(Socket client)
        {
            StateObject state = new StateObject();
            state.clientSocket = client;
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            StateObject state = (StateObject)AR.AsyncState;
            Socket client = state.clientSocket;

            int received = client.EndReceive(AR);
            if (received > 0)
            {
                byte[] receivedData = new byte[received];
                Array.Copy(state.buffer, receivedData, received);

                if (receivedData[0] == 0) 
                {
                    string receivedStr = Encoding.UTF8.GetString(receivedData, 1, received - 1);
                    UpdateTextThreadSafe(receivedStr, Hienthi);
                    foreach (Socket s in clientSockets)
                    {
                        if (s != client)
                        {
                            s.Send(receivedData);
                        }
                    }
                }
                else if (receivedData[0] == 1) 
                {
                    HandleFileReceiving(receivedData.Skip(1).ToArray());
                    foreach (Socket s in clientSockets)
                    {
                        if (s != client)
                        {
                            s.Send(receivedData);
                        }
                    }
                }
                else if (receivedData[0] == 2)
                {
                    string fileName = Encoding.UTF8.GetString(receivedData, 1, received - 1);
                    UpdateTextThreadSafe("Receiving file: " + fileName, Hienthi);
                    foreach (Socket s in clientSockets)
                    {
                        if (s != client)
                        {
                            s.Send(receivedData); 
                        }
                    }
                }
            }

            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
        }



        private List<byte> fileBuffer = new List<byte>();

        private void HandleFileReceiving(byte[] receivedChunk)
        {
            fileBuffer.AddRange(receivedChunk);
            if (receivedChunk.Length < 1024)
            {
                string filePath = "received_file_" + DateTime.Now.Ticks + ".dat";
                System.IO.File.WriteAllBytes(filePath, fileBuffer.ToArray());  
                fileBuffer.Clear(); 
                UpdateTextThreadSafe("File received and saved as: " + filePath, Hienthi);
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
