using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF;

public partial class user_shopping_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");
        if (myuser != null)
        {
            YF.Model.Shopping shopping = new YF.Model.Shopping();
            int id = int.Parse(Request.QueryString["id"].ToString());
            YF.Model.Goods goods = YF.BLL.Goods.GetGoods(id);
            shopping.Goods = goods;
            shopping.User = myuser;
            shopping.Num = 1;
            shopping.State = 0;
            shopping.Adddate = DateTime.Now;
            //查询商品是否第一次加入购物车
            if (YF.BLL.Shopping.list(goods.Id, myuser.Id, 0).Count > 0)//不是第一次
            {
                YF.BLL.Shopping.updatenum(goods.Id, myuser.Id, 0);
                YF.JsHelper.AlertAndRedirect("操作成功！", "/user/shopping.aspx");
            }
            else
            {
                if (YF.BLL.Shopping.add(shopping))//第一次
                {
                    YF.JsHelper.AlertAndRedirect("操作成功！", "/user/shopping.aspx");
                }
                else
                {
                    YF.JsHelper.AlertAndRedirect("操作失败！", "/shopping.aspx");
                }
            }
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("尚未登录！", "/login.aspx");
        }
    }
}