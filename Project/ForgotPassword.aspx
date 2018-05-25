<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" MasterPageFile="~/HomeMaster.master"%>
<asp:Content ID="forgotcontent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table class="style1">
            <tr>
                <td colspan="3" align="center">
                    Forgot Password</td>
            </tr>
            <tr>
                <td class="style2" style="width: 81px">
                    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 81px">
                    <asp:Label ID="Label5" runat="server" Text="Security Question"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Select Question</asp:ListItem>
                        <asp:ListItem>What is your favourite Game ?</asp:ListItem>
                        <asp:ListItem>What is your favourite place?</asp:ListItem>
                        <asp:ListItem>What is your favourite movie?</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="DropDownList1" ErrorMessage="Select Question" 
                        InitialValue="Select Question"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 81px">
                    <asp:Label ID="Label6" runat="server" Text="Answer"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBox6" ErrorMessage="Enter Answer"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Clear" />
                </td>
            </tr>
            <tr>
            <td class="style2" colspan="3" align="center" style="width: 81px">
                 <asp:Label ID="Label2" runat="server" Visible="False">Password is sent to your registered EmailID</asp:Label>
                     
                 
                </td>
            </tr>
        </table>
</asp:Content>