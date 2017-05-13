using FTPClient.Reporter;
using StringAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPClient.FTPProtocol
{
    /// <summary>
    /// 辅助Socket操作
    /// </summary>
    class SocketHelper
    {
        Socket ctrlSocket;
        string ServerIP;
        string FileName;
        int FileSize;
        bool IsUpload = false;
        byte[] receiveByte = new byte[64 * 1024];
        AsyncCallback asyncCallback;
        /// <summary>
        /// 控制台引用
        /// </summary>
        RichTextBox richTextBoxConsole;
        public SocketHelper(RichTextBox richTextBoxConsole)
        {
            ctrlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            asyncCallback = new AsyncCallback(this.receiveCallBack);
            this.richTextBoxConsole = richTextBoxConsole;
        }
        /// <summary>
        /// 控制连接
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        public void ctrlConnect(string IP, int ctrlPort)
        {
            if (ctrlSocket == null) return;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), ctrlPort);
            ServerIP = IP;
            ctrlSocket.Connect(ipEndPoint);
            ctrlSocket.BeginReceive(receiveByte, 0, receiveByte.Length, 0, asyncCallback, null);
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void ctrlDisconnect()
        {
            ctrlSocket.Disconnect(true);
            richTextBoxConsole.Invoke(new MethodInvoker(delegate
            {
                richTextBoxConsole.AppendText(DateTime.Now.ToString() + "\n" + "disconnect" + "\n");
            }));
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void sendCtrlMessage(string msg, string fileName, bool isUpload)
        {
            if (ctrlSocket == null) return;
            if (!ctrlSocket.Connected) return;
            byte[] msgByte = Encoding.ASCII.GetBytes(msg);
            FileName = fileName;
            IsUpload = isUpload;
            ctrlSocket.Send(msgByte);
        }
        /// <summary>
        /// 接收服务器的消息时的处理
        /// </summary>
        /// <param name="iar"></param>
        void receiveCallBack(IAsyncResult iar)
        {
            try
            {
                int REnd = ctrlSocket.EndReceive(iar);
                string receive_content = Encoding.ASCII.GetString(receiveByte, 0, REnd);
                Reporter.BugReport.reportFTPLog(receive_content);
                richTextBoxConsole.Invoke(new MethodInvoker(delegate
                {
                    richTextBoxConsole.AppendText(DateTime.Now.ToString() + "\n" + receive_content + "\n");
                }));
                /* PASSIVE模式传输文件，获取传输端口号 */
                if(receive_content.Contains("227 Entering Passive Mode"))
                {
                    int startIndex = receive_content.IndexOf('(') + 1;
                    string param_s = receive_content.Substring(receive_content.IndexOf('(') + 1, receive_content.Length - startIndex - 3);
                    /*
                    richTextBoxConsole.Invoke(new MethodInvoker(delegate
                    {
                        richTextBoxConsole.AppendText(DateTime.Now.ToString() + "\n" + param_s + "\n");
                    }));*/
                    int num1 = int.Parse(CodeAnalysis.getValueString("port_param " + param_s)[4]);
                    int num2 = int.Parse(CodeAnalysis.getValueString("port_param " + param_s)[5]);
                    int dataPort = num1 * 256 + num2;
                    richTextBoxConsole.Invoke(new MethodInvoker(delegate
                    {
                        richTextBoxConsole.AppendText(DateTime.Now.ToString() + "\n" + "get data port : " + dataPort.ToString() + "\n");
                    }));
                    lock (ServerIP)
                    {
                        /* 启动数据传输进程 */
                        if (IsUpload) CMDMethod.CMDComand.executeDataTransferProcess(ServerIP, dataPort, FileName);
                        else CMDMethod.CMDComand.executeDataDownloadProcess(ServerIP, dataPort, FileName, FileSize);
                    }
                }
                /* 获取文件尺寸 */
                else if(receive_content.Contains("213 "))
                {
                    FileSize = int.Parse(CodeAnalysis.getValueString(receive_content)[0]);
                }
                ctrlSocket.BeginReceive(receiveByte, 0, receiveByte.Length, 0, asyncCallback, null);
            }
            catch (Exception e)
            {
                BugReport.report(e);
            }
        }
    }
}
