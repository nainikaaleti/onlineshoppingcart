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


public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    DataSet ds;
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["role"] = List.SelectedItem.Value;
        Session["username"] = TextBox1.Text;
        string query = "select * from userreg where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' and roleid=" + Session["role"];
        da = new SqlDataAdapter(query, con);
        ds = new DataSet();
        da.Fill(ds);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    Session["userid"] = ds.Tables[0].Rows[0]["userid"];
                }
            }

            if (ds.Tables[0].Rows.Count > 0 && Session["role"] == "1")
            {
                Response.Redirect("AdminHome.aspx");
            }
            else if (ds.Tables[0].Rows.Count > 0 && Session["role"] == "2")
            {
                Response.Redirect("ShopKeeperHome.aspx");
            }
            else if (ds.Tables[0].Rows.Count > 0 && Session["role"] == "3")
            {
                Response.Redirect("UserHome.aspx");
            }
            else
            {
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "Invalid username/password";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void linkreg_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
