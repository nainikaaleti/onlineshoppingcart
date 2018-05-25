<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin" MasterPageFile="~/AdminInnerMaster.master"%>
<asp:Content ID="admincontent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="z-index: 100; left: 486px; position: absolute; top: 235px; width: 379px; height: 288px;">
            <tr>
              <td colspan="3" align="right">
                  <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Welcome : Admin"></asp:Label>  
                  
              </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="These are the existing ShopKeepers" Width="276px"></asp:Label></td>
                <td style="height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:GridView ID="GVUsers" runat="server" 
                    AutoGenerateColumns="False" Width="297px" 
                        onselectedindexchanged="GVUsers_SelectedIndexChanged">
                     <Columns>
                     <asp:TemplateField>
                                    <HeaderTemplate>UserId </HeaderTemplate>
                                    <ItemTemplate>
                                    <asp:Label ID="ShopKeeperId" runat="server" Text='<%#Eval("UserId") %>' >
                                    </asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField>
                                    <HeaderTemplate>ShopKeeper Name</HeaderTemplate>
                                    <ItemTemplate>
                                    <asp:Label ID="UserName" runat="server" Text='<%#Eval("name") %>' >
                                    </asp:Label>
                                    </ItemTemplate>                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                    <HeaderTemplate>Shop Name </HeaderTemplate>
                                    <ItemTemplate>
                                    <asp:Label ID="UserType" runat="server" Text='<%#Eval("shopname") %>' >
                                    </asp:Label>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                    <HeaderTemplate>Active Users </HeaderTemplate>
                                    <ItemTemplate>
                                   
                                    <asp:CheckBox ID="CBIsActive" runat="server" Text="IsActive" Checked= ' <%#Eval("IsActive") %>' >
                                    </asp:CheckBox>
                                    </ItemTemplate>
                                    
                                    </asp:TemplateField>
                                    
                                    
                                   
 
                                    </Columns>
                                    
                                    
                                      
                                  
                    </asp:GridView>
                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Label ID="LBLError" runat="server" Visible="False"></asp:Label></td>
                <td>
                </td>
            </tr>
        </table>

</asp:Content>