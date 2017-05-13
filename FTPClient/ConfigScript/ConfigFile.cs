using FTPClient.Reporter;
using StringAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FTPClient.ConfigScript
{
    class ConfigFile
    {
        const string CONFIG_PATH = @"./config/config.conf";
        public const string FTPServer = "FTPServer";
        public const string CtrlPort = "CtrlPort";
        public const string DataPort = "DataPort";
        public const string User = "User";
        public const string Password = "Password";
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> loadConfig()
        {
            try
            {
                Dictionary<string, string> configContent = new Dictionary<string, string>();
                StreamReader configReader = new StreamReader(CONFIG_PATH, Encoding.UTF8);
                string line = "";
                string item = "";
                string value = "";
                while((line = configReader.ReadLine())!=null)
                {
                    item = CodeAnalysis.getCommandString(line);
                    value = CodeAnalysis.getValueString(line)[0];
                    if (!string.IsNullOrEmpty(item) && !configContent.ContainsKey(item)) configContent.Add(item, value);
                }
                configReader.Close();
                return configContent;
            }
            catch(Exception e)
            {
                BugReport.report(e);
                return null;
            }
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configContent"></param>
        public static void saveConfig(Dictionary<string, string> configContent)
        {
            if (configContent == null) return;
            try
            {
                StreamWriter configWriter = new StreamWriter(CONFIG_PATH, false, Encoding.UTF8);
                if (configContent.ContainsKey(FTPServer)) configWriter.WriteLine(FTPServer + " " + configContent[FTPServer]);
                if (configContent.ContainsKey(CtrlPort)) configWriter.WriteLine(CtrlPort + " " + configContent[CtrlPort]);
                if (configContent.ContainsKey(DataPort)) configWriter.WriteLine(DataPort + " " + configContent[DataPort]);
                if (configContent.ContainsKey(User)) configWriter.WriteLine(User + " " + configContent[User]);
                if (configContent.ContainsKey(Password)) configWriter.WriteLine(Password + " " + configContent[Password]);
                configWriter.Close();
            }
            catch(Exception e)
            {
                BugReport.report(e);
            }
        }
    }
}
