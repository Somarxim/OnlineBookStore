<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>

<%@ Register Src="~/inc/top.ascx" TagPrefix="uc1" TagName="top" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc1" TagName="down" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册页</title>
    <style type="text/css">
        .auto-style1 {
            width: 387px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:top runat="server" ID="top" />
            <table width="1000" align="center">
                <tr>
                    <td align="right" class="auto-style1">用户名：</td><td>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">密码：</td><td>
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">姓名：</td><td>
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">地址：</td><td>
                    <asp:TextBox ID="address" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">性别：</td><td>
                    <asp:DropDownList ID="sex" runat="server">
                        <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">手机：</td><td>
                    <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">邮箱：</td><td>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">QQ：</td><td>
                    <asp:TextBox ID="qq" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td><td>
                    <asp:Button ID="submit" runat="server" OnClick="Button1_Click" Text="注册" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click1" />
                    </td>
                </tr>
            </table>
            <uc1:down runat="server" ID="down" />
        </div>
    </form>
</body>
</html>