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
using System.Data.SqlClient;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label3.Text = Session["username"].ToString();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select * from userreg where roleid=3 and isActive=1";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        GVUsers.DataSource = ds;
        GVUsers.DataBind();
      
    }
    protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
