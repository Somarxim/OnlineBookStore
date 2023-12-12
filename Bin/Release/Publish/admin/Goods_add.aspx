<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_add.aspx.cs" Inherits="admin_Goods_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品发布页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" width="80%">
                <tr>
                    <td>名称：</td>
                    <td>
                        <asp:TextBox ID="title" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>作者：</td>
                    <td><asp:TextBox ID="author" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>类别：</td>
                    <td>
                        <asp:DropDownList ID="type" runat="server">
                            <asp:ListItem>现当代文学</asp:ListItem>
                            <asp:ListItem Value="外国经典"></asp:ListItem>
                            <asp:ListItem Value="国学经典"></asp:ListItem>
                            <asp:ListItem Value="乡土小说"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>价格：</td>
                    <td><asp:TextBox ID="price" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>库存：</td>
                    <td><asp:TextBox ID="num" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>封面：</td>
                    <td>
                        <asp:FileUpload ID="img" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>详情：</td>
                    <td><asp:TextBox ID="detail" runat="server" Height="80px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>状态：</td>
                    <td>
                        <asp:DropDownList ID="state" runat="server">
                            <asp:ListItem Value="1">上线</asp:ListItem>
                            <asp:ListItem Value="0">下线</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td><td>
                    <asp:Button ID="Button1" runat="server" Text="发布" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
