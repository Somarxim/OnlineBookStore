<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_edit.aspx.cs" Inherits="user_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户信息编辑页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" align="center">
                <tr>
                    <td>密码：</td><td>
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>姓名：</td><td>
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>地址：</td><td>
                    <asp:TextBox ID="address" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>性别：</td><td>
                    <asp:DropDownList ID="sex" runat="server">
                        <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>手机：</td><td>
                    <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>邮箱：</td><td>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">QQ：</td><td class="auto-style3">
                    <asp:TextBox ID="qq" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">状态：</td><td class="auto-style3">
                    <asp:DropDownList ID="state" runat="server">
                        <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">正常</asp:ListItem>
                        <asp:ListItem Value="2">关闭</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="id" runat="server" />
                    </td><td>
                    <asp:Button ID="submit" runat="server" OnClick="Button1_Click" Text="保存" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
