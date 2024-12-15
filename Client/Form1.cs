using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client
{
    public partial class Form1 : Form
    {
            private TcpClient client;
            private StreamWriter writer;    
            private TcpClient screenClient;
            private Thread screenThread;
            private bool isReceiving = false;
            private bool isSending = false;
            private bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
            this.ScreenPictureBox.MouseClick += new MouseEventHandler(ScreenPictureBox_MouseClick);
            this.ScreenPictureBox.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.ScreenPictureBox.Focus();
            this.ScreenPictureBox.MouseDown += Form1_MouseDown;
            this.ScreenPictureBox.MouseUp += Form1_MouseUp;
            this.ScreenPictureBox.TabStop = true;
            this.ScreenPictureBox.Focus();
        }
        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            string serverIP = txtServerIP.Text;
            int port = 8080; // hoặc giá trị bạn chỉ định

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(serverIP, port);
                MessageBox.Show("Connected to server!");

                NetworkStream stream = client.GetStream();
                writer = new StreamWriter(stream);
                isConnected = true; // Đặt cờ kết nối thành true
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                writer?.Close();
                client?.Close();
                isConnected = false; // Đặt cờ kết nối thành false
                MessageBox.Show("Disconnected from server.");
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error disconnecting: {ex.Message}");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isConnected)
            {
                DisconnectButton_Click(this, EventArgs.Empty);
            }
            base.OnFormClosing(e);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isConnected)
            {
                Point serverCoords = ConvertToServerCoordinates(e.X, e.Y); // Chuyển tọa độ chuột từ client sang server
                string command = $"MOUSE:MOVE:{serverCoords.X},{serverCoords.Y}";
                SendCommandToServer(command); // Gửi lệnh di chuyển chuột tới server
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point serverCoords = ConvertToServerCoordinates(e.X, e.Y); // Chuyển tọa độ chuột từ client sang server
            string command = e.Button == MouseButtons.Left
                ? $"MOUSE:LEFT_DOWN:{serverCoords.X},{serverCoords.Y}"
                : $"MOUSE:RIGHT_DOWN:{serverCoords.X},{serverCoords.Y}";
            SendCommandToServer(command); // Gửi lệnh nhấn chuột tới server
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Point serverCoords = ConvertToServerCoordinates(e.X, e.Y); // Chuyển tọa độ chuột từ client sang server
            string command = e.Button == MouseButtons.Left
                ? $"MOUSE:LEFT_UP:{serverCoords.X},{serverCoords.Y}"
                : $"MOUSE:RIGHT_UP:{serverCoords.X},{serverCoords.Y}";
            SendCommandToServer(command); // Gửi lệnh thả chuột tới server
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (isConnected && writer != null)
                {
                    writer.WriteLine($"KEY:{(byte)e.KeyCode},true");
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending key down event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (isConnected && writer != null)
                {
                    writer.WriteLine($"KEY:{(byte)e.KeyCode},false");
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending key up event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartReceivingButton_Click(object sender, EventArgs e)
        {
            if (isReceiving)
            {
                StopReceiving();
                StartReceivingButton.Text = "Start Receiving";
            }
            else
            {
                StartReceiving();
                StartReceivingButton.Text = "Stop Receiving";
            }
        }
        private void SendCommandToServer(string command)
        {
            try
            {
                if (isConnected && writer != null)
                {
                    writer.WriteLine(command);
                    writer.Flush();
                }
                else
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartReceiving()
        {
            try
            {
                string serverIP = txtServerIP.Text.Trim();
                if (string.IsNullOrEmpty(serverIP))
                {
                    MessageBox.Show("Please enter a valid server IP.");
                    return;
                }
                screenClient = new TcpClient(serverIP, 8081);
                isReceiving = true;
                ReceivingStatusLabel.Text = "Receiving started.";
                screenThread = new Thread(ReceiveScreenFromServer);
                screenThread.IsBackground = true;  // Đảm bảo thread sẽ dừng khi ứng dụng đóng
                screenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting receiving: {ex.Message}");
            }
        }
        private void StopReceiving()
        {
            try
            {
                isReceiving = false;
                screenClient?.Close(); // Đảm bảo đóng kết nối
                ReceivingStatusLabel.Text = "Receiving stopped.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping receiving: {ex.Message}");
            }
        }
        private void ReceiveScreenFromServer()
        {
            try
            {
                using (var stream = screenClient.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    while (isReceiving)
                    {
                        try
                        {
                            int length = reader.ReadInt32();
                            byte[] buffer = new byte[length];
                            int totalRead = 0;

                            while (totalRead < length)
                            {
                                int bytesRead = stream.Read(buffer, totalRead, length - totalRead);
                                if (bytesRead == 0)
                                    throw new Exception("Disconnected during image transfer.");
                                totalRead += bytesRead;
                            }

                            using (var ms = new MemoryStream(buffer))
                            {
                                Bitmap screen = new Bitmap(ms);
                                Invoke(new Action(() =>
                                {
                                    ScreenPictureBox.Image = screen;
                                }));
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!isReceiving) break;
                            MessageBox.Show($"Error receiving screen data: {ex.Message}");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting screen receive thread: {ex.Message}");
            }
        }
        private void ScreenPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Xác định nút chuột và tọa độ
            string button = e.Button == MouseButtons.Left ? "LEFT_CLICK" : "RIGHT_CLICK";
            string command = $"MOUSE:{button}:{e.X},{e.Y}";
            SendCommandToServer(command);
        }
        private void UploadFile(string filePath)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                string command = $"UPLOAD {fileName}";
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    stream.Write(fileData, 0, fileData.Length); // Send file data
                }
                MessageBox.Show("File uploaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DebugLogImageSize(string context, Bitmap image)
        {
            Console.WriteLine($"{context}: Width={image.Width}, Height={image.Height}");
        }
        private void DownloadFileFromServer(string fileName, string savePath)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string command = $"DOWNLOAD {fileName}";
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);

                    using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                MessageBox.Show("File downloaded successfully to: " + savePath, "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string[] ListServerFiles()
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new string[0]; // Return empty array if not connected
                }
                string command = "LIST";
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    byte[] buffer = new byte[8192];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string fileList = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return fileList.Split('|');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error listing files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0]; // Return empty array if error
            }
        }
        private void RequestScreenshot()
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string command = "SCREENSHOT";
                byte[] commandBytes = Encoding.UTF8.GetBytes(command);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[8192]; // Tăng kích thước buffer để truyền nhanh hơn
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                            if (bytesRead < buffer.Length)
                                break;
                        }
                        if (ms.Length > 0)
                        {
                            ms.Position = 0; // Đặt lại vị trí đọc trong MemoryStream
                            Image screenshot = Image.FromStream(ms);
                            ScreenPictureBox.Invoke((MethodInvoker)(() =>
                            {
                                ScreenPictureBox.Image = screenshot;
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to request screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    UploadFileToServer(filePath);
                }
            }
        }
        private void UploadFileToServer(string filePath)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                string command = $"UPLOAD {fileName}";

                using (NetworkStream stream = client.GetStream())
                {
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    stream.Write(fileData, 0, fileData.Length);
                }
                MessageBox.Show("File uploaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Client is not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string defaultFileName = "default_file.txt"; // Chọn một tên file mặc định (hoặc lấy từ danh sách file server)
                using (NetworkStream stream = client.GetStream())
                {
                    string command = "DOWNLOAD " + defaultFileName;
                    byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), defaultFileName);
                    using (FileStream fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write))
                    {
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, bytesRead);
                        }
                    }
                    MessageBox.Show("File downloaded successfully to: " + saveFilePath, "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ScreenshotButton_Click(object sender, EventArgs e)
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
                    string screenshotCommand = "SCREENSHOT";
                    byte[] commandBytes = Encoding.UTF8.GetBytes(screenshotCommand);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                }
                MessageBox.Show("Screenshot request sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending screenshot request: " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void btnCutScreen_Click(object sender, EventArgs e)
        {
            try
            {
                if (true)
                {
                    string directoryPath = @"C:\Screenshots";
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);  // Tạo thư mục nếu chưa có
                    }
                    Bitmap screenshot = new Bitmap(ScreenPictureBox.Width, ScreenPictureBox.Height);
                    ScreenPictureBox.DrawToBitmap(screenshot, new Rectangle(0, 0, screenshot.Width, screenshot.Height));
                    string filePath = Path.Combine(directoryPath, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show($"Đã lưu ảnh chụp màn hình tại: {filePath}");
                }
                else
                {
                    MessageBox.Show("Không có kết nối đến máy chủ để chụp màn hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chụp màn hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReceiveScreenAndSave()
        {
            try
            {
                using (var stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Nhận dữ liệu ảnh từ server
                    int length = reader.ReadInt32();
                    byte[] buffer = new byte[length];
                    int totalRead = 0;

                    while (totalRead < length)
                    {
                        int bytesRead = stream.Read(buffer, totalRead, length - totalRead);
                        if (bytesRead == 0)
                            throw new Exception("Disconnected during image transfer.");
                        totalRead += bytesRead;
                    }

                    // Lưu ảnh vào file
                    using (var ms = new MemoryStream(buffer))
                    {
                        Bitmap screenshot = new Bitmap(ms);
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "ServerScreenshot.png");
                        screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show($"Screenshot saved at {filePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving screenshot: {ex.Message}");
            }
        }
        private Point ConvertToServerCoordinates(int clientX, int clientY)
        {
            int serverWidth = 1920;
            int serverHeight = 1080;
            int clientWidth = ScreenPictureBox.Width;
            int clientHeight = ScreenPictureBox.Height;
            int clientLeft = ScreenPictureBox.Left;
            int clientTop = ScreenPictureBox.Top;

            // Tính tỷ lệ giữa kích thước server và client
            double scaleX = (double)serverWidth / clientWidth;
            double scaleY = ((double)serverHeight / clientHeight);

            // Tính tọa độ trên server
            int serverX = (int)((clientX - clientLeft) * scaleX);
            int serverY = (int)((clientY - clientTop) * scaleY);

            // Đảm bảo tọa độ không vượt quá kích thước server
            serverX = Math.Max(0, Math.Min(serverX, serverWidth));
            serverY = Math.Max(0, Math.Min(serverY, serverHeight));

            return new Point(serverX, serverY);
        }
        private void ScreenPictureBox_Click(object sender, EventArgs e)
        {
        }
    }
}
