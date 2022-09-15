﻿using System;
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
        var ip = "192.168.64.4";
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            if (check_license(openFileDialog1.FileName))
            {
                byte[] msg = Encoding.ASCII.GetBytes("Hi");
                byte[] rec = null;
                MessageBox.Show("1");
                IPAddress address = IPAddress.Parse(ip);
                MessageBox.Show(ip);
                MessageBox.Show(address.ToString());
                MessageBox.Show("2");
                IPEndPoint endPoint = new IPEndPoint(address, 8080);
                MessageBox.Show(endPoint.ToString());
                MessageBox.Show("3");
                Socket Sock = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                MessageBox.Show(Sock.ToString());
                MessageBox.Show("4");
                Sock.Connect(endPoint);
                MessageBox.Show(endPoint.ToString());
                MessageBox.Show("5");
                Sock.Send(msg, msg.Length, 0);
                object value = Sock.Receive(rec, rec.Length, 0);
                MessageBox.Show(Encoding.ASCII.GetString(rec));
                MessageBox.Show("6");
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
        byte[] hashValue = fbuf;
        //MessageBox.Show(Convert.ToBase64String(hashValue));
        return (Convert.ToBase64String(hashValue) == "MTIzNDcyMzA5NTcyMzkwNTM=");
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