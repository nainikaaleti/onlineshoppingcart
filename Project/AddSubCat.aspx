<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="AddSubCat.aspx.cs" Inherits="AddSubCat" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Select Category::"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="175px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Sub Category Name::"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Description::"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Height="52px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
        </td>
    </tr>
    </table>
</asp:Content>

