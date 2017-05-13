using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPClient.DiaglogWindow
{
    public partial class DownloadFile : Form
    {
        public string DownLoadFileName
        {
            get { return textBox_FileName.Text; }
            set { textBox_FileName.Text = value; }
        }

        public DownloadFile()
        {
            InitializeComponent();
        }
    }
}
