<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/HomeMaster.master"%>
<asp:Content ID="LoginContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <table class="style1" style="width: 425px">
            <tr>
                <td colspan="3" align="center">
                    Login</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Username"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Role"></asp:Label>
                </td>
                <td class="style3">
                    <asp:RadioButtonList ID="List" runat="server">
                        <asp:ListItem Value="1"> Admin </asp:ListItem>
                        <asp:ListItem Value="2"> Shopkeeper </asp:ListItem>
                        <asp:ListItem Value="3"> User </asp:ListItem>
                    </asp:RadioButtonList>
                                
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="List" ErrorMessage="Select Role" 
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
              <td colspan="3" align="center">
                  <asp:LinkButton ID="LinkButton1" runat="server" Text="Forgot Password?" 
                        PostBackUrl="~/ForgotPassword.aspx" CausesValidation="False" 
                      onclick="LinkButton1_Click"></asp:LinkButton>
                  
              </td>
            </tr>
        </table>
</asp:Content>