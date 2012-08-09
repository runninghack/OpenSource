using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;

namespace GridDaemon
{
    public partial class GridClient : Form
    {
        MySqlConnection conn;
        MonoGrid mg;
        Node localNode;
        int molDiv;
        string ServerIP;

        public GridClient()
        {
            InitializeComponent();
            ServerIP = ConfigHelper.ReadParameter("ServerIP");
            string connstr = "server=" + ServerIP + ";database=MonoGrid;user=root;pwd=123456;";
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);

            //参数初始化
           
            //localNode = NodeHelper.InitNode(mg);

            Tbx_DockPath.Text = ConfigHelper.ReadParameter("DockFolder");
            Tbx_IP.Text = ConfigHelper.ReadParameter("ServerIP");
            Tbx_MainFolder.Text = ConfigHelper.ReadParameter("MainFolder");

            LB_CPU.Text = NodeHelper.GetCPUInfo();
            LB_IP.Text = NodeHelper.GetIP();
            progressBar1.Value = (int)(NodeHelper.GetCpuUsage()*100f);

            Lb_Status.Text = "参数已读取";
        }

        private void Btn_ServiceStart_Click(object sender, EventArgs e)
        {
            MainService service = new MainService();
            service.Update();
            Lb_Status.Text = "服务已经开始";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string configPath = AppPath + @"/config.ini";
            string[] content = File.ReadAllLines(configPath);
            content[0] = "MainFolder:                            " + Tbx_MainFolder.Text;
            content[1] = "ServerIP:                                " + Tbx_IP.Text;
            content[2] = "DockFolder:                             " + Tbx_DockPath.Text;
            File.WriteAllLines(configPath, content);
           // ConsoleHelper.Show("编辑Dock的配置文件" + patch);

            Lb_Status.Text = "参数设置已经保存";
        }

        private void Btn_ServiceStop_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Btn_deleteFile_Click(object sender, EventArgs e)
        {
            NodeHelper.DeleteLastFile(mg);
        }
    }
}
