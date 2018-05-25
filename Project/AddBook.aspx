<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBook.aspx.cs" Inherits="AddBook" MasterPageFile="~/InnerMaster.master"%>
<asp:Content ID="BookContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table class="style1" style="width: 480px">
            <tr>
                <td colspan="3" align="right">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Label ID="Label13" runat="server" Text="Welcome :" Font-Bold="true"></asp:Label>
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    Add Book</td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label10" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        Height="16px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="135px">
                    </asp:DropDownList>
                    &nbsp;</td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="DropDownList1" ErrorMessage="Enter Category" 
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label15" runat="server" Text="Sub Category"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                        Height="16px" Width="140px">
                    </asp:DropDownList>
                    </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label1" runat="server" Text="Book Title"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Book Title"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label2" runat="server" Text="Author"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Enter Author"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label3" runat="server" Text="Publisher"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox3" runat="server" Height="22px"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="Enter Publisher"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
                &nbsp;in Dollars</td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label5" runat="server" Text="No of Copies"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label6" runat="server" Text="Buy or Download"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label20" runat="server" Text="1 = Buy / 2 = Download"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label12" runat="server" Text="Upload Book"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
                   <tr>
                <td class="style2" style="width: 128px">
                    <asp:Label ID="Label7" runat="server" Text="Upload Image"></asp:Label>
                </td>
                <td class="style3" style="width: 171px">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style2" colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Clear" />
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>