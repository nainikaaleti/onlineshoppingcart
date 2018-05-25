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

public partial class AddSubCat : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
            con.Open();
            adp = new SqlDataAdapter("select * from book_category inner join userreg on book_category.userid=userreg.userId where userreg.username='"+Session["username"].ToString()+"'", con);
            adp.Fill(ds, "cat");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "catname";
            DropDownList1.DataValueField = "catid";
            DropDownList1.Items.Insert(0, "Select Item");
            DropDownList1.DataBind();
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
            
            //cmd = new SqlCommand("insert into Sub_Category(CatId,SubcatName,descr) values(@CatId,@SubCatName,@descr)", con);
            //cmd.Parameters.AddWithValue("@CatId", DropDownList1.SelectedValue.ToString());
            //cmd.Parameters.AddWithValue("@SubCatName", TextBox1.Text);
            //cmd.Parameters.AddWithValue("@descr", TextBox2.Text);
            //cmd.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Sub_Category values ('" + DropDownList1.SelectedValue.ToString()+ "','" + TextBox1.Text + "','" + TextBox2.Text + "')";
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("<script>alert('inserted successfully')");
            }
          

          
           
    }
}
