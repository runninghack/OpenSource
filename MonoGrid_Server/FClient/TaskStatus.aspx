<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TaskStatus.aspx.cs" Inherits="Web.FClient.TaskStatus" Title="任务状态" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="135px" 
            Width="674px">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="上传者" />
                <asp:BoundField DataField="UploadTime" HeaderText="上传时间" />
               
                
                <asp:TemplateField HeaderText="状态">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# GetStatus(Eval("Status").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:BoundField DataField="Intro" HeaderText="描述" NullDisplayText="无" />
                <asp:TemplateField HeaderText="进度">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# GetProcess(float.Parse(Eval("OverMolCount").ToString())/float.Parse(Eval("MolCount").ToString())*100f) %>'></asp:Label>
                        %
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            href='<%# @"http://192.168.1.11/Files/Results/" + Eval("idTask").ToString() + @"/Total.res"  %>' 
                            Text="下载 "></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" onclick="ButtonUpdate_Click" 
            Text="更新" />
    
    </div>
</asp:Content>
