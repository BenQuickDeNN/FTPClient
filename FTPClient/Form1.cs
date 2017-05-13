using FTPClient.ConfigScript;
using FTPClient.FTPProtocol;
using FTPClient.Reporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class FormMain : Form
    {
        FTPHelper ftpHelper;
        public FormMain()
        {
            InitializeComponent();
            initializeWidget();
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        void initializeWidget()
        {
            Dictionary<string, string> configDict = ConfigFile.loadConfig();
            if(configDict == null)
            {
                MessageBox.Show("无法加载配置文件!");
                return;
            }
            try
            {
                textBox_FtpServer.Text = configDict[ConfigFile.FTPServer];
                textBox_User.Text = configDict[ConfigFile.User];
                textBox_Password.Text = configDict[ConfigFile.Password];
                numericUpDown_CtrlPort.Value = int.Parse(configDict[ConfigFile.CtrlPort]);
                numericUpDown_DataPort.Value = int.Parse(configDict[ConfigFile.DataPort]);
            }
            catch(Exception e)
            {
                BugReport.report(e);
            }
            button_disconnect.Enabled = false;
            button_Download.Enabled = false;
            button_Upload.Enabled = false;
        }
        /// <summary>
        /// 控件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void widgetClickEvent(object sender, EventArgs args)
        {
            if (sender.Equals(button_connect)) event_Connect();
            if (sender.Equals(button_disconnect)) event_Disconnect();
            if (sender.Equals(button_Upload)) event_Upload();
        }
        /// <summary>
        /// 连接事件
        /// </summary>
        void event_Connect()
        {
            /* 保存当前配置 */
            Dictionary<string, string> configDict = new Dictionary<string, string>();
            configDict.Add(ConfigFile.FTPServer, textBox_FtpServer.Text);
            configDict.Add(ConfigFile.CtrlPort, numericUpDown_CtrlPort.Value.ToString());
            configDict.Add(ConfigFile.DataPort, numericUpDown_DataPort.Value.ToString());
            configDict.Add(ConfigFile.User, textBox_User.Text);
            configDict.Add(ConfigFile.Password, textBox_Password.Text);
            ConfigFile.saveConfig(configDict);
            /* 开始连接 */
            ftpHelper = new FTPHelper(richTextBox_Console);
            ftpHelper.ctrlConnect(textBox_FtpServer.Text);

            button_disconnect.Enabled = true;
            button_connect.Enabled = false;
            button_Upload.Enabled = true;
            button_Download.Enabled = true;

            Thread.Sleep(50);
            ftpHelper.ctrlAuth(textBox_User.Text, textBox_Password.Text);
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        void event_Disconnect()
        {
            if (ftpHelper == null) return;
            ftpHelper.ctrlDisconnect();
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            button_Upload.Enabled = false;
            button_Download.Enabled = false;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        void event_Upload()
        {
            if (ftpHelper == null) return;
            if (openFileDialog_upload.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog_upload.FileName;
                ftpHelper.ctrlUpload(filePath);
            }
        }
    }
}
