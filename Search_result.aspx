<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search_result.aspx.cs" Inherits="Search_result" %>

<%@ Register src="inc/top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="inc/down.ascx" tagname="down" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网上书店</title>
<style>
    .container{
    display:flex;
    flex-direction:column;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <uc1:top ID="top1" runat="server" />
            <div style="width:1000px;margin:0 auto;">
                <asp:TextBox ID="searchbox" runat="server"></asp:TextBox>
                <asp:Button ID="search" runat="server" Text="搜索" PostBackUrl="~/Search_result.aspx"/>
            </div>
            <div style="width:1000px;margin:0 auto;">
                <ul style="list-style:none;margin:0;padding:0;">
                    <%
                        string searchstr = Request["searchbox"];
                        List<YF.Model.Goods> list = YF.BLL.Goods.search(searchstr);
                        for (int i = 0; i < list.Count; i++)
                        {
                    %>
                    <li style="float:left;height:180px;width:218px;text-align:center;border:#DEDEDE solid 1px;margin:10px 10px 10px 0;padding:10px;">
                        <a href="goods.aspx?id=<% =list[i].Id %>" target="_blank">
                            <img src="img/<% =list[i].Img %>" width="80" /><br /><% =list[i].Title %> | <% =list[i].Price %>
                        </a>
                    </li>
                    <% } %>
                </ul>
            </div>
            <div>
                <uc2:down ID="down1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
