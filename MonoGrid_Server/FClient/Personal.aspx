<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Web.FClient.Personal" Title="个人信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <h2 style="text-align: center">个人信息：</h2>
        <table class="style1">
            <tr>
                <td>
                    用户名 
                </td>
                <td>
                    <asp:TextBox ID="TextBoxUserName" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBoxUserName" ErrorMessage="缺少用户名"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    密码 
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPWD" runat="server" MaxLength="25" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBoxPWD" ErrorMessage="缺少密码"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    确认密码 
                </td>
                <td>
                    <asp:TextBox ID="TextBoxConfirm" runat="server" MaxLength="25" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBoxConfirm" ErrorMessage="缺少密码验证"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    邮箱 
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEMail" runat="server" MaxLength="40"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBoxEMail" ErrorMessage="缺少电子邮箱地址"></asp:RequiredFieldValidator>
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="TextBoxEMail" ErrorMessage="邮箱地址格式错误" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="ButtonRegister" runat="server" onclick="ButtonRegister_Click" 
                        Text="注册" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
    
    </div>
</asp:Content>
