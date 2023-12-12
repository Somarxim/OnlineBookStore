<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="user_order" %>

<%@ Register Src="~/inc/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/inc/top.ascx" TagPrefix="uc1" TagName="top" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc1" TagName="down" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户订单页</title>
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
                    <td align="center">
                        <table width="100%" align="center" border="1">
                            <tr align="center">
                                <td>订单编号</td>
                                <td>商品明细</td>
                                <td>状态</td>
                                <td>价格</td>
                                <td>日期</td>
                                <td>操作</td>
                            </tr>
                            <%
                                if (Request.QueryString["action"] == "pay")
                                {
                                    string id = Request.QueryString["id"];
                                    YF.BLL.Order.update(id, 2);
                                    YF.JsHelper.AlertAndRedirect("付款完成", "order.aspx");
                                }
                                else if(Request.QueryString["action"] == "over")
                                {
                                    string id = Request.QueryString["id"];
                                    YF.BLL.Order.update(id, 4);
                                    YF.JsHelper.AlertAndRedirect("订单完成", "order.aspx");
                                }
                                YF.Model.User myuser = new YF.Model.User();
                                myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");//获取当前用户信息
                                List<YF.Model.Order> list = YF.BLL.Order.list(myuser.Id);//通过用户ID查询订单信息
                                for (int i = 0; i < list.Count; i++)
                                {
                                    string state = "";
                                    if (list[i].State == 1)
                                    {
                                        state = "未付款";
                                    }
                                    else if (list[i].State == 2)
                                    {
                                        state = "已付款";
                                    }
                                    else if (list[i].State == 3)
                                    {
                                        state = "已发货";
                                    }
                                    else if (list[i].State == 4)
                                    {
                                        state = "已完成";
                                    }
                            %>
                            <tr align="center">
                                <td><% =list[i].Id %></td>
                                <td>
                                    <table>
                                        <tr>
                                            <% 
                                                List<YF.Model.Shopping> shoppinglist = YF.BLL.Shopping.list(list[i].Id);//通过订单编号查询关联购物车信息
                                                for (int j = 0; j < shoppinglist.Count; j++)
                                                {
                                                %>
                                            <td><img src="/img/<% =shoppinglist[j].Goods.Img %>" width="30" /></td>
                                            <td><% =shoppinglist[j].Goods.Title %>:</td>
                                            <td><% =shoppinglist[j].Num %>*<% =shoppinglist[j].Goods.Price %>.00=</td>
                                            <td><% =shoppinglist[j].Num * shoppinglist[j].Goods.Price %>.00</td>
                                        </tr>
                                            <% } %>
                                    </table>
                                </td>
                                <td><% =state %></td>
                                <td><% =list[i].Amount %>.00</td>
                                <td><% =list[i].Adddate %></td>
                                <td><a href="order.aspx?id=<% =list[i].Id %>&action=pay">付款</a>|<a href="order.aspx?id=<% =list[i].Id %>&action=over">完成</a></td>
                            </tr>
                            <% } %>
                        </table>
                        <table width="100%" align="center" border="1">
                            <tr>
                                <td align="right">

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
