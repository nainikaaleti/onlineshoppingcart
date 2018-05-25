
<%@ Page Language="C#" MasterPageFile="~/UserInnerMaster.master" AutoEventWireup="true" CodeFile="prologue.aspx.cs" Inherits="prologue" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table><tr><td>
   <table style="width: 404px">
   <tr>
   <td style="width: 203px">
       <asp:Label ID="Label1" runat="server" Text="Bookname"></asp:Label>
   </td>
   <td>
       <asp:TextBox ID="TextBox1" runat="server" Width="201px"></asp:TextBox>
   </td></tr>
   <tr>
   <td style="width: 203px">
       <asp:Label ID="Label2" runat="server" Text="Authorname"></asp:Label>
   </td>
   <td>
       <asp:TextBox ID="TextBox2" runat="server" Width="202px"></asp:TextBox>
   </td>
   </tr> 
   <tr>
   <td style="width: 203px; height: 26px;">
       <asp:Label ID="Label3" runat="server" Text="Order ID"></asp:Label>
   </td>
   <td style="height: 26px">
       <asp:TextBox ID="TextBox3" runat="server" Width="204px"></asp:TextBox>
   </td>
   </tr> 
   <tr>
   <td style="width: 203px">
       <asp:Label ID="Label4" runat="server" Text="Price in Dollars"></asp:Label>
   </td>
   <td>
       <asp:TextBox ID="TextBox4" runat="server" Width="201px"></asp:TextBox>
   </td></tr>
   <tr>
   <td colspan="2" align="center">
       <br />
        <asp:Button ID="btnBuy" runat="server" Text="Place Order" 
           onclick="btnBuy_Click"/>
       &nbsp;&nbsp;&nbsp;
       <asp:Button ID="btndownload" runat="server" Text="Download" Height="23px" 
           onclick="btndownload_Click"/>
       <br />
       &nbsp;
       </td>
   </tr>
   
   <tr>
   <td colspan="2">
       <asp:Label ID="lblbuy" runat="server" Visible="False"></asp:Label>
       <asp:Label ID="lbldown" runat="server" Visible="False"></asp:Label>
       </td>
   </tr>
   
   </table>
   </td>
   <td>
 <%--  <asp:Image ID="iBook" runat="server" Height="100" Width="100"  /> --%>
   </td>
   </tr>
   <tr>
   <td colspan="2">
       &nbsp;</td>
   </tr>
   </table>
</asp:Content>

