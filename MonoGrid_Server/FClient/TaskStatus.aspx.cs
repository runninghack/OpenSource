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

namespace Web.FClient
{
	public partial class TaskStatus : System.Web.UI.Page
	{
		MySqlConnection conn;
		MonoGrid mg;
		protected void Page_Load (object sender, EventArgs e)
		{
			string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
			conn = new MySqlConnection (connstr);
			mg = new MonoGrid (conn);
			getData ();
		}
		void getData ()
		{
			List<Task> list = mg.Task.ToList<Task> ();
			GridView1.DataSource = list;
			
			GridView1.DataBind ();
		}

		protected void ButtonUpdate_Click (object sender, EventArgs e)
		{
			getData ();
			
		}
		public string GetStatus (string intstring)
		{
			string output = null;
			switch (intstring) {
			case "0":
				output = "未开始";
				break;
			case "1":
				output = "正在计算";
				break;
			case "2":
				output = "已经完成";
				break;
			}
			return output;
		}
		
		public string GetProcess(float val)
		{
			return (val>100)?"100":val.ToString("f2");
		}
	}
}
