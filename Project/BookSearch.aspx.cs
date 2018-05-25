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
using System.Threading;
using System.IO;

public partial class BookSearch : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label12.Text = Session["username"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        cmd.Connection = con;
        if(DropDownList1.SelectedValue!=null)
        cmd.CommandText = "SELECT books.bookId,books.bookname, books.author, books.publisher, Shop_Details.ShopName, Shop_Details.branch FROM  books CROSS JOIN Shop_Details where " + DropDownList1.SelectedValue + " like '%" + TextBox1.Text + "%'";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dlimgdtls.DataSource = ds;
        dlimgdtls.DataBind();
     }
    protected void dlimgdtls_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string bookid;
        string bookpath;

        if (e.CommandName == "viewdetails")
        {
            Label lbl = ((Label)e.Item.FindControl("lblbookid"));
            bookid = lbl.Text;

            
            Response.Redirect("prologue.aspx?bookid=" + bookid );
            

        }
        else
        {
            Label lbl = ((Label)e.Item.FindControl("lblbookid"));
            bookid = lbl.Text;

            int uid = Convert.ToInt16(Session["userid"]);
            SqlDataAdapter sda = new SqlDataAdapter("select *from tbl_MyFavorite where bookId='" + bookid + "' and userId='" + uid + "'", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label13.Visible = true;
                Label13.Text = "Already Added to Favourite";
            }
            else
            {
                string s = "insert into tbl_MyFavorite (userId,bookId)values('" + uid + "','" + bookid + "')";
                SqlCommand cmdObj = new SqlCommand(s, con);
                con.Open();
                int i = cmdObj.ExecuteNonQuery();
                con.Close();
            }
        }

    }

    private void fileDownload(string fileName, string fileUrl)
    {
        Page.Response.Clear();
        bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
        if (!success)
            Response.Write("Downloading Error!");
        Page.Response.End();
    }

    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;

                int pack = 10240; //10K bytes
                int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                br.Close();
                myFile.Close();
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    protected void dlimgdtls_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}
