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


public partial class AddBook : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    string f;
    string fImg;
    string bookpath;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label14.Text = Session["username"].ToString();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select userId from userreg where username='" + Label14.Text + "'";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        HiddenField1.Value = ds.Tables[0].Rows[0][0].ToString();

        ddlBind();
     //   fillGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string s = Server.MapPath("~/books/");
            f = FileUpload1.FileName;
            bookpath = f.Substring(0, f.Length - 4);
            s = s + f;
            FileUpload1.PostedFile.SaveAs(s);
        }
        if (FileUpload2.HasFile)
        {
            string sImg = Server.MapPath("~/img/");
            fImg = FileUpload2.FileName;
            bookpath = fImg.Substring(0, fImg.Length - 4);
            sImg = sImg + fImg;
            FileUpload2.PostedFile.SaveAs(sImg);
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        //cmd.CommandText = "insert into books(catid,userid,bookname,author,publisher,volumes,noofcopies,shopname,shopaddress,contactperno,bookpath) values('" + DropDownList1.SelectedValue + "',"+Session["userid"]+",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','"+bookpath+"')";
        cmd.CommandText = "insert into books(catId,SubId,bookname,userId,author,publisher,volumes,noofcopies,bookpath,isActive,prologue,imagepath) values(@catid,@SubId,@bookname,@userid,@author,@publisher,@vol,@noofcop,@path,@isactive,@prologue,@imagepath)";
        cmd.Parameters.AddWithValue("@catid",Convert.ToInt32(DropDownList1.SelectedValue));
        cmd.Parameters.AddWithValue("@SubId", Convert.ToInt32(DropDownList2.SelectedValue));
        cmd.Parameters.AddWithValue("@bookname", TextBox1.Text);
        cmd.Parameters.AddWithValue("@userid",Convert.ToInt32(Session["userid"]));
        cmd.Parameters.AddWithValue("@author", TextBox2.Text);
        cmd.Parameters.AddWithValue("@publisher", TextBox3.Text);
        cmd.Parameters.AddWithValue("@vol", TextBox4.Text);
        cmd.Parameters.AddWithValue("@noofcop",Convert.ToInt32(TextBox5.Text));
        cmd.Parameters.AddWithValue("@path", f);
        cmd.Parameters.AddWithValue("@isactive", 1);
        cmd.Parameters.AddWithValue("@prologue", TextBox6.Text);
        cmd.Parameters.AddWithValue("@imagepath", FileUpload2.FileName);
        
    
        con.Open();
int status = cmd.ExecuteNonQuery();
        con.Close();
        if (status > 0)
        {
            Label9.Text = "Book added Successfully";
            //con.Open();
            //cmd = new SqlCommand("select emailId from userreg where roleId='2'",con);
            //da = new SqlDataAdapter(cmd);
            //ds = new DataSet();
            //da.Fill(ds);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
                //SmtpClient serverobj = new SmtpClient();
                //serverobj.Host = "smtp.gmail.com";
                //serverobj.Credentials = new NetworkCredential("rameshy.coign@gmail.com","8374623703");
                //MailMessage msgobj = new MailMessage();
                //serverobj.EnableSsl = true;
                //msgobj.From = new MailAddress("rameshy.coign@gmail.com");
                //string s = ds.Tables[0].Rows[i][0].ToString();
                //msgobj.To.Add(s);
                //msgobj.Subject = "Book Shopping";
                //string y = TextBox1.Text;
                //msgobj.Body =y+ "this book for improving in communication skills";
                ////msgobj.Attachments.Add(new Attachment(path));
                //serverobj.Send(msgobj);
                //Label1.Visible = true;
                //Label1.Text = "Your mail has been sent";
                //TextBox4.Text = "";
                //TextBox3.Text = "";
                //txtSubject.Text = "";
                //txtToMailID.Text = "";
                //txtBoby.Text = "";


 
            //}

        }
        else
        {
            Label9.Text = "Book adding failed";
        }
    }


    public void ddlBind()
    {
        if (!IsPostBack)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from book_category where userid='"+HiddenField1.Value + "'";
            da = new SqlDataAdapter(cmd);
            //con.Open();
            ds = new DataSet();
            da.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "catname";
            DropDownList1.DataValueField = "catid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();

        SqlDataAdapter adp = new SqlDataAdapter("select * from Sub_Category where catid='" + int.Parse(DropDownList1.SelectedValue.ToString()) + "'", con);
        adp.Fill(ds, "sub");
        DropDownList2.DataSource = ds.Tables["sub"];
        DropDownList2.DataValueField = "SubId";
        DropDownList2.DataTextField = "SubCatName";
        DropDownList2.DataBind();
    }
}
