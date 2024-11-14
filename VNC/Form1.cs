using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace VNC
{

    public partial class VncServerApp : Form
    {

        private Process vncServerProcess; // Tiến trình của TightVNC server
        private bool isRunning = false;  // Trạng thái server (đang chạy hoặc dừng)

        public VncServerApp()
        {
            InitializeComponent();
        }

        private void btnLayIpMk_Click(object sender, EventArgs e)
        {
            txtIP.Text = GetWirelessLANIPAddress(); // Hiển thị IP của Wireless LAN Adapter
            txtPort.Text = "5900"; // Cổng mặc định của TightVNC Server
        }

        // Hàm lấy địa chỉ IP của máy chủ
        private string GetWirelessLANIPAddress()
        {
            try
            {
                foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Kiểm tra nếu adapter là Wireless LAN
                    if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                        networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork) // Lấy IPv4
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy địa chỉ IP: " + ex.Message, "Lỗi");
            }
            return "Không tìm thấy địa chỉ IP của Wi-Fi";
        }


        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                StopVncServer();
            }
            else
            {
                StartVncServer();
            }
        }
        // Hàm khởi động TightVNC Server
        private void StartVncServer()
        {
            string vncServerPath = @"C:\Program Files\TightVNC\tvnserver.exe"; // Đường dẫn TightVNC Server
            string arguments = "-run"; // Tham số chạy TightVNC ở chế độ service hoặc ứng dụng

            try
            {
                if (File.Exists(vncServerPath))
                {
                    vncServerProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = vncServerPath,
                            Arguments = arguments,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        }
                    };

                    vncServerProcess.Start();
                    isRunning = true;                 // Cập nhật trạng thái server
                    btnListen.Text = "Stop";          // Đổi tên nút thành "Stop"
                    MessageBox.Show("TightVNC Server đã khởi động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy TightVNC Server tại đường dẫn:\n{vncServerPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động TightVNC Server:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm dừng TightVNC Server
        private void StopVncServer()
        {
            try
            {
                // Lấy danh sách tiến trình của TightVNC Server
                var processes = Process.GetProcessesByName("tvnserver"); // Lấy các tiến trình có tên tvnserver

                if (processes.Length > 0)
                {
                    foreach (var process in processes)
                    {
                        process.Kill();               // Dừng tiến trình
                        process.WaitForExit();        // Đợi tiến trình thoát hoàn toàn
                    }

                    // Xác nhận rằng server đã dừng
                    isRunning = false;
                    btnListen.Text = "Listen";       // Đổi trạng thái nút thành "Listen"
                    MessageBox.Show("TightVNC Server đã dừng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu không tìm thấy tiến trình, báo lỗi
                    MessageBox.Show("TightVNC Server không đang chạy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu không thể dừng
                MessageBox.Show($"Lỗi khi dừng TightVNC Server:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void IP_Click(object sender, EventArgs e)
        {

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
