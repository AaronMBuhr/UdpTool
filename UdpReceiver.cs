using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace UdpTool
{
    public class UdpReceiver
    {
        public static string receive(int port)
        {
            return receive(port, out _);
        }

        public static string receive(int port, out string sender_ip_address)
        {
            using (UdpClient client = new UdpClient(port))
            {
                IPEndPoint sender_ip_endpoint = new IPEndPoint(IPAddress.Any, 0);
                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = client.Receive(ref sender_ip_endpoint);
                sender_ip_address = sender_ip_endpoint.Address.ToString();
                return Encoding.ASCII.GetString(receiveBytes);
            }
        }
    }
}
