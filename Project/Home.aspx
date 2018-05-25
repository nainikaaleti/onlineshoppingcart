<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" MasterPageFile="~/HomeMaster.master"%>
<asp:Content ID="Homecontent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <p>
              Registration for&nbsp; ShopKeeper and User<br />
              Select Role <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                  onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Select</asp:ListItem>
                      
                     <asp:ListItem Value="1">None</asp:ListItem> 
                    <asp:ListItem Value="2">ShopKeeper</asp:ListItem>
                    <asp:ListItem Value="3">User</asp:ListItem>
                </asp:DropDownList>
            </p>
    </asp:Content>