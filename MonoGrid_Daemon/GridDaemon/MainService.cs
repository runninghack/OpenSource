using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

namespace GridDaemon
{
    partial class MainService
    {
        MySqlConnection conn;
        MonoGrid mg;
        Node localNode;
        int molDiv;
        string ServerIP;
        string MainFolder;

        //构造函数
        public MainService()
        {
             //参数初始化
            ServerIP =ConfigHelper.ReadParameter("ServerIP");
            MainFolder = ConfigHelper.ReadParameter("MainFolder");
            string connstr = "server=" + ServerIP+ ";database=MonoGrid;user=root;pwd=123456;";
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);

            try
            {
                molDiv = int.Parse(mg.Parameter.First(p => p.PnAme == "molDiv").PvAlue);
            }
            catch
            {
                ConsoleHelper.Warn("数据库配置出错，未能获取系统参数！");
                throw new Exception("数据库配置出错，未能获取系统参数！");
            }
            
            //初始化Node
            localNode = NodeHelper.InitNode(mg);
        }
    }
}
