﻿using FTPClient.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FTPDownload
{
    class Program
    {
        Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket transferSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receiveByte = new byte[1024];
        FileStream fs;
        /// <summary>
        /// 32MB的文件缓冲区
        /// </summary>
        //byte[] fileByte = new byte[32 * 1024 * 1024];
        string FileName;
        /// <summary>
        /// 总文件大小，单位为字节
        /// </summary>
        int FileSize;
        /// <summary>
        /// 收到字节计数器
        /// </summary>
        int receiveCounter = 0;
        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                string ip = args[0];
                int port = int.Parse(args[1]);
                string fileName = args[2];
                int fileSize = int.Parse(args[3]);
                BugReport.report(new Exception(ip + " " + port.ToString() + " " + fileName + " " + fileSize.ToString()));
                Console.WriteLine("server ip : " + ip);
                Console.WriteLine("port : " + port.ToString());
                program.dataConnect(ip, port, fileName, fileSize);
                Thread.Sleep(1000);
                program.dataDisconnect();

            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                Console.WriteLine();
                BugReport.report(e);
            }
            //Console.ReadLine();
        }
        /// <summary>
        /// 数据传输端口连接进程
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void dataConnect(string ip, int port, string fileName, int fileSize)
        {
            if (dataSocket == null) dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
            FileName = Path.GetFullPath(fileName);
            FileSize = fileSize;
            fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            dataSocket.Connect(ipEndPoint);
            dataSocket.BeginReceive(receiveByte, 0, receiveByte.Length, 0, receiveCallBack, null);
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void dataDisconnect()
        {
            if (transferSocket != null) transferSocket.Disconnect(false);
            if (dataSocket == null) return;
            dataSocket.Disconnect(false);
        }
        /// <summary>
        /// 接收服务器的消息时的处理
        /// </summary>
        /// <param name="iar"></param>
        void receiveCallBack(IAsyncResult iar)
        {
            try
            {
                
                if (receiveCounter >= FileSize)
                {
                    fs.Write(receiveByte, 0, FileSize % receiveByte.Length);
                    fs.Close();
                }
                else
                {
                    fs.Write(receiveByte, 0, receiveByte.Length);
                    receiveCounter += receiveByte.Length;
                    dataSocket.BeginReceive(receiveByte, 0, receiveByte.Length, 0, receiveCallBack, null);
                }
            }
            catch (Exception e)
            {
                BugReport.report(e);
            }
        }
    }
}
