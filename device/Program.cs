using System;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;	
using System.Collections;
using System.Runtime.InteropServices;

public class Program{

	public static void Main(string[] args)
    {	
        var bind_ip = "127.0.0.1";
		Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

                // In Windows we are going to bind to the loopback address
                // In Docker we have to bind to the actual IPAddress in order to make it accessible from outside
                // The decision to bind to ip or loopback is done based on an environment variable bind_ip

                IPAddress hostIP = null;
                if(String.IsNullOrEmpty(bind_ip)){
                        hostIP = IPAddress.Loopback;
                }else{
                        for(int i=0; i< ipHostInfo.AddressList.Length; i++){
                                if(ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork) hostIP = ipHostInfo.AddressList[i];
                        }
                }
                
                if(hostIP == null) throw new ArgumentException("No valid IPv4 IPAddress to bind to");
                
		IPEndPoint ep = new IPEndPoint(hostIP,8080);
		listenSocket.Bind(ep);
		listenSocket.Listen(1);
		
		while(true)	{
			Socket clientSocket = listenSocket.Accept();
            byte[] buffer = new byte[1024];
            int received = clientSocket.Receive(buffer);
            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            Console.WriteLine("Received: {0}", text);
            byte[] response = Encoding.ASCII.GetBytes("Hello World!");
            clientSocket.Send(response);
            clientSocket.Close();
		}
    }
}