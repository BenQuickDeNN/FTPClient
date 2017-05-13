using FTPClient.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FTPDataTransfer
{
    /// <summary>
    /// 数据传输进程
    /// </summary>
    class Program
    {
        Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket transferSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                string ip = args[0];
                int port = int.Parse(args[1]);
                string fileName = args[2];
                BugReport.report(new Exception(ip + " " + port.ToString() + " " + fileName));
                Console.WriteLine("server ip : " + ip);
                Console.WriteLine("port : " + port.ToString());
                program.dataConnect(ip, port, fileName);
                Thread.Sleep(50);
                program.dataDisconnect();
                
            }
            catch(Exception e)
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
        public void dataConnect(string ip, int port, string fileName)
        {
            if (dataSocket == null) dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
            dataSocket.Connect(ipEndPoint);
            if (File.Exists(fileName))
            {
                dataSocket.SendFile(fileName);
            }
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
    }
}
