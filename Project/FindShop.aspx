<%@ Page Language="C#" MasterPageFile="~/UserInnerMaster.master" AutoEventWireup="true" CodeFile="FindShop.aspx.cs" Inherits="FindShop" Title="Untitled Page" %>

<%@ Register TagName="uc" TagPrefix="uc1" Src="~/GoogleMapForASPNet.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Select Shop::"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                Height="16px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                Width="206px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Branch::"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                Height="16px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                Width="206px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr> <td> 
        <table class="style2">
            <tr>
                <td style="width: 110px">
        <asp:TreeView ID="TreeView1" runat="server" 
                        onselectednodechanged="TreeView1_SelectedNodeChanged">
        </asp:TreeView>
                </td>
                <td>
                <asp:DataList ID="dlimgdtls" runat="server" ItemStyle-BorderStyle="Ridge" 
                    ItemStyle-BorderColor="BlanchedAlmond" OnItemCommand="dlimgdtls_ItemCommand" 
                    onselectedindexchanged="dlimgdtls_SelectedIndexChanged">
        <ItemTemplate>
        <table>
        <tr>
        <td valign="top">Book Name<br />View Details<br />
            <asp:Label ID="lbBookName" runat="server" Text='<%#Eval("BookName") %>' Visible="false"></asp:Label>
            <asp:Label ID="lblbookid" runat="server" Text='<%#Eval("BookId") %>' Visible="false"></asp:Label>
            </td>
    <td valign="top"> : <%#Eval("bookname")%><br />:<asp:LinkButton ID="lbtviewdetails" runat="server" CommandName="viewdetails">View Details</asp:LinkButton></td>    
        </tr><tr><td colspan="3"><br /></td></tr>
        </table>
        </ItemTemplate>
            <ItemStyle BorderColor="BlanchedAlmond" BorderStyle="Ridge" />
        </asp:DataList>
        
                    
                </td>
               
            </tr>
             <tr>
             <td colspan="3">
             <asp:Label ID="lblStatus" runat="server"  Text="No Records Found" Visible="false"></asp:Label>
             &nbsp;</td>
             </tr>
              <tr>
             <td colspan="3">
          
         </td>
             </tr>
        </table>
    </td></tr>                                                  
     <tr>
    <td>
    <asp:Label ID="Lab1" runat="server">
       <asp:Panel ID="p1" runat="server" Visible="false">
         
         <frameset "25%,*,25%">
          <frame src="Tracert.html"  />
         </frameset>              
         </asp:Panel>
                  
    <br />
    <br />
    </asp:Label>
    </td>
    </tr>
</table>
<uc1:uc runat="server" ID="ucGoogle" />

</asp:Content>

