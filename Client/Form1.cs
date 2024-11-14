using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncSharp;

namespace Client
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            string serverIP = txtIP.Text.Trim();        // Lấy IP từ TextBox
            string password = txtPassword.Text.Trim(); // Lấy mật khẩu từ TextBox

            if (string.IsNullOrWhiteSpace(serverIP) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kiểm tra xem mật khẩu có đúng không
                bool isValid = TestVncConnection(serverIP, password);

                if (isValid)
                {
                    // Mở Form2 để hiển thị kết nối Remote Desktop
                    Form2 form2 = new Form2(serverIP, password);
                    form2.Show();

                    // Ẩn Form1
                    this.Hide();
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu mật khẩu sai
                    MessageBox.Show("Sai mật khẩu, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TestVncConnection(string serverIP, string password)
        {
            try
            {
                using (RemoteDesktop remoteDesktop = new RemoteDesktop())
                {
                    remoteDesktop.VncPort = 5900; // Cổng mặc định của VNC Server
                    remoteDesktop.GetPassword = () => password; // Cung cấp mật khẩu
                    remoteDesktop.Connect(serverIP); // Thử kết nối

                    // Nếu không có ngoại lệ, kết nối thành công
                    remoteDesktop.Disconnect(); // Ngắt kết nối ngay sau khi kiểm tra
                    return true;
                }
            }
            catch
            {
                // Mật khẩu sai hoặc không thể kết nối
                return false;
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
