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

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Admin") 
        {
            Response.Redirect("AdminRegistration.aspx");
        }
        else if (DropDownList1.SelectedItem.Text == "ShopKeeper")
        {
            Response.Redirect("ShopKeeperRegistration.aspx");
        }
        else if (DropDownList1.SelectedItem.Text == "User")
        {
            Response.Redirect("UserRegistration.aspx");
        }
    }
}
