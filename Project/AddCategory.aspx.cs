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

public partial class AddCategory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    SqlDataReader rdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            //fillGrid();
        }
        labelsession.Text = Session["username"].ToString();

        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select userId from userreg where username='" + labelsession.Text + "'";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        HiddenField1.Value = ds.Tables[0].Rows[0][0].ToString();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "insert into book_category(catname,catdesc,userId) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + Convert.ToInt32(HiddenField1.Value) + "')";
        con.Open();
        int status = cmd.ExecuteNonQuery();
        {
            if (status >= 0) 
            {
                Label3.Text = "Category added successfully";
                //Label4.Visible = true;
                //fillGrid();
            }
            else
            {
                Label3.Text = "Added Category failed";
            }
        }
        Clear();
    }

    public void Clear() 
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
}