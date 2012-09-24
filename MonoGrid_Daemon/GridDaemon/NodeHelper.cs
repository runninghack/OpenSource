using System;
using System.Net;
//For GetIP () function
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace GridDaemon
{
    public static class NodeHelper
    {
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress ip in ips)
            {
                string tempIP = ip.ToString();
                if (tempIP != "127.0.0.1" && tempIP != "::1")
                {
                    return tempIP;
                }
            }
            return "error";
        }

        /// <summary>
        /// 获取本机CPU简要信息
        /// </summary>
        /// <returns></returns>
        public static string GetCPUInfo()
        {
            return System.IO.File.ReadAllLines(@"/proc/cpuinfo").First(s => s.StartsWith("model name")).Substring(13);
        }


        private static float[] GetCpuState()
        {
            char[] separators = new char[] { ' ', ',' };

            string[] content = System.IO.File.ReadAllLines(@"/proc/stat");
            string infoString = content[0];
            string[] parts = infoString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            float[] frmes = new float[7];
            for (int i = 1; i <= 7; i++)
            {
                frmes[i - 1] = float.Parse(parts[i]);
            }
            return frmes;
        }

        /// <summary>
        /// 获取CPU利用率
        /// </summary>
        /// <returns></returns>
        public static float GetCpuUsage()
        {
            //第一次取值
            float[] frmes1 = GetCpuState();
            System.Threading.Thread.Sleep(1000);
            //第二次取值
            float[] frmes2 = GetCpuState();

            //根据两次取值结果进行计算
            return (1.0f - (frmes2[3] - frmes1[3]) / (frmes2.Sum() - frmes1.Sum()));
        }

        /// <summary>
        /// 下载piece文件
        /// </summary>
        /// <param name="targetPiece">需要下载的Piece</param>
        public static void DownloadPiece(TaskPiece targetPiece, string MainFolder, string ServerIP)
        {
            string remoteFolderPath = @"/Files/Upload/" + targetPiece.TaskID + "/";
            string folderName = targetPiece.TaskID + "_" + targetPiece.NoInGroup;
            string localFolderPath = MainFolder + "/" + folderName + "/";
            string molName = folderName + @".mol2";

            if (!Directory.Exists(localFolderPath))
                Directory.CreateDirectory(localFolderPath);

            WebClient myClient = new WebClient();

            //例:  /Files/Upload/20110102030405/20110102030405_6.mol2		
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + molName, localFolderPath + molName);
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "dock.in", localFolderPath + "dock.in");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "flex.defn", localFolderPath + "flex.defn");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "flex_drive.tbl", localFolderPath + "flex_drive.tbl");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "grid_2.bmp", localFolderPath + "grid_2.bmp");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "grid_2.cnt", localFolderPath + "grid_2.cnt");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "grid_2.nrg", localFolderPath + "grid_2.nrg");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "site_4ang_sc_4ang_pro.sph", localFolderPath + "site_4ang_sc_4ang_pro.sph");
            myClient.DownloadFile("http://" + ServerIP + remoteFolderPath + "vdw.defn", localFolderPath + "vdw.defn");

            File.Copy(MainFolder + @"/dock6", localFolderPath + "dock6");

            FileHelper.Grand(MainFolder, folderName);
            configDockin(localFolderPath + "dock.in", folderName);
        }

        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="filepath">dock.in文件的路径</param>
        /// <param name="molName">mol的名称</param>
        public static void configDockin(string filepath, string molName)
        {
            FileHelper.EditFile(@"ligand_atom_file                                             " + molName + ".mol2", filepath);
        }


        /// <summary>
        /// 查看本地是否已经运算完成
        /// </summary>
        /// <param name="resultPath">结果文件地址</param>
        /// <returns></returns>
        public static bool CheckPFinish(string molName, int molDiv, string MainFolder)
        {
            string resFilePath = MainFolder + "/" + molName + "/output_scored.mol2";
            //！！！！！！！！！！！！！！！
            string[] molStrings = System.IO.File.ReadAllLines(resFilePath);
            int resCount = molStrings.Count(s => s == "@<TRIPOS>MOLECULE");

            if (resCount == molDiv)
            {
                return true;
            }

            string molFilePath = MainFolder + "/" + molName + "/" + molName + ".mol2";
            //！！！！！！！！！！！！！！
            string[] molStrings2 = System.IO.File.ReadAllLines(molFilePath);
            int molCountInFile = molStrings2.Count(s => s == "@<TRIPOS>MOLECULE");
            if (resCount == molCountInFile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 初始化Node
        /// </summary>
        /// <param name="mg">数据库DataContext</param>
        /// <returns>初始化后的本地Node</returns>
        public static Node InitNode(MonoGrid mg)
        {
            string Ip = NodeHelper.GetIP();
            if (Ip == "error")
            {
                ConsoleHelper.Warn("获取IP失败，请检查网络情况！");
            }
            Node tempNode = null;
            try
            {
                tempNode = mg.Node.First(n => n.Ip == Ip);
                //tempNode.CpuUse = (int)(NodeHelper.GetCpuUsage() * 100f);
                //tempNode.UpdateTime = DateTime.Now;
                tempNode.Status = 0;
            }
            catch
            {
                tempNode = new Node();
                tempNode.Ip = Ip;
                tempNode.DockFolder = ConfigHelper.ReadParameter("DockFolder");
                tempNode.CpuIntro = NodeHelper.GetCPUInfo();
                tempNode.UpdateTime = DateTime.Now;

                mg.Node.InsertOnSubmit(tempNode);
            }
            finally
            {
                if (!FileHelper.CheckDock(tempNode.DockFolder))
                {
                    ConsoleHelper.Warn("本地Dock程序异常！");
                    throw new Exception("本地Dock程序异常！");
                }
                mg.SubmitChanges();
            }
            tempNode = mg.Node.First(n => n.Ip == Ip);
            return tempNode;
        }



        public static void DeleteLastFile(MonoGrid mg)
        {
            string mainFolder = ConfigHelper.ReadParameter("MainFolder");
            var s2Task = (from t in mg.Task
                          where t.Status == 2
                          select new
                          {
                              t.IDTask
                          })
                                      .ToList();

            DirectoryInfo mainFolderInfo = new DirectoryInfo(mainFolder);

            if (s2Task.Count!=0)
            {
                foreach (var item in s2Task)
                {
                    string id = item.ToString();
                    DirectoryInfo[] folders = mainFolderInfo.GetDirectories(id);
                    foreach (DirectoryInfo folder in folders)
                    {
                        folder.Delete(true);
                    }
                }
            }
        }
    }
}

