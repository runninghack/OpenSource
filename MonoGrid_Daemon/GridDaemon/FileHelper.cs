using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace GridDaemon
{

    public static class FileHelper
    {



        public static void Grand(string path, string name)
        {
//            System.IO.Directory.SetCurrentDirectory(path);
//            Process.Start("sudo chmod 777 " + name + " -R");
//
//            ConsoleHelper.Show("授予 " + path + " 目录读写权限");
        }

        public static bool CheckDock(string DockPath)
        {
            //试运行
            Process myProcess = new Process();
            //string viewFiles = "tar -tf " + fileName + " ";
            myProcess.StartInfo.FileName = DockPath;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            // myProcess.StartInfo.Arguments = "-c ' " + viewFiles + " ' ";
            myProcess.Start();
            string output = myProcess.StandardOutput.ReadToEnd();
            myProcess.Close();


            if (output.IndexOf("DOCK v6.2") > -1)

                return true;
            else
            {
                ConsoleHelper.Warn("Dock程序试运行异常");
                return false;
            }
        }



        /// <summary>
        /// 文件夹不存在则创建
        /// </summary>
        /// <param name="filename">文件名所在路径</param>
        public static void NotFolderIsCreate(string filename)
        {
            string fileAtDir = Path.GetDirectoryName(filename);
            if (!Directory.Exists(fileAtDir))
                Directory.CreateDirectory(fileAtDir);
            ConsoleHelper.Show("创建"+fileAtDir +"目录");
        }

        /// <summary>
        /// 修改文本文件某行内容
        /// </summary>
        /// <param name="curLine">要修改的行数</param>
        /// <param name="newLineValue">改行修改成的文本</param>
        /// <param name="patch">文件地址</param>
        public static void EditFile2(int curLine, string newLineValue, string patch)
        {
            FileStream fs = new FileStream(patch, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8"));
            string line = sr.ReadLine();
            StringBuilder sb = new StringBuilder();

//            if (curLine == 1)
//            {
//                sr.ReadLine();
//                line = newLineValue;
//            }

            for (int i = 1; line != null; i++)
            {
                sb.Append(line + "\r\n");
                if (i != curLine - 1)
                    line = sr.ReadLine();
                else
                {
                    sr.ReadLine();
                    line = newLineValue;
                }
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream(patch, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.Write(sb.ToString());
            sw.Close();
            fs.Close();
            ConsoleHelper.Show("编辑Dock的配置文件"+patch);
        }
		
		/// <summary>
        /// 修改文本文件某行内容
        /// </summary>
        /// <param name="newLineValue">改行修改成的文本</param>
        /// <param name="patch">文件地址</param>
        public static void EditFile(string newLineValue, string path)
        {
            string[] content = File.ReadAllLines(path);
			content[0]=newLineValue;
            File.WriteAllLines(path, content);
            ConsoleHelper.Show("编辑Dock的配置文件" + path);
        }
		
        /// <summary>
        /// 运行dock并计算
        /// </summary>
        /// <param name="dockPath">dock软件地址</param>
        /// <param name="filePath">dock.in文件的地址</param>
        public static void RunDock(string dockPath)
        {
            ConsoleHelper.Show("运行Dock程序开始计算");
            System.IO.Directory.SetCurrentDirectory(dockPath);
            Process.Start("./dock6", "-i dock.in");
        }

    }
}