using System;
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
using System.Configuration;

public partial class _Default : System.Web.UI.Page 
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "insert into userreg(roleId,name,username,password,emailId,phone,address,city,securityques,answer,isActive) values(3,'"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+"','"+TextBox6.Text+"','"+TextBox7.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox8.Text+"',1)";
        con.Open();
        int status = cmd.ExecuteNonQuery();
        if (status >= 0)
        {
            Label10.Text = "User registered successfully";
        }
        else 
        {
            Label10.Text = "User registration failed";
        }
        Clear();
    }

    public void Clear() 
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
