﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Web.FClient.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script type="text/javascript" language="JavaScript">
      function addFile()
      {
      var str = '<br /><INPUT id="File1" type="file" size="50" name="file" runat="server" />'
      document.getElementById('MyFile').insertAdjacentHTML("beforeEnd",str)
      }
    </script>

</head>
<body>
    <form  id="Form1" method="post" runat="server">
    <div>
        <table  >
        <tr>
            <td >
                Attachment :
            </td>
            <td>
                <p id="MyFile">
                    <input id="filMyFile" type="file" size="50" name="filMyFile" runat="server" />
             
                    <input onclick="addFile()" type="button" value="Add"/>
                     </p>                <asp:Label ID="lblAttachmentError" runat="server" ForeColor="Red"></asp:Label><br/>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click"></asp:Button>
                <asp:Label ID="lblAttachment" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>