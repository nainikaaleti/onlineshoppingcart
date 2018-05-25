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

public partial class writequery : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter sda;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"]!=null)
        lblsession.Text = Session["username"].ToString();
        if (!IsPostBack)
        {
            
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT shopname FROM Shop_Reg";
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);

            ddlshopname.DataSource = ds;
            ddlshopname.DataTextField = "shopname";
            ddlshopname.DataValueField = "shopname";
            ddlshopname.DataBind();
            ddlshopname.Items.Insert(0, "Select any one");
        }
    }
    protected void btnquery_Click(object sender, EventArgs e)
    {
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Insert into Query values('" + lblsession.Text + "','" + txtname.Text + "','" + txtbookname.Text + "','" + txtauthorname.Text + "','" + txtnoofcopies.Text + "','" + txtemailid.Text + "','" + txtaddresss.Text + "','" + ddlshopname.SelectedItem.Text + "','" + ddlbranch.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "')";
            cmd.ExecuteNonQuery();

    }
    protected void ddlshopname_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "select * from Shop_Details where ShopName='" +ddlshopname.SelectedItem.Text + "'";
        sda = new SqlDataAdapter(cmd);
        ds = new DataSet();
        sda.Fill(ds);

        ddlbranch.DataSource = ds;
        ddlbranch.DataTextField = "Branch";
        ddlbranch.DataValueField = "Branch";
        ddlbranch.DataBind();
        ddlbranch.Items.Insert(0, "Select any one");

    }
}
