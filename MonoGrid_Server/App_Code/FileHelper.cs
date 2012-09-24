using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Net;


public static class FileHelper
{

    public static void Grand(string path, string name)
    {
        System.IO.Directory.SetCurrentDirectory(path);
        Process.Start("sudo chmod 777 " + name + " -R");
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


        if (output == "")
            return false;
        else
            return true;
    }

    /// <summary>
    /// 从网络上下载文件到服务器
    /// </summary>
    /// <param name="url"></param>
    /// <param name="filename"></param>
    /// <param name="pagecode"></param>
    public static void DownUrltoFile(string url, string filename, string pagecode)
    {
        try
        {
            //编码
            Encoding encode = Encoding.GetEncoding(pagecode);
            //请求URL
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //设置超时(60秒)
            req.Timeout = 60000;
            NotFolderIsCreate(filename);
            //获取Response
            HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
            //创建StreamReader与StreamWriter文件流对象
            StreamReader sr = new StreamReader(rep.GetResponseStream(), encode);
            StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(filename), false, encode);
            //写入内容
            sw.Write(sr.ReadToEnd());
            //清理当前缓存区，并将缓存写入文件
            sw.Flush();
            //释放相关对象资源
            sw.Close();
            sw.Dispose();
            sr.Close();
            sr.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
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
    }

    /// <summary>
    /// 分割任务mol2文件，待改进
    /// </summary>
    /// <param name="taskID">任务</param>
    public static void DivideFile(string taskID, int molCount, int molDiv, string Path)
    {
        string filePath = Path + @"/" + taskID + @".mol2";
        StreamReader file = new StreamReader(filePath);

        string line;//一行内容
        List<string> temp = new List<string>();

        int singleMolCount = 0;//单个子文件中mol的计数器
        int sumMolCount = 0;//总mol的计数器
        int fileNum = 0;

        while ((line = file.ReadLine()) != null)
        {
            temp.Add(line);
            if (line == "@<TRIPOS>SUBSTRUCTURE")
            {
                singleMolCount++; sumMolCount++;

                //满molDiv个mol，写入一个子文件（考虑最后的余数）
                if ((singleMolCount % molDiv == 0) && (singleMolCount != 0) || (sumMolCount == molCount))
                {
                    temp.Add(file.ReadLine());
                    //读完此mol最后一行，方面后面写入文件

                    string childPath = Path + "//" + taskID + "_" + fileNum++ + @".mol2";
                    WriteFile(childPath, temp);

                    temp = new List<string>();//准备下一次写文件
                    singleMolCount = 0;
                }
            }
        }
        file.Close();
    }

    private static void WriteFile(string path, List<string> content)
    {
        string fileAtDir = Path.GetDirectoryName(path);
        if (!Directory.Exists(fileAtDir))
            Directory.CreateDirectory(fileAtDir);

        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
        {
            foreach (string item in content)
            {
                sw.WriteLine(item);
            }
        }
    }
}
