using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace UDPCode
{
    class UDPTransport
    {
        static Thread threadRecv = null;
        static IPEndPoint hostRecv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8898);
        static IPEndPoint hostSend = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8899);
        static UdpClient udpRecv = null;
        static UdpClient udpSend = null;

        static void StartSend()
        {
            string message = "Hello,World!";
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpSend = new UdpClient(hostSend);
            for (int i = 0; i < 10; i++)
                udpSend.Send(data, data.Length, hostRecv);
        }

        static void StartReceive()
        {
            string message = null;
            byte[] data = null;
            udpRecv = new UdpClient(hostRecv);
            while(true)
            {
                data = udpRecv.Receive(ref hostRecv);
                message = Encoding.UTF8.GetString(data, 0, data.Length);
                Console.WriteLine(string.Format("{0}[{1}]", hostRecv, message));
            }
        }

        static void Main()
        {
            threadRecv = new Thread(StartReceive);
            threadRecv.Start();
            //while(true)
            StartSend();
        }
    }
}
