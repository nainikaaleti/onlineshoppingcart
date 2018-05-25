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
using System.Net.Mail;
using System.Net.Security;
using System.Net;

public partial class ViewBooks : System.Web.UI.Page
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
        da = new SqlDataAdapter("select * from books where userid='"+HiddenField1.Value+"'", con);
        ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbl = (Label)row.FindControl("lblbookid");
        TextBox textbookname = (TextBox)row.FindControl("txtbookname");
        TextBox textauthor = (TextBox)row.FindControl("txtauthor");
        TextBox txtpublisher = (TextBox)row.FindControl("txtpublisher");
        TextBox txtnoofcopies = (TextBox)row.FindControl("txtnoofcopies");
        TextBox txtshopname = (TextBox)row.FindControl("txtshopname");
        TextBox txtshopaddress = (TextBox)row.FindControl("txtshopaddress");

        GridView1.EditIndex = -1;
        con.Open();
        SqlCommand cmd = new SqlCommand("update books set bookname='" + textbookname.Text + "',author='" + textauthor.Text + "',publisher='" + txtpublisher.Text + "',noofcopies='" + txtnoofcopies.Text + "' where bookid=" + lbl.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillGrid();
        con.Open();
        cmd = new SqlCommand("select emailId from userreg where roleId='2'", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            SmtpClient serverobj = new SmtpClient();
            serverobj.Host = "smtp.gmail.com";
            serverobj.Credentials = new NetworkCredential("polinenizz@gmail.com", "9491561290");
            MailMessage msgobj = new MailMessage();
            serverobj.EnableSsl = true;
            msgobj.From = new MailAddress("polinenizz@gmail.com");
            string s = ds.Tables[0].Rows[i][0].ToString();
            msgobj.To.Add(s);
            msgobj.Subject = "Book Shopping";
            //string y = TextBox1.Text;
            msgobj.Body = "this book for improving in communication skills";
            serverobj.Send(msgobj);

        }
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        fillGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteID = (Label)row.FindControl("lblbookid");
        con.Open();
        //SqlCommand cmd = new SqlCommand("update books set isActive=0  where bookid=" + lbldeleteID.Text + "", con);
        SqlCommand cmd = new SqlCommand("delete  books  where bookid=" + lbldeleteID.Text + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        fillGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        fillGrid();
    }
}
