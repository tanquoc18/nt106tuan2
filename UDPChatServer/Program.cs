using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPServer
{
    static void Main()
    {
        // Tạo UdpClient để lắng nghe trên cổng 11000
        UdpClient udpServer = new UdpClient(11000);
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 11000);

        Console.WriteLine("Server đang lắng nghe...");

        while (true)
        {
            // Nhận dữ liệu từ client
            byte[] receiveBytes = udpServer.Receive(ref remoteEP);
            string receivedData = Encoding.UTF8.GetString(receiveBytes);
            Console.WriteLine($"Client: {receivedData}");

            // Gửi phản hồi lại cho client
            string responseData = $"Server đã nhận được: {receivedData}";
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseData);
            udpServer.Send(responseBytes, responseBytes.Length, remoteEP);
        }
    }
}
