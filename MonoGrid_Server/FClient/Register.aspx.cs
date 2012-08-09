using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Register : System.Web.UI.Page
    {
        private MySqlConnection conn = null;
        private MonoGrid mg = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            //验证信息输入

            //写入数据库Client表

            Client cToAdd = new Client();
            cToAdd.UserName = TextBoxUserName.Text;
            cToAdd.Pwd = TextBoxPWD.Text;
            cToAdd.Email = TextBoxEMail.Text;
            cToAdd.RegisterTime = DateTime.Now;

            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);
            mg.Client.InsertOnSubmit(cToAdd);
            mg.SubmitChanges();
        }
    }
}
