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
//using System.Messaging;

public partial class prologue : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    SqlDataAdapter adp;
    string bookid;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        bookid = Request.QueryString["bookid"];

        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select bookid,bookname,author,volumes,prologue,imagepath,bookpath from books where bookId='" + bookid + "'";

        adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        TextBox1.Text = ds.Tables[0].Rows[0]["bookname"].ToString();
        TextBox2.Text = ds.Tables[0].Rows[0]["author"].ToString();
        TextBox3.Enabled = false;
        TextBox3.Text = ds.Tables[0].Rows[0]["bookid"].ToString();
        TextBox4.Text = ds.Tables[0].Rows[0]["volumes"].ToString();
        //        str = Server.MapPath("img") + "\\" + 
        //iBook.ImageUrl = "~/img/" + ds.Tables[0].Rows[0]["imagepath"].ToString();
        Session["book"] = ds.Tables[0].Rows[0]["bookpath"].ToString();
        //Server.MapPath("img") + "\\" + ds.Tables[0].Rows[0]["imagepath"].ToString();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    static int status = 0;
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select prologue from books where bookId='" + bookid + "'";
       
        int x = Convert.ToInt32(cmd.ExecuteScalar());
        if (x == 1)
        {
            if (status == 0)
            {

                mail();
                lblbuy.Text = "Confirmation mail sent to registered Mail ID." + "\r\n" + "Please keep the cash ready by the time product reaches your address." + "\r\n" + "Thank you for buying.";

            }
            else
            {
                lblbuy.Text = "Already Sent";
            }
            lblbuy.Visible = true;
        }
        else
        {
            lblbuy.Visible = true;
            lblbuy.Text = "You can download the book for free";
        }
        con.Close();

    }
    
    SqlDataAdapter sdamail;
    DataSet dsmail = new DataSet();
    //public void SendMail()
    //{
    //    try
    //    {
    //        sdamail = new SqlDataAdapter("select emailid from userreg where userid=" + Convert.ToInt32(Session["UserId"]), con);
    //        dsmail = new DataSet();
    //        sdamail.Fill(dsmail);


    //        // Declare object message of MailMessage class
    //        MailMessage message;

    //        // Declare object fromaddress of MailAddress class. From address is taken from web.config
    //        MailAddress fromaddress = new MailAddress("bolluvijaykumar@gmail.com");

    //        // Declare object fromaddress of MailAddress class. To address is taken from paramater.
    //        //MailAddress toaddress = new MailAddress(DeliveryTo);
    //        string EmailID = dsmail.Tables[0].Rows[0][0].ToString();
    //        MailAddress toaddress = new MailAddress(EmailID); //Database

    //        // Assigning fromaddress and toaddress to message object 
    //        message = new MailMessage(fromaddress, toaddress);//HardCoded

    //        // Assigning mail subject from web.config
    //        //Database
    //        message.Subject = "Buy Book";

    //        // Setting message body to html
    //        message.IsBodyHtml = true;

    //        // Get message body from web.config
    //        message.Body = "Hi, Thank you for buying plz visit again";

    //        // Create Attachment object for keeping attachments
    //        //Attachment fileattach = new Attachment(filepath);

    //        //// Add attachments to the message
    //        //message.Attachments.Add(fileattach);

    //        // Get the Server name from App.config
    //        string server = "smtp.mail.yahoo.com";

    //        // Create SmtPClient object with the server name and port as 21
    //        SmtpClient client = new SmtpClient(server, 21);

    //        // Set Delivery Method of sending mail
    //        client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

    //        // Send mail
    //        client.Send(message);
    //        //fileattach.Dispose();
    //        message = null;
    //        //return;


    //    }
    //    catch
    //    {
    //        // Log the errors in a text file for that call logtheerror() function from Functions class
    //        //LogTheError(exsendmail.Message.ToString() + "--->SendEmail()", exsendmail.Source.ToString());
    //    }
    //}
    static int message1 = 0;

    public void mail()
    {
        SmtpClient sc = new SmtpClient();
        try
        {
            SqlCommand cmd = new SqlCommand("select emailid from userreg where userid='" + Convert.ToInt32(Session["UserId"]) + "'", con);
            string toadd = cmd.ExecuteScalar().ToString();
            MailAddress from = new MailAddress(ConfigurationSettings.AppSettings["MailAdmin"]);
            MailAddress to = new MailAddress(toadd);

            MailMessage Mail = new System.Net.Mail.MailMessage("polinenizz@gmail.com", toadd, "Hello..", "Mail From Admin.. Your Order ID is " + bookid + ". Thank you for buying!!");
            
            sc.Host = "smtp.gmail.com";
            sc.Port = 587;
            sc.EnableSsl = true;
            sc.Credentials = new System.Net.NetworkCredential("polinenizz@gmail.com", "9491561290");
            sc.Send(Mail);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void btndownload_Click(object sender, EventArgs e)
    {

        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select prologue from books where bookId='" + bookid + "'";
       
        int x = Convert.ToInt32(cmd.ExecuteScalar());
        if (x == 2)
        {

            //if (message1 == 0)
            //{
            string y = Session["book"].ToString();
            string path = Server.MapPath("books/" +y);
            System.Diagnostics.Process.Start(path);

            //    FileUpload file = new System.IO.FileInfo(path);
            //    if (file.Exists)
            //    {

            //        Response.Clear();

            //        Response.AddHeader(

            //        "Content-Disposition", "attachment; filename=" + file.);
            //        Response.AddHeader(

            //        "Content-Length", file.Length.ToString());
            //        Response.ContentType =

            //        "application/octet-stream";
            //        Response.WriteFile(file.FullName);

            //        Response.End();

            //    }

            //    else
            //    {

            //        Response.Write("This file does not exist.");
            //    }
            //    lbldown.Text = "Thank you for downloading";
            //}


            //else
            //{
            //    lbldown.Text = "Already downloaded";
            //}
            //    lbldown.Visible = true;

        }
        else
        {
            lbldown.Visible = true;
            lbldown.Text = "This book cannot be downloaded, you have to buy";
        }
}
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}


