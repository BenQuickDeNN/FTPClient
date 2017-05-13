/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace CMDMethod
{
    /// <summary>
    /// 专门执行控制台命令的类
    /// </summary>
    class CMDComand
    {
        /// <summary>
        /// 执行普通的CMD命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        public static void executeCMDComand(string command, string[] args, string path)
        {
            /* 调用系统调用选择打开方式 */
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //变换地址
            proc.StandardInput.WriteLine("cd " + path);
            proc.StandardInput.Flush();
            string totalString = command;
            for(int i = 0; i < args.Length; i++)
            {
                totalString += " " + args[i];
            }
            totalString += "\n";
            proc.StandardInput.WriteLine(totalString);
            proc.StandardInput.Flush();
        }
        /// <summary>
        /// 执行数据传送进程
        /// </summary>
        public static void executeDataTransferProcess(string ip, int port, string fileName)
        {
            string proPath = Path.GetFullPath(@"./FTPDataTransfer.exe");
            Process proc = new Process();
            proc.StartInfo.FileName = proPath;
            proc.StartInfo.Arguments = ip + " " + port.ToString() + " " + fileName;
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
        }
    }
}
