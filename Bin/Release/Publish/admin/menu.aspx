<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="admin_menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网上书店后台管理系统</title>
</head>
<body style="background:#DEDEDE;margin:0;padding:0;">
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr align="center"><td><a href="user.aspx" target="shopping">用户管理</a></td></tr>
                <tr align="center"><td><a href="Goods.aspx" target="shopping">商品管理</a></td></tr>
                <tr align="center"><td><a href="Goods_add.aspx" target="shopping">商品发布</a></td></tr>
                <tr align="center"><td><a href="order.aspx" target="shopping">订单管理</a></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
