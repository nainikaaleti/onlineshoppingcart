﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCategory.aspx.cs" Inherits="ViewCategory" MasterPageFile="~/InnerMaster.master"%>
<asp:Content ID="viewContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table class="style1" width="500px">
             <tr>
               <td align="right">
                   <asp:Label ID="Label1" runat="server" Text="Welcome :" Font-Bold="true"></asp:Label>
                   <asp:Label ID="Label2" runat="server"></asp:Label>
               </td>
             </tr>
             <tr>
                <td class="style2" align="center" colspan="3">
                    <asp:Label ID="Label4" runat="server" Text="Category Details" Font-Bold="True" 
                        Visible="False"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="center" colspan="3">
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" Width="477px" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <Columns >
            
            <asp:TemplateField>
            <ItemTemplate >
            <asp:Label ID="lblcatid" runat ="server" Text ='<%#Eval("catId") %>' Visible="false" ></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Category Name" >
            <ItemTemplate> <%#Eval("catname")%></ItemTemplate> 
            <EditItemTemplate>
            <asp:TextBox ID="txtcategoryName" runat ="server" Text ='<%#Eval("catname") %>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText ="Category Desc"><ItemTemplate><%#Eval("catdesc")%> </ItemTemplate>
           <EditItemTemplate >
           <asp:TextBox ID="txtcategoryDesc" runat ="server" Text ='<%#Eval("catdesc") %>'></asp:TextBox>
           </EditItemTemplate>
            </asp:TemplateField>
            </Columns>
                    </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
</asp:Content>