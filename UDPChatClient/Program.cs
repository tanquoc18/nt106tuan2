using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPClient
{
    static void Main()
    {
        // Tạo socket cho client
        Socket udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPAddress serverIP = IPAddress.Parse("127.0.0.1"); // Địa chỉ IP của server
        IPEndPoint remoteEP = new IPEndPoint(serverIP, 11000);

        while (true)
        {
            Console.Write("Nhập tin nhắn: ");
            string message = Console.ReadLine();

            // Gửi dữ liệu đến server
            byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            udpClient.SendTo(sendBytes, remoteEP);

            // Nhận phản hồi từ server
            byte[] buffer = new byte[1024];
            EndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);
            int receivedBytes = udpClient.ReceiveFrom(buffer, ref serverEP);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
            Console.WriteLine(receivedMessage);
        }
    }
}
