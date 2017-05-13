using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPClient.FTPProtocol
{
    /// <summary>
    /// 辅助使用FTP协议
    /// </summary>
    class FTPHelper
    {
        public const int FTPCtrlPort = 21;
        /// <summary>
        /// 控制字结尾
        /// </summary>
        public const string SerialTail = "\r\n";
        /// <summary>
        /// 控制字-用户认证
        /// </summary>
        public const string CTRL_AUTH = "AUTH";
        public const string CTRL_USER = "USER";
        public const string CTRL_PASS = "PASS";
        public const string CTRL_QUIT = "QUIT";
        public const string CTRL_TYPE = "TYPE";
        public const string CTRL_PASV = "PASV";
        public const string CTRL_STOR = "STOR";

        SocketHelper socketHelper;

        /// <summary>
        /// 控制台输出框
        /// </summary>
        //RichTextBox richTextBoxConsole;
        public FTPHelper(RichTextBox richTextBoxConsole)
        {
            socketHelper = new SocketHelper(richTextBoxConsole);
        }
        /// <summary>
        /// 与服务器建立连接
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        public void ctrlConnect(string IP)
        {
            if (socketHelper == null) return;
            IPAddress ipAddress;
            if (!IPAddress.TryParse(IP, out ipAddress)) return;
            socketHelper.ctrlConnect(IP, FTPCtrlPort);
        }
        /// <summary>
        /// 提交认证用户
        /// </summary>
        /// <param name="user"></param>
        public void ctrlAuth(string user, string password)
        {
            if (socketHelper == null) return;
            Thread.Sleep(50);
            //socketHelper.sendCtrlMessage(CTRL_AUTH + " " + "TLS" + SerialTail);
            Thread.Sleep(50);
            //socketHelper.sendCtrlMessage(CTRL_AUTH + " " + "SSL" + SerialTail);
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_USER + " " + user + SerialTail, "");
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_PASS + " " + password + SerialTail, "");
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filename"></param>
        public void ctrlUpload(string filename)
        {
            if (socketHelper == null) return;
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_TYPE + " I" + SerialTail, "");// 传输二进制文件
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_PASV + SerialTail, "");
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_STOR + " " + Path.GetFileName(filename) + SerialTail, filename);
        }
        /// <summary>
        /// 与服务器断开连接
        /// </summary>
        public void ctrlDisconnect()
        {
            Thread.Sleep(50);
            socketHelper.sendCtrlMessage(CTRL_QUIT + SerialTail, "");
            socketHelper.ctrlDisconnect();
        }
    }
}
