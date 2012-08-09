using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GridDaemon
{
   public static  class ConfigHelper
    {
       public static void ConfigStart()
       {
           string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
           if (!File.Exists(AppPath+@"/config.ini"))
           {
               CreateConfigFile();
               ConsoleHelper.Warn("未找到配置文件！");
               ConsoleHelper.Show("在 " + AppPath + " 目录建立config.ini文件，请选择性修改配置信息");
           }
           else
           {
               ConsoleHelper.Show("配置文件存在");
           }
       }

        public static void CreateConfigFile()
        {
            //获取exe文件执行的目录
            string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = AppPath + @"/config.ini";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(@"MainFolder:                             /home/bigstep/www/Files");
                    sw.WriteLine(@"ServerIP:                                192.168.1.11");
                    //sw.WriteLine(@"ConnectionString:                     server=192.168.1.11;database=MonoGrid;user=root;pwd=123456;");
                    sw.WriteLine(@"DockFolder:                             /home/wangliang/www/dock6");
                }
            }
        }

        public static string ReadParameter(string PName)
        {
            string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string PString = File.ReadAllLines(AppPath+@"/config.ini").First<string>(s => s.StartsWith(PName));

            ConsoleHelper.Show("读取配置文件中 " + PName + " 信息");
            return PString.Substring(PString.LastIndexOf(':')+1).Trim();
        }
    }
}
