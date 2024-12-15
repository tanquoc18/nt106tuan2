using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
namespace CUOICUNG
{
    public partial class Form1 : Form
    {
        private TcpListener serverListener;
        private Thread serverThread;
        private bool isRunning;
        private TcpListener screenListener;
        private Thread screenThread;
        private bool isStreaming;
        private TcpClient client;
        private StreamWriter logWriter;
        private readonly object logLock = new object();
        public Form1()
        {
            InitializeComponent();
            logWriter = new StreamWriter("log.txt", true) { AutoFlush = true };
        }
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public static void MoveMouse(int x, int y)
        {
            Cursor.Position = new Point(x, y);
        }
        public static void MouseLeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }
        public static void MouseLeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void MouseRightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }
        public static void MouseRightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int KEYEVENTF_KEYDOWN = 0x0000; // Key down flag
        private const int KEYEVENTF_KEYUP = 0x0002;   // Key up flag
        private void ProcessMouseCommand(string command)
        {
            string[] parts = command.Split(':');
            if (parts[0] == "MOUSE")
            {
                switch (parts[1])
                {
                    case "MOVE":
                        string[] coords = parts[2].Split(',');
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);
                        MoveMouse(x, y);
                        break;
                    case "LEFT_DOWN":
                        MouseLeftDown();
                        break;
                    case "LEFT_UP":
                        MouseLeftUp();
                        break;
                    case "RIGHT_DOWN":
                        MouseRightDown();
                        break;
                    case "RIGHT_UP":
                        MouseRightUp();
                        break;
                }
            }
        }
        private async void StartServerButton_Click(object sender, EventArgs e)
        {
            
            if (isRunning)
            {
                StopServer();
                StartServerButton.Text = "Start Server";
            }
            else
            {
                await StartServerAsync();
                StartServerButton.Text = "Stop Server";
            }
        }
        private async Task StartServerAsync()
        {
            try
            {
                string localIP = GetLocalIPAddress();
                serverListener = new TcpListener(IPAddress.Parse(localIP), 8080);
                serverListener.Start();
                isRunning = true;
                MessageBox.Show($"Server is running at IP: {localIP}, Port: 8080");
                ServerStatusLabel.Text = $"Server running at {localIP}:8080";
                
                await ListenForClientsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server: {ex.Message}");
            }
        }
        private void StopServer()
        {
            try
            {
                isRunning = false;
                serverListener?.Stop();
                if (serverThread != null && serverThread.IsAlive)
                {
                    serverThread.Join(); // Chờ thread dừng an toàn
                }
                ServerStatusLabel.Text = "Server stopped";
            }
            catch (Exception ex)
            {
                WriteLog($"Error stopping server: {ex.Message}");
            }
        }
        private void ListenForClients()
        {
            while (isRunning)
            {
                TcpClient client = serverListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                HandleClientCommands(stream);
            }
        }
        private async Task ListenForClientsAsync()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = await serverListener.AcceptTcpClientAsync(); // Sử dụng bất đồng bộ
                    NetworkStream stream = client.GetStream();
                    await HandleClientCommandsAsync(stream); // Đảm bảo hàm HandleClientCommandsAsync cũng là async
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error handling client: {ex.Message}");
                }
            }
        }
        private async Task HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    HandleCommand(command);
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
        private async Task HandleClientCommandsAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            try
            {
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (command.StartsWith("MOUSE"))
                    {
                        HandleMouseCommand(command.Substring(6));
                    }
                    else if (command.StartsWith("KEYBOARD"))
                    {
                        HandleKeyboardCommand(command.Substring(9));
                    }
                    else
                    {
                        WriteLog($"Unknown command: {command}");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error while handling commands: {ex.Message}");
            }
            finally
            {
                stream.Close();
            }
        }
        private void HandleCommand(string command)
        {
            try
            {
                if (command.StartsWith("MOUSE"))
                {
                    HandleMouseCommand(command.Substring(6));
                }
                else if (command.StartsWith("KEYBOARD"))
                {
                    HandleKeyboardCommand(command.Substring(9));
                }
                else
                {
                    WriteLog($"Unknown command: {command}");
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error processing command '{command}': {ex.Message}");
            }
        }
        private void HandleClientRequest(string command, NetworkStream stream)
        {
            if (command == "CAPTURE_SCREEN")
            {
                CaptureAndSendScreen(stream);
            }
            else 
            {
                MessageBox.Show("Không thể gửi lệnh chụp màn hình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CaptureAndSendScreen(NetworkStream stream)
        {
            try
            {
                Rectangle bounds = Screen.PrimaryScreen.Bounds;
                using (Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height))
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);

                    // Gửi ảnh qua stream
                    using (var ms = new MemoryStream())
                    {
                        screenshot.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imageData = ms.ToArray();

                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(imageData.Length);  // Gửi độ dài dữ liệu
                        writer.Write(imageData);         // Gửi dữ liệu ảnh
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing and sending screen: {ex.Message}");
            }
        }
        private void HandleMouseCommand(string command)
        {
            try
            {
                string[] parts = command.Split(':');
                if (parts.Length < 2) return;

                string action = parts[0];
                string[] parameters = parts[1].Split(',');

                switch (action)
                {
                    case "MOVE":
                        if (parameters.Length != 2)
                        {
                            break;
                        }
                        if (int.TryParse(parameters[0], out int x) && int.TryParse(parameters[1], out int y))
                        {
                            if (x >= 0 && y >= 0 && x <= Screen.PrimaryScreen.Bounds.Width && y <= Screen.PrimaryScreen.Bounds.Height)
                            {
                                Cursor.Position = new Point(x, y);
                            }
                            else
                            {
                                WriteLog("Mouse move command out of bounds.");
                            }
                        }
                        break;
                    case "LEFT_CLICK":
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(50); // Đảm bảo sự kiện chuột được nhận
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        break;
                    case "RIGHT_CLICK":
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(50); // Thêm độ trễ để đảm bảo sự kiện được xử lý
                        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        break;
                    default:
                        WriteLog("Unknown mouse command.");
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLog($"Error processing mouse command '{command}': {ex.Message}");
            }
        }
        private void HandleKeyboardCommand(string keyCommand)
        {
            string[] parts = keyCommand.Split(':');
            if (parts.Length < 2) return;
            string action = parts[0];
            int keyCode;
            if (int.TryParse(parts[1], out keyCode))
            {
                switch (action)
                {
                    case "KEY_DOWN":
                        keybd_event((byte)keyCode, 0, KEYEVENTF_KEYDOWN, 0);
                        WriteLog($"Key down: {keyCode}");
                        break;
                    case "KEY_UP":
                        keybd_event((byte)keyCode, 0, KEYEVENTF_KEYUP, 0);
                        WriteLog($"Key up: {keyCode}");
                        break;
                    default:
                        WriteLog($"Unknown keyboard action: {action}");
                        break;
                }
            }
            else
            {
                WriteLog("Invalid keyCode.");
            }
        }
        private void WriteLog(string message)
        {
            lock (logLock)
            {
                logWriter.WriteLine($"[{DateTime.Now}] {message}");
            }
        }
        private string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving local IP address: {ex.Message}");
            }
            return "127.0.0.1";
        }
        private void StartStreamingButton_Click(object sender, EventArgs e)
        {
            if (isStreaming)
            {
                StopStreaming();
                StartStreamingButton.Text = "Start Streaming";
            }
            else
            {
                StartStreaming();
                StartStreamingButton.Text = "Stop Streaming";
            }
        }
        private void StartStreaming()
        {
            try
            {
                string localIP = GetLocalIPAddress();
                screenListener = new TcpListener(IPAddress.Parse(localIP), 8081);
                screenListener.Start();
                isStreaming = true;
                StreamingStatusLabel.Text = "Streaming started.";
                screenThread = new Thread(SendScreenToClient);
                screenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting streaming: {ex.Message}");
            }
        }
        private void StopStreaming()
        {
            try
            {
                isStreaming = false;
                screenListener?.Stop();
                screenThread?.Abort();
                StreamingStatusLabel.Text = "Streaming stopped.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping streaming: {ex.Message}");
            }
        }
        private void DebugLogImageSize(string context, Bitmap image)
        {
            Console.WriteLine($"{context}: Width={image.Width}, Height={image.Height}");
        }
        private void SendScreenToClient()
        {
            while (isStreaming)
            {
                try
                {
                    using (var client = screenListener.AcceptTcpClient())
                    using (var stream = client.GetStream())
                    {
                        BinaryWriter writer = new BinaryWriter(stream);

                        while (isStreaming)
                        {
                            Bitmap screenCapture = CaptureScreen();
                            using (var ms = new MemoryStream())
                            {
                                screenCapture.Save(ms, ImageFormat.Jpeg);
                                byte[] buffer = ms.ToArray();
                                writer.Write(buffer.Length);
                                writer.Write(buffer);
                                writer.Flush();
                            }
                            Thread.Sleep(50); // Giảm độ trễ để tăng hiệu suất
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!isStreaming) break;
                    MessageBox.Show($"Error streaming: {ex.Message}");
                }
            }
        }
        private byte[] CaptureScreenn()
        {
            using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }
        private Bitmap CaptureScreen()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(screenBounds.Width, screenBounds.Height, PixelFormat.Format24bppRgb); // Đổi format phù hợp
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(screenBounds.Left, screenBounds.Top, 0, 0, screenBounds.Size, CopyPixelOperation.SourceCopy);
            }
            return screenshot;
        }
        private void HandleFileTransfer(NetworkStream stream, string command, byte[] buffer)
        {
            string serverFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServerFiles");
            Directory.CreateDirectory(serverFolder); // Ensure folder exists
            if (command.StartsWith("UPLOAD"))
            {
                string fileName = command.Substring(7); // Remove "UPLOAD " prefix
                string filePath = Path.Combine(serverFolder, fileName);

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, bytesRead);
                            if (bytesRead < buffer.Length) break; // End of file
                        }
                    }
                    WriteLog($"File uploaded: {fileName}");
                }
                catch (Exception ex) {WriteLog($"Error uploading file {fileName}: {ex.Message}");}
            }
            else if (command.StartsWith("DOWNLOAD"))
            {
                string fileName = command.Substring(9); // Remove "DOWNLOAD " prefix
                string filePath = Path.Combine(serverFolder, fileName);

                try
                {
                    if (File.Exists(filePath))
                    {
                        byte[] fileData = File.ReadAllBytes(filePath);
                        stream.Write(fileData, 0, fileData.Length); // Send file to client
                        WriteLog($"File downloaded: {fileName}");
                    }
                    else
                    {
                        byte[] errorMessage = Encoding.UTF8.GetBytes("File not found.");
                        stream.Write(errorMessage, 0, errorMessage.Length);
                        WriteLog($"File not found: {fileName}");
                    }
                }
                catch (Exception ex) {WriteLog($"Error downloading file {fileName}: {ex.Message}");}
            }
            else if (command == "LIST")
            {
                string[] files = Directory.GetFiles(serverFolder);
                string fileList = string.Join("|", files.Select(Path.GetFileName));
                byte[] data = Encoding.UTF8.GetBytes(fileList);
                stream.Write(data, 0, data.Length);
                WriteLog($"File list sent to client.");
            }
        }

        private void HandleClientCommands(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (command == "SCREENSHOT")
                {
                    byte[] screenshot = CaptureScreenn();
                    stream.Write(screenshot, 0, screenshot.Length);
                }
                else if (command == "UPLOAD" || command.StartsWith("UPLOAD"))
                {
                    HandleFileTransfer(stream, command, buffer);
                }
                else if (command == "DOWNLOAD" || command.StartsWith("DOWNLOAD"))
                {
                    HandleFileTransfer(stream, command, buffer);
                }
                else if (command == "LIST")
                {
                    HandleFileTransfer(stream, command, buffer);
                }
                else
                {
                    WriteLog($"Unknown command: {command}");
                }
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (NetworkStream stream = client.GetStream())
                {
                    string command = "REFRESH";
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string fileList = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    MessageBox.Show(fileList, "File List from Server");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error refreshing file list: " + ex.Message);}
        }
        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("server_ip", 8080);
                MessageBox.Show("Connected to server.");
            }
            catch (Exception ex) { MessageBox.Show("Error connecting to server: " + ex.Message);}
        }
    }
}
