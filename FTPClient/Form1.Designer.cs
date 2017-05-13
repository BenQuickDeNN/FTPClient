namespace FTPClient
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FtpServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_CtrlPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_DataPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_Upload = new System.Windows.Forms.Button();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.button_Download = new System.Windows.Forms.Button();
            this.progressBar_UploadFile = new System.Windows.Forms.ProgressBar();
            this.progressBar_download = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CtrlPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DataPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP Server";
            // 
            // textBox_FtpServer
            // 
            this.textBox_FtpServer.Location = new System.Drawing.Point(84, 10);
            this.textBox_FtpServer.Name = "textBox_FtpServer";
            this.textBox_FtpServer.Size = new System.Drawing.Size(397, 21);
            this.textBox_FtpServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ctrl Port";
            // 
            // numericUpDown_CtrlPort
            // 
            this.numericUpDown_CtrlPort.Location = new System.Drawing.Point(84, 35);
            this.numericUpDown_CtrlPort.Name = "numericUpDown_CtrlPort";
            this.numericUpDown_CtrlPort.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown_CtrlPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Port";
            // 
            // numericUpDown_DataPort
            // 
            this.numericUpDown_DataPort.Location = new System.Drawing.Point(84, 61);
            this.numericUpDown_DataPort.Name = "numericUpDown_DataPort";
            this.numericUpDown_DataPort.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown_DataPort.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "User";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(298, 35);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(183, 21);
            this.textBox_User.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(298, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 21);
            this.textBox1.TabIndex = 9;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(15, 97);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 10;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(129, 97);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            // 
            // button_Upload
            // 
            this.button_Upload.Location = new System.Drawing.Point(15, 488);
            this.button_Upload.Name = "button_Upload";
            this.button_Upload.Size = new System.Drawing.Size(75, 23);
            this.button_Upload.TabIndex = 12;
            this.button_Upload.Text = "Upload File";
            this.button_Upload.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Console
            // 
            this.richTextBox_Console.Location = new System.Drawing.Point(15, 127);
            this.richTextBox_Console.Name = "richTextBox_Console";
            this.richTextBox_Console.Size = new System.Drawing.Size(757, 355);
            this.richTextBox_Console.TabIndex = 13;
            this.richTextBox_Console.Text = "";
            // 
            // button_Download
            // 
            this.button_Download.Location = new System.Drawing.Point(15, 526);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(75, 23);
            this.button_Download.TabIndex = 14;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            // 
            // progressBar_UploadFile
            // 
            this.progressBar_UploadFile.Location = new System.Drawing.Point(96, 488);
            this.progressBar_UploadFile.Name = "progressBar_UploadFile";
            this.progressBar_UploadFile.Size = new System.Drawing.Size(676, 23);
            this.progressBar_UploadFile.TabIndex = 15;
            // 
            // progressBar_download
            // 
            this.progressBar_download.Location = new System.Drawing.Point(96, 526);
            this.progressBar_download.Name = "progressBar_download";
            this.progressBar_download.Size = new System.Drawing.Size(676, 23);
            this.progressBar_download.TabIndex = 16;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.progressBar_download);
            this.Controls.Add(this.progressBar_UploadFile);
            this.Controls.Add(this.button_Download);
            this.Controls.Add(this.richTextBox_Console);
            this.Controls.Add(this.button_Upload);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_DataPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_CtrlPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_FtpServer);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "FTPClient";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CtrlPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DataPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FtpServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_CtrlPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_DataPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_Upload;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.ProgressBar progressBar_UploadFile;
        private System.Windows.Forms.ProgressBar progressBar_download;
    }
}

