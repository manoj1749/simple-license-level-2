using System;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Runtime.InteropServices;

public class Program
{

    public static void Main(string[] args)
    {
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

        // In Windows we are going to bind to the loopback address
        // In Docker we have to bind to the actual IPAddress in order to make it accessible from outside
        // The decision to bind to ip or loopback is done based on an environment variable bind_ip

        IPAddress hostIP = null;
        hostIP = IPAddress.Loopback;
        //Console.WriteLine(hostIP);

        if (hostIP == null) throw new ArgumentException("No valid IPv4 IPAddress to bind to");

        IPEndPoint ep = new IPEndPoint(hostIP, 8080);
        //Console.WriteLine(ep);
        listenSocket.Bind(ep);
        listenSocket.Listen(1);
        //Console.WriteLine("1");

        while (true)
        {
            Socket clientSocket = listenSocket.Accept();
            byte[] buffer = new byte[1024];
            //Console.WriteLine("2");
            int received = clientSocket.Receive(buffer);
            byte[] data = new byte[received];
            //Console.WriteLine("3");
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            if (text == "10")
            {
                //Console.WriteLine("4");
                byte[] msg = Encoding.ASCII.GetBytes("1");
                clientSocket.Send(msg, msg.Length, 0);
                int rec = clientSocket.Receive(buffer);
                byte[] data1 = new byte[rec];
                //Console.WriteLine("3");
                Array.Copy(buffer, data1, rec);
                string text1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine("Received: {0}", text1);
                string license = Convert.ToBase64String(data1);
                if (license == "MTA4MjExMTQwOQ==")
                {
                    byte[] msg1 = Encoding.ASCII.GetBytes("cyberchaze{35#xmYii&PY5#ch#gH^6ey}");
                    clientSocket.Send(msg1, msg1.Length, 0);
                }
                else
                {
                    byte[] msg2 = Encoding.ASCII.GetBytes("Invalid License Key");
                    clientSocket.Send(msg2, msg2.Length, 0);
                }
                //byte[] response = Encoding.ASCII.GetBytes("cyberchaze{35#xmYii&PY5#ch#gH^6ey}");
                //Console.WriteLine(Encoding.ASCII.GetString(response));
                //clientSocket.Send(response);
                clientSocket.Close();
            }
            else
            {
                //Console.WriteLine("5");
                byte[] msg = Encoding.ASCII.GetBytes("0");
                clientSocket.Send(msg, msg.Length, 0);
                clientSocket.Close();
            }
        }
    }
}