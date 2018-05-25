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
public partial class ViewQuery : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlCommand cmd;
    SqlDataAdapter da,da1;
    DataSet ds,ds1;

    protected void Page_Load(object sender, EventArgs e)
    {
        da1 = new SqlDataAdapter("select shopname,shopaddress from userreg  where userId=" + Convert.ToInt32(Session["userid"]), con);
        ds1 = new DataSet();
        da1.Fill(ds1);

        
        da = new SqlDataAdapter("select username,bookname,authorname,NumberOfCopies,emailid from Query where shopname='"+ds1.Tables[0].Rows[0][0].ToString()+ "' and branch='"+ds1.Tables[0].Rows[0][1].ToString()+"'",con);
        ds = new DataSet();
        da.Fill(ds);
        gvQueries.DataSource = ds;
        gvQueries.DataBind();


    }
}
