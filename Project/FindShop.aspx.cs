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

public partial class FindShop : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    DataSet ds = new DataSet();
    DataSet dssub = new DataSet();
    SqlDataAdapter adp;
    string imgpath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucGoogle.Visible = false;
            con.Open();
            adp = new SqlDataAdapter("select distinct(shopname) from Shop_Details", con);
            adp.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "ShopName";
            DropDownList1.DataValueField = "ShopName";
            
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dlimgdtls.Visible = false;
        lblStatus.Visible = false;
        DropDownList2.Items.Clear();
        adp = new SqlDataAdapter("select * from Shop_Details where ShopName='" + DropDownList1.SelectedItem.Text + "'", con);
        adp.Fill(ds, "branch");
        for (int i = 0; i < ds.Tables["branch"].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables["branch"].Rows[i]["Branch"].ToString());
        }
        DropDownList2.Items.Insert(0, "Select Branch");
        DropDownList2.DataBind();


    }
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        p1.Visible = true;
        lblStatus.Visible = false;
        TreeView1.Nodes.Clear();
        con.Open();

        sda1 = new SqlDataAdapter("select userid from userreg where shopname='" + DropDownList1.SelectedItem.Text + "' and shopaddress='" + DropDownList2.SelectedItem.Text + "'", con);
        sda1.Fill(ds1, "cat1");

        if (ds1.Tables[0].Rows.Count > 0)
        {
            adp = new SqlDataAdapter("select * from book_category where userId=" + Convert.ToInt32(ds1.Tables[0].Rows[0][0]), con);
            adp.Fill(ds, "cat");
            TreeNode tn;
            for (int i = 0; i < ds.Tables["cat"].Rows.Count; i++)
            {

                tn = new TreeNode();
                tn.Text = ds.Tables["cat"].Rows[i]["catname"].ToString();
                tn.Value = ds.Tables["cat"].Rows[i]["catId"].ToString();
                TreeView1.Nodes.Add(tn);
                SqlDataAdapter adp1 = new SqlDataAdapter("select * from Sub_Category where catid='" + int.Parse(ds.Tables["cat"].Rows[i]["catId"].ToString()) + "'", con);
                dssub = new DataSet();
                adp1.Fill(dssub, "subcat");
                for (int j = 0; j < dssub.Tables["subcat"].Rows.Count; j++)
                {
                    TreeNode n = new TreeNode();
                    n.Text = dssub.Tables["subcat"].Rows[j]["SubCatName"].ToString();
                    n.Value = dssub.Tables["subcat"].Rows[j]["SubId"].ToString();
                    TreeView1.Nodes[i].ChildNodes.Add(n);
                }
            }
            //ucGoogle.Visible = true;
         //   ucGoogle.GoogleMapObject.Width = "400px";
          //  ucGoogle.GoogleMapObject.Height = "400px";



//            GooglePoint GP2 = new GooglePoint();
  //          GP2.ID = "AmeerPet";
    //        GP2.Latitude = 17.430232; //+0.001
      //      GP2.Longitude = 78.450326;
        //    GP2.InfoHTML = "This is Pushpin 1";
          //  ucGoogle.GoogleMapObject.Points.Add(GP2);
            //ucGoogle.GoogleMapObject.ZoomLevel = 9;

//            GooglePoint GP1 = new GooglePoint();
  //          GP1.ID = "BanjaraHills";
    //        GP1.Latitude = 17.419216;
      //      GP1.Longitude = 78.435404;
        //    GP1.InfoHTML = "BanjaraHills";
          //  ucGoogle.GoogleMapObject.Points.Add(GP1);
            //ucGoogle.GoogleMapObject.ZoomLevel = 9;


            //ucGoogle.GoogleMapObject.CenterPoint = new GooglePoint("1", 17.430232, 78.450326);
            //ucGoogle.GoogleMapObject.CenterPoint = new GooglePoint("2", 17.430232, 78.450326);
            //TreeView1.DataBind();
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
       // con.Open();
        if (TreeView1.SelectedNode.ChildNodes.Count == 0)
        {
            if (TreeView1.SelectedNode.Parent != null)
            {
                dlimgdtls.Visible = true;
                adp = new SqlDataAdapter("select * from books where SubId=" + int.Parse(TreeView1.SelectedNode.Value) + " and catId=" + int.Parse(TreeView1.SelectedNode.Parent.Value), con);
                adp.Fill(ds, "books");
                dlimgdtls.DataSource = ds.Tables["books"];
                dlimgdtls.DataBind();
                lblStatus.Visible = false;
            }
            else
            {
                dlimgdtls.Visible = false;
                lblStatus.Visible = true;
            }
        }
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
            //Label lbl1 = ((Label)e.Item.FindControl("lblimgpath"));
            //imgpath = lbl1.Text;
            //Response.Redirect("imageeditor.aspx?imgpath=" + imgpath);
        }

    }
    protected void dlimgdtls_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}

