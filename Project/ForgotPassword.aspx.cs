using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class ForgotPassword : System.Web.UI.Page
{
    public string pwd, email;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select password,emailId from userreg where username='" + TextBox1.Text + "' and securityques='" + DropDownList1.SelectedItem.Text + "' and answer='" + TextBox6.Text + "'";
        con.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Label2.Visible = true;
            pwd = dr["password"].ToString();
            email = dr["emailId"].ToString();
        }

        con.Close();
        SendMail(email, pwd);

    }
    public void SendMail(string to, string password)
    {



        SmtpClient srvrobj = new SmtpClient();
        srvrobj.Host = "smtp.gmail.com";
        srvrobj.Credentials = new NetworkCredential("polinenizz@gmail.com", "9491561290");
        srvrobj.EnableSsl = true;
        srvrobj.Port = 587;
        MailMessage mlmsgobj = new MailMessage();
        mlmsgobj.From = new MailAddress("polinenizz@gmail.com", "Forgot Password");
        mlmsgobj.To.Add("" + email + "");
        mlmsgobj.CC.Add("p4punilnimmagadda@gmail.com");
        mlmsgobj.Subject = "password" ;
        mlmsgobj.Body = "Your password is:  " + password  + " ";
       srvrobj.Send(mlmsgobj);
    }

}
