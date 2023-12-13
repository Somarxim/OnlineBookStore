<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="admin_order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单信息页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="1000" align="center" border="1">
    <tr align="center">
        <td>订单编号</td>
        <td>商品明细</td>
        <td>状态</td>
        <td>价格</td>
        <td>日期</td>
        <td>操作</td>
    </tr>
    <%
        if (Request.QueryString["action"] == "deliver")
        {
            string id = Request.QueryString["id"];
            YF.BLL.Order.update(id, 3);
            YF.JsHelper.AlertAndRedirect("发货成功！", "order.aspx");
        }
        List<YF.Model.Order> list = YF.BLL.Order.list();
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
        <td><a href="order.aspx?id=<% =list[i].Id %>&action=deliver">发货</a></td>
    </tr>
    <% } %>
</table>
        </div>
    </form>
</body>
</html>
