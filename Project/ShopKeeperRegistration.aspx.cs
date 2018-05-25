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
using System.Web.Mail;
using System.Net.Mail;

public partial class ShopKeeperRegistration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd, cmd1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string type = "";
        if (RadioButton1.Checked == true)
        {
            type = RadioButton1.Text;
        }
        else
            type = RadioButton2.Text;

        con.Open();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_shpreg";
        cmd.Parameters.AddWithValue("@roleId",2);
        cmd.Parameters.AddWithValue("@name",Txt_Name.Text);
        cmd.Parameters.AddWithValue("@username", Txt_uname.Text);
        cmd.Parameters.AddWithValue("@password", Txt_pswd.Text);
        cmd.Parameters.AddWithValue("@emailId", Txt_Email.Text);
        cmd.Parameters.AddWithValue("@phone", Txt_PhnNo.Text);
        cmd.Parameters.AddWithValue("@address", Txt_Address.Text);
        cmd.Parameters.AddWithValue("@city", Txt_City.Text);
        cmd.Parameters.AddWithValue("@shopname", Txt_SName.Text);
        cmd.Parameters.AddWithValue("@shopaddress", Txt_Branch.Text);
        cmd.Parameters.AddWithValue("@securityques", Ddl_SecQue.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@answer", Txt_SecAns.Text);
        cmd.Parameters.AddWithValue("@isActive",1);
        cmd.Parameters.AddWithValue("@PType", type);
        cmd.Parameters.AddWithValue("@CardName", Ddl_CardType.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@BankName", Ddl_BankName.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@CardHolderName", txt_CardHolderName.Text);
        cmd.Parameters.AddWithValue("@PinNo", Txt_PinNo.Text);
  
        int status = cmd.ExecuteNonQuery(); 
        if (status >= 0)
        {
            Label11.Text = "ShopKeeper registered successfully";
        }
        else 
        {
            Label11.Text = "ShopKeeper registration failed";
        }
        cmd.Dispose();
        con.Close();

        Clear();
    }
    //public void mail()
    //{
    //    string email = Txt_Email.Text;
    //    string from = "harsha.oruganti@gmail.com";
    //    string Sub = "Hello Ur PassWord Is....";
    //    string body = "Your mail Id Is.." + Txt_Email.Text + "And Your Pass Word Is....";
    //    string ShopId = "";
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("select count(*) from Shop_Reg", con);
    //    ShopId = Txt_Name.Text + cmd.ExecuteScalar().ToString();
    //    System.Net.Mail.
    //}
    public void Clear()
    {
        Txt_Name.Text = "";
        Txt_Email.Text = "";
        Txt_PhnNo.Text = "";
        Txt_SName.Text = "";
        Txt_Address.Text = "";
        Txt_City.Text = "";
        Txt_SecAns.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void Txt_PhnNo_TextChanged(object sender, EventArgs e)
    {

    }
}
