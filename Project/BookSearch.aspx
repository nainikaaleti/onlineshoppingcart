<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookSearch.aspx.cs" Inherits="BookSearch" MasterPageFile="~/UserInnerMaster.master" %>
<asp:Content ID="Booksearch1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="style1" >
            <tr>
               <td align="right" colspan="3">
                   <asp:Label ID="Label11" runat="server" Text="Welcome :" Font-Bold="true"></asp:Label>
                   <asp:Label ID="Label12" runat="server"></asp:Label>
               </td> 
            </tr>
            <tr>
                <td align="center" class="style4" 
                    style="font-size: medium; font-weight: bold;">
                    Book Search</td>
            </tr>
            <tr>
                <td class="style2" align="center">
                    <asp:TextBox ID="TextBox1" runat="server" Width="394px"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td class="style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="bookname">Book Name</asp:ListItem>
                        <asp:ListItem Value="author">Author</asp:ListItem>
                        <asp:ListItem Value="publisher">Publisher</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Select any of the following from the list" ControlToValidate="DropDownList1" InitialValue="Select"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" />
                    &nbsp;
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/writequery.aspx">Click 
                    Here</asp:HyperLink>
                    
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
                    
                </td>
            </tr>
        </table>
        <table class="style1" style="width: 409px">
        <tr>
            <td>
                <asp:DataList ID="dlimgdtls" runat="server" ItemStyle-BorderStyle="Ridge" 
                    ItemStyle-BorderColor="BlanchedAlmond" OnItemCommand="dlimgdtls_ItemCommand" 
                    onselectedindexchanged="dlimgdtls_SelectedIndexChanged">
        <ItemTemplate>
        <table>
        <tr>
        <td valign="top">Book Name<br />Author<br />Publisher<br />ShopName<br />Branch<br />
            <%-- View Details--%><br />
            <asp:Label ID="lblbookid" runat="server" Text='<%#Eval("bookid") %>' Visible="false"></asp:Label>
            </td>
        <td valign="top"> : <%#Eval("bookname")%><br />: <%#Eval("author")%><br />: <%#Eval("publisher")%><br />
            :<%#Eval("ShopName")%><br />:<%#Eval("branch")%><br /><%--: --%><asp:LinkButton
                ID="lbtviewdetails" runat="server" CommandName="viewdetails">View Details</asp:LinkButton><br /><%--<asp:LinkButton
                    ID="LinkButton1" runat="server" CommandName="Add To My Favourites">Add 
            To favourites</asp:LinkButton> --%>
           </td>    
        </tr><tr><td colspan="3"><br /></td></tr>
        </table>
        </ItemTemplate>
            <ItemStyle BorderColor="BlanchedAlmond" BorderStyle="Ridge" />
        </asp:DataList>
            </td>
        </tr>
    </table>

</asp:Content>