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
    public partial class Parameter : System.Web.UI.Page
    {
        MySqlConnection conn;
        MonoGrid mg;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            conn = new MySqlConnection(connstr);
            mg = new MonoGrid(conn);
            if (!IsPostBack)
            {
                
                GridView1.DataSource = mg.Parameter;
                GridView1.DataBind();
            }
            Tbx_Name.Text = "";
            Tbx_Value.Text = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "EditPara")
            {
                Web.Parameter p = mg.Parameter.FirstOrDefault(item => item.IDParameter == id);
                Tbx_Name.Text = p.PnAme;
                Tbx_Value.Text = p.PvAlue;
            }
        }
    }
}
