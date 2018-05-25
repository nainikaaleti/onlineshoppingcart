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

public partial class ViewCategory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        Label2.Text = Session["username"].ToString();
        if (!IsPostBack)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select userId from userreg where username='" + Label2.Text + "'";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            HiddenField1.Value = ds.Tables[0].Rows[0][0].ToString();

            fillGrid();
        }
    }

    public void fillGrid()
    {
        da = new SqlDataAdapter("select * from book_category where userId='" + HiddenField1.Value + "' ", con);
        ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteID = (Label)row.FindControl("lblcatid");
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from book_category  where catid=" + lbldeleteID.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillGrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        fillGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbl = (Label)row.FindControl("lblcatid");
        TextBox textcatgname = (TextBox)row.FindControl("txtcategoryName");
        TextBox txtcategorydesc = (TextBox)row.FindControl("txtcategoryDesc");
        GridView1.EditIndex = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("update book_category set catname='" + textcatgname.Text + "',catdesc='" + txtcategorydesc.Text + "' where catid=" + lbl.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        fillGrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
