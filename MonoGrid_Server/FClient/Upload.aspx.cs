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
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.IO;

namespace Web.FClient
{
	public partial class Upload : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{
			
		}

		protected void btnUpload_Click (object sender, EventArgs e)
		{
			HttpFileCollection files = HttpContext.Current.Request.Files;
			Task tToUpload = new Task ();
			tToUpload.IDTask = DateTime.Now.ToString ("yyyyMMddHHmmss");
			string folder = Server.MapPath (@"~/Files/Upload/" + tToUpload.IDTask);
			if (!Directory.Exists (folder))
				Directory.CreateDirectory (folder);
			
			
			for (int i = 0; i < files.Count; i++) {
				if (i < files.Count && i < 10) {
					if (files[i].FileName != "" || files[i] != null) {
						HttpPostedFile myFile = files[i];
						string FileName = myFile.FileName.ToString ().Trim ();
						this.lblAttachmentError.Text = "<" + FileName + ">";
						// Show file name 
						// Empty value in Browse Box
						if (myFile.FileName.Trim () == "") {
							this.lblAttachmentError.Text = "No file selected.";
							return;
						}
						
						if (myFile.ContentLength != 0) {
							this.lblAttachment.Text += "<BR>" + FileName;
							this.lblAttachmentError.Text = "";
							string temp=null;
							if (FileName.EndsWith("mol2")) {
								
							 temp=this.Request.PhysicalApplicationPath.ToString ().Trim () + @"Files/Upload/" + tToUpload.IDTask + @"/" + tToUpload.IDTask + ".mol2";
							}
							else 
							 temp=this.Request.PhysicalApplicationPath.ToString ().Trim () + @"Files/Upload/" + tToUpload.IDTask + @"/" + FileName;
							myFile.SaveAs (temp);
						} 
						else 
						{
							this.lblAttachmentError.Text = "File not found.";
							return;
						}
					}
				} else
					this.lblAttachmentError.Text = "Uploaded File exceed limits.";
				
			}
			
			
			//Mol文件内节点个数
			string molPath = folder + @"/" + tToUpload.IDTask + ".mol2";
			string[] molStrings = System.IO.File.ReadAllLines (molPath);
			int molCount = (from str in molStrings
				where str == "@<TRIPOS>MOLECULE"
				select str).Count ();
			
			tToUpload.MolCount=molCount;
			tToUpload.UserID=1;
			tToUpload.Status=0;
			tToUpload.UploadTime=DateTime.Now;
			tToUpload.Intro="无";
			
			string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
			MySqlConnection conn = new MySqlConnection (connstr);
			MonoGrid mg = new MonoGrid (conn);
			mg.Task.InsertOnSubmit (tToUpload);
			mg.SubmitChanges ();
			//检测其他文件的完整性合法性
			//写入数据库
			
			FileHelper.Grand(Server.MapPath("~/Files/Upload"),tToUpload.IDTask);
		}
		

	}
}
