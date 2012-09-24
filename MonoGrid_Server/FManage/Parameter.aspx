<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Parameter.aspx.cs" Inherits="Web.Manage.Parameter" Title="参数设置" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    
        <h2 class="style1">参数设置：</h2><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="PName" HeaderText="参数名" />
                <asp:BoundField DataField="PValue" HeaderText="参数值" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server"  
                            CommandArgument='<%# Eval("idParameter") %>' CommandName="EditPara" Text="编辑" />
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        <br />
        <table class="style2" style="height: 54px; width: 35%">
            <tr>
                <td>
                    参数名：</td>
                <td>
                    <asp:TextBox ID="Tbx_Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    参数值：</td>
                <td>
                    <asp:TextBox ID="Tbx_Value" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:Content>
