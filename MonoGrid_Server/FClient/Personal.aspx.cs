using System;
using System.Collections;
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
    public partial class Personal : System.Web.UI.Page
    {
        MySqlConnection conn;
        MonoGrid mg;
        protected void Page_Load(object sender, EventArgs e)
        {
			Session["User"]=1;
            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);
            if (!IsPostBack)
            {
                Client c = new Client();
                c = mg.Client.FirstOrDefault(item => item.IDClient == 1);//暂时赋值
                TextBoxUserName.Text = c.UserName;
                TextBoxEMail.Text = c.Email;
                Session["Pwd"] = c.Pwd;
            }

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c = mg.Client.FirstOrDefault(item => item.IDClient == int.Parse(Session["User"].ToString()));
            c.UserName = TextBoxUserName.Text;
            c.Pwd = TextBoxPWD.Text;
            c.Email = TextBoxEMail.Text;

            mg.SubmitChanges();

        }
    }
}
