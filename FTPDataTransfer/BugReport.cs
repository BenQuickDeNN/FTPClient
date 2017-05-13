using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FTPClient.Reporter
{
    class BugReport
    {
        /// <summary>
        /// Bug报告文件地址
        /// </summary>
        const string BugReportFilePath = @"./dataTransfer_report.log";
        /// <summary>
        /// 生成bug报告
        /// </summary>
        /// <param name="e"></param>
        public static void report(Exception e)
        {
            try
            {
                StreamWriter bugWriter = new StreamWriter(BugReportFilePath, true, Encoding.Default);
                bugWriter.WriteLine(DateTime.Now.ToString());
                bugWriter.Write(e.ToString());
                bugWriter.WriteLine("");
                bugWriter.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
