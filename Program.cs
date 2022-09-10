using System;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
// To be removed from obfuscated build
using System.Numerics;

namespace appgui;


public class Form1 : Form
{
    public Button button1;
    public Button button2;
    public TextBox textInputTextBox;
    public Button textInputeButton;
    //public bool license_valid;
    //public MainMenu Menu;
    public Form1()
    {
        //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        //IPAddress ipAddress = ipHostInfo.AddressList[0];
        //IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

        // Create a TCP/IP  socket.  
        //Socket sender = new Socket(ipAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
        //sender.Connect(remoteEP);

        //Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
		MessageBox.Show("Socket connected");
        Size = new Size(150, 150);
        button2 = new Button();
        button2.Size = new Size(60, 20);
        button2.Location = new Point(35, 45);
        button2.Text = "License";
        this.Controls.Add(button2);
        button2.Click += new EventHandler(license_click);
    }

    private void license_click(object sender, EventArgs e)
    {
        int size = -1;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            if (check_license(openFileDialog1.FileName))
            {
                MessageBox.Show("cyberchaze{35#xmYii&PY5#ch#gH^6ey}");
            }
            else
            {
                MessageBox.Show("Invalid license file");
            }
        }
    }

    private static byte[] read_file(string path)
    {
        if (File.Exists(path))
        {
            var lic_stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var bin_reader = new BinaryReader(lic_stream, Encoding.UTF8, false);
            var fsz = new System.IO.FileInfo(path).Length;
            byte[] fbuf = new byte[fsz];
            bin_reader.Read(fbuf, 0, (int)fsz);
            bin_reader.Close();
            return fbuf;
        }
        else
        {
            throw new ArgumentException("Invalid path");
        }
    }

    public static bool check_license(string license_file = "license.dat")
    {
        var fbuf = read_file(license_file);
        SHA256 shHash = SHA256.Create();
        byte[] hashValue = shHash.ComputeHash(fbuf);
        //MessageBox.Show(Convert.ToBase64String(hashValue));
        return (Convert.ToBase64String(hashValue) == "PXiO+35VWUQJ1Mh02g8A0LdK5OE4f8npLY3ZlXjp5MA=");
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}