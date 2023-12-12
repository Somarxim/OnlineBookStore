<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="~/inc/top.ascx" TagPrefix="uc1" TagName="top" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc1" TagName="down" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页</title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:top runat="server" ID="top" />
            <table width ="1000" align="center">
                <tr>
                    <td align="right" class="auto-style1">用户名:</td><td>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">密码:</td><td>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td><td>
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="注册" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
            <uc1:down runat="server" ID="down" />
        </div>
    </form>
</body>
</html>
