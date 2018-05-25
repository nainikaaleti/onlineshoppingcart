<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" MasterPageFile="~/InnerMaster.master"%>
<asp:Content ID="CatContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="style1" style="width: 455px">
            <tr>
              <td align="right" colspan="3">
                <asp:Label ID="label5" runat="server" Font-Bold="true" Text="Welcome :"></asp:Label>
                <asp:Label ID="labelsession" runat="server"></asp:Label>
              </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    Add Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Category"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="Category Description"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Enter Category Description"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Clear" onclick="Button2_Click" />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>