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

public partial class ViewSubCat : System.Web.UI.Page
{
    SqlConnection con  = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlDataAdapter adp;
    SqlCommand cmd;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
            con.Open();
            adp = new SqlDataAdapter("select * from book_category inner join userreg on book_category.userId=userreg.userId where userreg.username='" + Session["username"].ToString() + "'", con);
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "catname";
            DropDownList1.DataValueField = "catId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "select category");  
        }
    }
    public void fillgrid()
    {
        
        con.Open();
        adp = new SqlDataAdapter("select * from Sub_Category where catid='" + int.Parse(DropDownList1.SelectedValue.ToString()) + "' ", con);
        adp.Fill(ds, "sub");
        GridView1.DataSource = ds.Tables["sub"];
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
   
    
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbl = (Label)row.FindControl("lblcatid");
        TextBox textcatgname = (TextBox)row.FindControl("txtcategoryName");
        TextBox txtcategorydescr = (TextBox)row.FindControl("txtcategorydescr");
        GridView1.EditIndex = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("update Sub_Category set SubCatName='" + textcatgname.Text + "' where SubId="+ lbl.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillgrid();
        

    }
    protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
       
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        fillgrid();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteID = (Label)row.FindControl("lblcatid");
        con.Open();
        SqlCommand cmd = new SqlCommand(" delete from Sub_Category where SubId=" + Convert.ToInt32(lbldeleteID.Text) + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillgrid();


    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        fillgrid();

    }
   
}
