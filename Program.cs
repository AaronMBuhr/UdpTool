using System;

namespace UdpTool
{
    class Program
    {
        const string help = @"*UdpTool* Usage:
UdpTool send remoteaddress port [num]
which is the same as:
UdpTool s remoteaddress port [num]
or
UdpTool receive port
which is the same as:
UdpTool r port
";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine(help);
                return;
            }
            if (args[0].ToLower().StartsWith("s"))
            {
                Console.WriteLine("Enter your message:");
                string message = Console.ReadLine();
                int count = args.Length > 3 ? int.Parse(args[3]) : 1;
                for (int n = 0; n < count; ++n)
                {
                    UdpSender.send(args[1], int.Parse(args[2]), message);
                    Console.WriteLine("Message sent to {0}:{1}", args[1], args[2]);
                }
            }
            else if (args[0].ToLower().StartsWith("r"))
            {
                Console.WriteLine("Receiving on port {0}", args[1]);
                while (true)
                {
                    string message = UdpReceiver.receive(int.Parse(args[1]));
                    Console.WriteLine("Message received:");
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine(help);
                return;
            }
        }
    }
}
