using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncSharp;

namespace Client
{
    public partial class Form2 : Form
    {

        private string serverIP;
        private string password;

        public Form2(string serverIP, string password)
        {
            InitializeComponent();
            this.serverIP = serverIP;
            this.password = password;
            try
            {
                // Cấu hình RemoteDesktop để kết nối
                remoteDesktop1.VncPort = 5900; // Port mặc định của VNC
                remoteDesktop1.GetPassword = () => this.password; // Hàm lấy mật khẩu
                remoteDesktop1.Connect(this.serverIP); // Kết nối đến server
             

                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu kết nối không thành công
            }
 

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ngắt kết nối khi đóng form
            remoteDesktop1.Disconnect();
        }




        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

 

        private void btnCaptureScreen_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem remoteDesktop có kết nối và được khởi tạo chưa
                if (remoteDesktop1.IsConnected)
                {
                    string directoryPath = @"C:\Screenshots";
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);  // Tạo thư mục nếu chưa có
                    }

                    // Tạo một Bitmap để lưu ảnh chụp màn hình
                    Bitmap screenshot = new Bitmap(remoteDesktop1.Width, remoteDesktop1.Height);

                    // Chụp màn hình từ RemoteDesktop và lưu vào Bitmap
                    remoteDesktop1.DrawToBitmap(screenshot, new Rectangle(0, 0, screenshot.Width, screenshot.Height));

                    // Lưu ảnh vào tệp với tên theo định dạng ngày giờ
                    string filePath = Path.Combine(directoryPath, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    // Thông báo cho người dùng rằng ảnh đã được lưu
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

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            remoteDesktop1.Disconnect();
            MessageBox.Show("Đã ngắt kết nối thành công.");
        }

    }
}
