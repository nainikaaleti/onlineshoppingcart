<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="UserRegistration.aspx.cs" Inherits="_Default" MasterPageFile="~/HomeMaster.master"%>
<asp:Content ID="Usercontent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table class="style1">
            <tr>
                <td class="style2" colspan="3" align="center" style="font-size: medium">
                    User Registration</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="UserName"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Enter UserName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"> 
                        <%--ontextchanged="TextBox3_TextChanged" Visible="False"--%></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label4" runat="server" Text="EmailId"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox4" ErrorMessage="Enter valid Emailid, for example:asqwzx@gmail.com" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>
                  <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBox5" ErrorMessage="Enter Phone number"></asp:RequiredFieldValidator> --%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Phone number invalid" 
                    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="127px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBox6" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox7" ErrorMessage="Enter City"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label8" runat="server" Text="Security Question"></asp:Label>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="DropDownList1" ErrorMessage="Select Question" 
                        InitialValue="Select Question"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label9" runat="server" Text="Answer"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="TextBox8" ErrorMessage="Enter Answer"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Clear" onclick="Button2_Click" />
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Content>