using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;

namespace Web.Manage
{
    public partial class ServerMain : System.Web.UI.Page
    {
        MySqlConnection conn;
        MonoGrid mg;
        int molDiv = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);

            //初始化获取系统参数
            molDiv = int.Parse(mg.Parameter.FirstOrDefault(i => i.PnAme == "molDiv").PvAlue);

            Update();
        }

        private void Update()
        {

            //分配piece匹配Nodes
            DistributeNodes();

            HandleWaitDownPiece();

            HandleDownTask();

            //HandleErrorNodes();

            //获取数据库中所有Node状态，并显示
            List<Node> nToList = mg.Node.ToList<Node>();
            GridView1.DataSource = nToList;
            GridView1.DataBind();
        }

        /// <summary>
        /// 分配节点 匹配Node和Piece
        /// </summary>
        void DistributeNodes()
        {
            List<Node> nodes = (from n in mg.Node
                                where n.Status == 0
                                select n).ToList<Node>();
            List<TaskPiece> pieces = (from p in mg.TaskPiece
                                      where p.Status == 0
                                      select p).ToList<TaskPiece>();

            if (nodes.Count + pieces.Count == 0)
                return;
            //没有可分配的
            int i = 0, j = 0;
            int nodeCount = nodes.Count, pieceCount = pieces.Count;

            while (nodeCount-- != 0 && pieceCount-- != 0)
            {
                TaskPiece p = pieces[i++];
                Node n = nodes[j++];

                n.Status = 1;
                //已分配但未开始
                p.NodeIp = n.Ip;
                p.Status = 1;
                //Node的Status置1（忙碌）
                //mg.Node.InsertOnSubmit(n);
                // mg.TaskPiece.InsertOnSubmit(p);
                mg.SubmitChanges();
            }

            //若无可分配Piece，查找Task表，若有Status为0的任务
            //选择一个Task（使用选择算法），将此任务分割为Piece，并写入Piece表
            //选择Piece表中一个Piece，进行分配操作（同上）
            //没有Piece等待了，再整出一些
            if (pieces.Count == 0)
            {
                List<Task> tasks = (from t1 in mg.Task
                                    where t1.Status == 0
                                    select t1).ToList<Task>();
                // 有Task，则分割成Piece
                if (tasks.Count != 0)
                {
                    Task taskToDivide = tasks.First();
                    FileHelper.DivideFile(taskToDivide.IDTask, taskToDivide.MolCount, molDiv, Server.MapPath(@"~/Files/Upload/" + taskToDivide.IDTask));
                    taskToDivide.Status = 1;
                    taskToDivide.StartTime = DateTime.Now;
                    mg.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// 检查并处理Status为3（等待下载）的Piece
        /// </summary>
        void HandleWaitDownPiece()
        {
            //查找Piece表中Status为3（已完成但未下载）的Piece，若有则下载
            List<TaskPiece> pToDown = (from p in mg.TaskPiece
                                       where p.Status == 3
                                       select p).ToList<TaskPiece>();

            if (pToDown.Count != 0)
            {
                foreach (TaskPiece p in pToDown)
                {
                    string filePath = "http://" + p.NodeIp + @"/Files/" + p.TaskID + "_" + p.NoInGroup + @"/output_scored.mol2";
                    //要下载的文件地址
                    string localFile = Server.MapPath(@"~/Files/Results/" + p.TaskID + @"/Result_" + p.NoInGroup);

                    FileHelper.NotFolderIsCreate(localFile);
                    //建立存放结果文件的文件夹
                    //保存在server端的文件名
                    //下载文件到Server端
                    new WebClient().DownloadFile(filePath, localFile);

                    //将Piece的Status标记为4（已下载）
                    p.Status = 4;
                    Node nToSet = mg.Node.First(n => n.Ip == p.NodeIp);
                    nToSet.Status = 0;

                    Task tToSet = mg.Task.First(t => t.IDTask == p.TaskID);
                    tToSet.OverMolCount += molDiv;
                }
            }
            mg.SubmitChanges();
        }

        /// <summary>
        /// 检查并处理已完成Task，即Status为1的Task所对应的Piece的Status为全4（已下载）
        /// </summary>
        void HandleDownTask()
        {

            //			List<Task> tFinish = (from t in mg.Task
            //				join p in mg.TaskPiece on t.IDTask equals p.TaskID
            //				where t.Status == 1 && p.Status == 4
            //				select t).ToList<Task> ();

            //查找Status为1的Task所对应的Pieces是否全部Status为4（已下载）
            List<Task> tFinish = new List<Task>();

            var s1Task = from t in mg.Task
                         where t.Status == 1
                         select t;

            foreach (Task t in s1Task)
            {
                List<TaskPiece> pieces = (from tp in mg.TaskPiece
                                          where tp.TaskID == t.IDTask
                                          select tp).ToList<TaskPiece>();

                //mg.TaskPiece (tp => tp.TaskID == t.IDTask);
                bool flag = true;
                foreach (TaskPiece p in pieces)
                {
                    if (p.Status != 4)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    tFinish.Add(t);
                }
            }

            //若任务的子节点都为已下载状态，以下进行整理和整合以最终完成
            if (tFinish.Count != 0)
            {
                foreach (Task t in tFinish)
                {
                    //检测Server端结果文件的完整性，整合并妥善放置文件
                    string path = Server.MapPath(@"~/Files/Results/") + t.IDTask;
                    string[] filename = Directory.GetFiles(path);

                    //若是完整的
                    if (filename.Count() >= (t.MolCount / molDiv))
                    {
                        //追加方式
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path + @"/Total.res", true))
                        {
                            //遍历结果文件
                            foreach (var item in filename)
                            {
                                string[] lines = System.IO.File.ReadAllLines(item);
                                //获取某个结果文件的内容
                                foreach (var line in lines)
                                {
                                    sw.WriteLine(line);
                                    //按行写入
                                }
                            }
                        }

                        //Task的Status设置为已完成
                        t.Status = 2;
                        t.FinishTime = DateTime.Now;
                        //已完成

                        //Piece表中对应的Piece删除
                        mg.ExecuteCommand("Delete from TaskPiece where TaskID={0}", t.IDTask);
                        mg.SubmitChanges();
                    }

                }
            }

        }

        /// <summary>
        /// 检测并处理异常Nodes
        /// </summary>
        void HandleErrorNodes()
        {
            List<Node> nError = (from n in mg.Node
                                 where (DateTime.Now - n.UpdateTime) > new TimeSpan(0, 5, 0)
                                 select n).ToList<Node>();

            //超时则认定为Error
            if (nError != null)
            {
                foreach (var n in nError)
                {
                    TaskPiece pToSet = (from p in mg.TaskPiece
                                        where p.NodeIp == n.Ip
                                        select p).First();
                    pToSet.Status = 0;//回收Piec
                    mg.Node.DeleteOnSubmit(n);
                    mg.SubmitChanges();
                    //丢弃故障Node
                }

            }
        }





        /// <summary>
        /// 用户页面上GridView数据的绑定
        /// </summary>
        /// <param name="intstring"></param>
        /// <returns></returns>
        public string GetStatus(string intstring)
        {
            string output = null;
            switch (intstring)
            {
                case "0": output = "空闲"; break;
                case "1": output = "忙碌"; break;
            }
            return output;
        }
    }


}

