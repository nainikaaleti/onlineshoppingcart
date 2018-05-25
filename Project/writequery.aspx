<%@ Page Language="C#" MasterPageFile="~/UserInnerMaster.master" AutoEventWireup="true" CodeFile="writequery.aspx.cs" Inherits="writequery" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="style2">
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Welcome: &nbsp;<asp:Label ID="lblsession" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label1" runat="server" Text="Book name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtbookname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtbookname" ErrorMessage="Enter book name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label2" runat="server" Text="author name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtauthorname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label3" runat="server" Text="No of copies"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnoofcopies" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtnoofcopies" 
                    ErrorMessage="Please enter nof of copies required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtname" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label5" runat="server" Text="Email id"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtemailid" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Enter valid Email id" ControlToValidate="txtemailid" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddresss" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:Label ID="Label8" runat="server" Text="Delivery"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="42px">
                    <asp:ListItem>Delivery Required</asp:ListItem>
                    <asp:ListItem>Delivry not requred</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                Shop Name</td>
            <td>
                <asp:DropDownList ID="ddlshopname" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlshopname_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlshopname" ErrorMessage="Select Any shop"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                Branch</td>
            <td>
                <asp:DropDownList ID="ddlbranch" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlbranch" ErrorMessage="Select branch"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr> <td></td><td> 
            <asp:Button ID="btnquery" runat="server" Text="Submit" 
                onclick="btnquery_Click" />
            </td></tr>
    </table>

</asp:Content>

