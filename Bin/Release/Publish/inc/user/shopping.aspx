<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shopping.aspx.cs" Inherits="user_shopping" %>

<%@ Register Src="~/inc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/inc/top.ascx" TagPrefix="uc1" TagName="top" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc1" TagName="down" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>购物车</title>
    <style type="text/css">
        .auto-style1 {
            width: 106px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <uc1:top runat="server" ID="top" />
            <table width="1000" align="center" border="0">
                <tr>
                    <td class="auto-style1" valign="top">
                        <uc1:menu runat="server" ID="menu" />
                    </td>
                    <td align="center" valign="top">
                        <table width="100%" align="center" border="1">
                            <tr align="center">
                                <td>编号</td>
                                <td>商品</td>
                                <td>封面</td>
                                <td>价格</td>
                                <td>数量</td>
                                <td>操作</td>
                            </tr>
                            <%
                                string id = Request.QueryString["id"];
                                if (id != null)
                                {
                                    YF.BLL.Shopping.del(int.Parse(id));
                                    YF.JsHelper.AlertAndRedirect("删除成功！","shopping.aspx");
                                }
                                YF.Model.User myuser = new YF.Model.User();
                                myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");
                                List<YF.Model.Shopping> list = YF.BLL.Shopping.list(myuser.Id);
                                for (int i = 0; i < list.Count; i++)
                                {
                            %>
                            <tr align="center">
                                <td><% =list[i].Id %></td>
                                <td><% =list[i].Goods.Title %></td>
                                <td><img src="/img/<% =list[i].Goods.Img %>" width="50" /></td>
                                <td><% =list[i].Goods.Price %>.00</td>
                                <td><% =list[i].Num %></td>
                                <td><a href="shopping.aspx?id=<% =list[i].Id %>">删除</a></td>
                            </tr>
                            <% } %>
                        </table>
                        <table width="100%" align="center" border="1">
                            <tr>
                                <td align="right">

                                    <asp:Button ID="Button1" runat="server" Text="我要下单" OnClick="Button1_Click" />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc1:down runat="server" ID="down" />
        </div>
    </form>
</body>
</html>
