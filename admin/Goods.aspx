<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods.aspx.cs" Inherits="admin_Goods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品管理页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="1100" align="center" border="1">
                <tr>
                    <td>
                        <asp:DropDownList ID="type" runat="server">
                            <asp:ListItem Value="所有"></asp:ListItem>
                            <asp:ListItem>现当代文学</asp:ListItem>
                            <asp:ListItem Value="外国经典"></asp:ListItem>
                            <asp:ListItem Value="国学经典"></asp:ListItem>
                            <asp:ListItem Value="乡土小说"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="select" runat="server" Text="确认" OnClick="select_Click" />
                    </td>
                </tr>
                <tr align="center">
                    <td>编号</td>
                    <td>商品</td>
                    <td>封面</td>
                    <td>价格</td>
                    <td>数量</td>
                    <td>时间</td>
                    <td>状态</td>
                    <td>操作</td>
                </tr>
                <%
                    string id = Request.QueryString["id"];
                    if (id != null)
                    {
                        if (YF.BLL.Shopping.listgoods(int.Parse(id)).Count > 0)
                        {
                            YF.JsHelper.AlertAndRedirect("商品不能删除！已有人购买！", "Goods.aspx");
                        }
                        else
                        {
                            YF.BLL.Goods.del(int.Parse(id));
                            YF.JsHelper.AlertAndRedirect("删除成功！", "Goods.aspx");
                        }
                    }
                    string type = this.type.Text;       
                    List<YF.Model.Goods> list = YF.BLL.Goods.typelist(type); 
                    if (type.Equals("所有")) { list = YF.BLL.Goods.list(); }
                    for (int i = 0; i < list.Count; i++)
                    {
                        string state = "";
                        if (list[i].State == 1) state = "正常";
                        else state = "下线";
                %>
                        <tr align="center">
                            <td><% =i+1 %></td>
                            <td><% =list[i].Title %></td>
                            <td><img src="../img/<% =list[i].Img %>" width="100" /></td>
                            <td><% =list[i].Price %></td>
                            <td><% =list[i].Num %></td>
                            <td><% =list[i].Adddate %></td>
                            <td><% =state %></td>
                            <td><a href="../goods.aspx?id=<% =list[i].Id %>" target="_blank">查看</a>|<a href="Good_edit.aspx?id=<% =list[i].Id %>">编辑</a>|<a href="Goods.aspx?id=<% =list[i].Id %>">删除</a></td>
                        </tr>
                <% } %>


                
            </table>
        </div>
    </form>
</body>
</html>
