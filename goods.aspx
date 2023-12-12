<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goods.aspx.cs" Inherits="goods" %>

<%@ Register src="inc/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="inc/down.ascx" tagname="down" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>书籍详情页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:top ID="top1" runat="server" />
            <table width="1000" align="center" border="0">
                <tr>
                    <td rowspan="6" align="center" style="width:300px;">
                        <asp:Image ID="img" runat="server" />
                    </td>
                    <td>书名：<asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>作者：<asp:Label ID="author" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>类别：<asp:Label ID="type" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>价格：<asp:Label ID="price" runat="server" Text="Label"></asp:Label>￥
                    </td>
                </tr>
                <tr>
                    <td>库存：<asp:Label ID="num" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><a href="/user/shopping_add.aspx?id=<% =Request.QueryString["id"] %>">购买</a></td>
                    <td>
                        <asp:Button ID="comment" runat="server" Text="评论" OnClick="comment_Click" />
                    </td>
                </tr>
            </table>
            <table width="1000" align="center" border="1">
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="detail" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="1000" align="center" border="0"  style="background:#DEDEDE;">
                <tr><td>评论</td></tr>
                <%
                    List<YF.Model.Comment> list = YF.BLL.Comment.list(int.Parse(Request.QueryString["id"]));
                    for (int i = 0; i < list.Count; i++)
                    {
                %>
                <tr>
                    <td style="color:deepskyblue"><% =list[i].User.Name %>:<% =list[i].Detail %></td>
                    <td align="right"><% =list[i].Adddate.Hour %>:<% =list[i].Adddate.Minute %></td>
                </tr>
                <% } %>
            </table>
            <table width="1000" align="center" border="0">
                <tr>
                    <td><asp:TextBox ID="txtComment" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnSubmitComment" runat="server" Text="确认" OnClick="btnSubmitComment_Click" /></td>
                </tr>
            </table>
            <uc2:down ID="down1" runat="server" />
        </div>
    </form>
</body>
</html>
