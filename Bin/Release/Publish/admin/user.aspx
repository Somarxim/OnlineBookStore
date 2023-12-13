<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="admin_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户管理页</title>
<style type="text/css">
    .auto-style1 {
        width: 100px;
    }
    .auto-style2 {
        width: 100px;
        height: 30px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="1100" align="center" border="1">
    <tr align="center">
        <td class="auto-style1">编号</td>
        <td class="auto-style1">用户名</td>
        <td class="auto-style1">密码</td>
        <td class="auto-style1">姓名</td>
        <td class="auto-style1">地址</td>
        <td class="auto-style1">性别</td>
        <td class="auto-style1">手机</td>
        <td class="auto-style1">邮箱</td>
        <td class="auto-style1">QQ</td>
        <td class="auto-style1">状态</td>
        <td class="auto-style1">时间</td>
        <td class="auto-style1">操作</td>
    </tr>
    <%
        string id = Request.QueryString["id"];
        if (id != null)
        {
            YF.BLL.User.del(int.Parse(id));
            YF.JsHelper.AlertAndRedirect("删除成功！","user.aspx");
        }
        List<YF.Model.User> list = YF.BLL.User.list();
        %>
    <%
        for (int i = 0; i < list.Count; i++)
        {
            string sex = "";
            string state = "";
            if (list[i].Sex == 1) sex = "男";
            else sex = "女";
            if (list[i].State == 1) state = "正常";
            else state = "关闭";
    %>
     <tr align="center">
         <td class="auto-style2"><% =list[i].Id %></td>
         <td class="auto-style2"><% =list[i].Username %></td>
         <td class="auto-style2"><% =list[i].Password %></td>
         <td class="auto-style2"><% =list[i].Name %></td>
         <td class="auto-style2"><% =list[i].Address%></td>
         <td class="auto-style2"><% =sex %></td>
         <td class="auto-style2"><% =list[i].Mobile %></td>
         <td class="auto-style2"><% =list[i].Email %></td>
         <td class="auto-style2"><% =list[i].Qq %></td>
         <td class="auto-style2"><% =state %></td>
         <td class="auto-style2"><% =list[i].Adddate %></td>
         <td class="auto-style2"><a href="user.aspx?id=<%= list[i].Id %>">删除</a> | <a href="user_edit.aspx?id=<%= list[i].Id %>">编辑</a></td>
     </tr>
    <% } %>
</table>
        </div>
    </form>
</body>
</html>
