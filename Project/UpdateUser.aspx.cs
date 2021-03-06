﻿using System;
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

public partial class UpdateUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label12.Text = Session["username"].ToString();
        
        if (!IsPostBack) 
        {
            string query = "select * from userreg where username='" + Session["username"] + "' and roleid=3";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds);
            TextBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["username"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["password"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["emailId"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["phone"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["address"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["city"].ToString();
            DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["securityques"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["answer"].ToString();
            HiddenField1.Value = ds.Tables[0].Rows[0]["userid"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = "update userreg set name='" + TextBox1.Text + "',username='" + TextBox2.Text + "',password='" + TextBox3.Text + "',emailId='" + TextBox4.Text + "',phone='" + TextBox5.Text + "',address='" + TextBox6.Text + "',city='" + TextBox7.Text + "',securityques='"+DropDownList1.SelectedItem.Text+"',answer='" + TextBox8.Text + "' where userid=" + HiddenField1.Value + "";
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = query;
        con.Open();
        int status = cmd.ExecuteNonQuery();
        if (status > 0)
        {
            Label10.Text = "Updated Successfully";
        }
        else 
        {
            Label10.Text = "Updation failed";
        }
        con.Close();
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
