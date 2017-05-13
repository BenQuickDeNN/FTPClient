using FTPClient.Reporter;
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
        Socket dataSocket;
        byte[] receiveByte = new byte[64 * 1024];
        AsyncCallback asyncCallback;
        /// <summary>
        /// 控制台引用
        /// </summary>
        RichTextBox richTextBoxConsole;
        public SocketHelper(RichTextBox richTextBoxConsole)
        {
            ctrlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            if (dataSocket == null) return;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), ctrlPort);
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
        public void sendCtrlMessage(string msg)
        {
            if (ctrlSocket == null) return;
            if (!ctrlSocket.Connected) return;
            byte[] msgByte = Encoding.ASCII.GetBytes(msg);
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
                string receive_content = Encoding.UTF8.GetString(receiveByte, 0, REnd);
                richTextBoxConsole.Invoke(new MethodInvoker(delegate
                {
                    richTextBoxConsole.AppendText(DateTime.Now.ToString() + "\n" + receive_content + "\n");
                }));
                ctrlSocket.BeginReceive(receiveByte, 0, receiveByte.Length, 0, asyncCallback, null);
            }
            catch (Exception e)
            {
                BugReport.report(e);
            }
        }
    }
}
