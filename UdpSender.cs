using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UdpTool
{
    class UdpSender
    {
        public static void send(string receiver_address, int port, string message)
        {
            using (UdpClient client = new UdpClient())
            {
                client.Connect(receiver_address, port);
                Byte[] send_bytes = Encoding.UTF8.GetBytes(message);
                client.Send(send_bytes, send_bytes.Length);
            }
        }
    }
}
