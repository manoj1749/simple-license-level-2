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
        Label ip_label = new Label();
        ip_label.Text = "License Key";
        ip_label.Location = new Point(25, 30);
        ip_label.AutoSize = true;
        ip_label.Font = new Font("Calibri", 10);
        ip_label.Padding = new Padding(6);
        this.Controls.Add(ip_label);

        textInputTextBox = new TextBox();
        textInputTextBox.Location = new Point(110, 30);
        textInputTextBox.Size = new Size(120, 20);
        this.Controls.Add(textInputTextBox);

        Size = new Size(300, 150);
        button2 = new Button();
        button2.Size = new Size(60, 25);
        button2.Location = new Point(120, 60);
        button2.Text = "Run";
        this.Controls.Add(button2);
        button2.Click += new EventHandler(license_click);
    }

    private int countChars(string str)
    {
        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            
            
                count++;
        }
        return count;
    }

    private void license_click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textInputTextBox.Text))
        {
            MessageBox.Show("Please enter a valid license key");
            return;
        }
        else if (countChars(textInputTextBox.Text) != 10)
        {
            MessageBox.Show("license key isn't of required length");
            return;
        }
        else
        {
            var ip = "127.0.0.1";
            byte[] msg = Encoding.ASCII.GetBytes(textInputTextBox.Text/*123456789*/);
            //MessageBox.Show("1");
            IPAddress address = IPAddress.Parse(ip);
            //MessageBox.Show(ip);
            //MessageBox.Show(address.ToString());
            //MessageBox.Show("2");
            IPEndPoint endPoint = new IPEndPoint(address, 8080);
            //MessageBox.Show(endPoint.ToString());
            //MessageBox.Show("3");
            Socket Sock = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //MessageBox.Show("4");
            Sock.Connect(endPoint);
            //MessageBox.Show(endPoint.ToString());
            //MessageBox.Show("5");
            Sock.Send(msg, msg.Length, 0);
            byte[] buffer = new byte[1024];
            int recieved = Sock.Receive(buffer);
            byte[] data = new byte[recieved];
            Array.Copy(buffer, data, recieved);
            MessageBox.Show(Encoding.ASCII.GetString(data));
            //MessageBox.Show("6");
            Sock.Close();
        }
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