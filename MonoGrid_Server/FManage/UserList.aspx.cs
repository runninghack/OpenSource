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

namespace Web.Manage
{
    public partial class UserList : System.Web.UI.Page
    {
        MySqlConnection conn;
        MonoGrid mg;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);

            GridView1.DataSource = GetUsers();
            GridView1.DataBind();
        }

        private IQueryable GetUsers()
        {
            return mg.Client;
        }
    }
}
