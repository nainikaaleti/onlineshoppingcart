<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopKeeperRegistration.aspx.cs" Inherits="ShopKeeperRegistration" MasterPageFile="~/HomeMaster.master"%>
<asp:Content ID="shoContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="style1">
            <tr>
                <td colspan="3" align="center">
                    ShopKeeper Registration</td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_Name" runat="server"></asp:TextBox></td>
                   
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="Txt_Name" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr> <td class="style4" style="width: 126px">
                    <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_uname" runat="server"></asp:TextBox></td>
                   
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="Txt_uname" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                </td></tr>
                <tr>  <td class="style4" style="width: 126px">
                    <asp:Label ID="Label3" runat="server" Text="Password" OnTextChanged="Txt_pswd_TextChanged"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_pswd" runat="server" TextMode="Password" ></asp:TextBox></td>
                   
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="Txt_pswd" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td></tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label4" runat="server" Text="EmailId"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_Email" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="Txt_Email" ErrorMessage="Enter EmailId"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="Txt_Email" ErrorMessage="Enter valid Emailid" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label5" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_PhnNo" runat="server" OnTextChanged="Txt_PhnNo_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="Txt_PhnNo" ErrorMessage="Enter Phone number"></asp:RequiredFieldValidator> --%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Txt_PhnNo" ErrorMessage="Phone number invalid" 
                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label6" runat="server" Text="ShopName"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_SName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="Txt_SName" ErrorMessage="Enter Shop Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label17" runat="server" Text="Branch Name"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_Branch" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="Txt_Branch" ErrorMessage="Enter Shop Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label7" runat="server" Text="Shop Address"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_Address" runat="server" TextMode="MultiLine" Width="127px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="Txt_Address" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label8" runat="server" Text="City"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_City" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="Txt_City" ErrorMessage="Enter City"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label9" runat="server" Text="Security Question"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="Ddl_SecQue" runat="server" Width="166px">
                        <asp:ListItem>Select Question</asp:ListItem>
                        <asp:ListItem>What is your favourite Game ?</asp:ListItem>
                        <asp:ListItem>What is your favourite place?</asp:ListItem>
                        <asp:ListItem>What is your favourite movie?</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="Ddl_SecQue" ErrorMessage="Select Question" 
                        InitialValue="Select Question"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label10" runat="server" Text="Answer"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_SecAns" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="Txt_SecAns" ErrorMessage="Enter Answer"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="3">
                    <asp:Label ID="Label12" runat="server" Text="Payment"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Type" 
                        Text="Credit" />
                </td>
                <td class="style3">
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Type" 
                        Text="Debit" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label13" runat="server" Text="CardType::"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="Ddl_CardType" runat="server" Width="137px" Height="16px">
                        <asp:ListItem>visa</asp:ListItem>
                        <asp:ListItem>master</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label14" runat="server" Text="Bank Name::"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="Ddl_BankName" runat="server" Width="137px" Height="16px">
                        <asp:ListItem>icici</asp:ListItem>
                        <asp:ListItem>hsbc</asp:ListItem>
                        <asp:ListItem>Andhra bank</asp:ListItem>
                        <asp:ListItem>hdfc</asp:ListItem>
                        <asp:ListItem>State bank of india</asp:ListItem>
                        <asp:ListItem>state bank of hyderabad</asp:ListItem>
                        <asp:ListItem>citi bank</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label15" runat="server" Text="Card Holder Name::"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txt_CardHolderName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 126px">
                    <asp:Label ID="Label16" runat="server" Text="Pin Number::"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="Txt_PinNo" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="3" align="center">
                    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Clear" onclick="Button2_Click" />
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

</asp:Content>