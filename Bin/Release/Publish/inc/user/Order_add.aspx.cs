using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF;

public partial class user_Order_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int zongjia = 0;
        
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");//获取当前用户信息
        List<YF.Model.Shopping> list = YF.BLL.Shopping.list(myuser.Id);//通过用户ID查询购物车信息
        for(int i = 0; i < list.Count; i++)
        {
            zongjia = zongjia + list[i].Goods.Price * list[i].Num;//i=i+1
        }
        this.zongjia.Text = zongjia.ToString();//把总价返回到前台
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");//获取当前用户信息
        //生成订单编号
        string dingdanbianhao = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        YF.Model.Order myorder = new YF.Model.Order();//实例化一个空订单对象
        myorder.Id = dingdanbianhao;//赋值订单编号
        myorder.User = myuser;//赋值当前用户信息
        myorder.Amount = int.Parse(this.zongjia.Text);//赋值当前订单总价
        myorder.State = 1;//赋值当前订单状态
        myorder.Adddate = DateTime.Now;//获取当前订单时间
        if (YF.BLL.Order.add(myorder))//把订单对象，调用业务层，插入数据
        {
            YF.BLL.Shopping.updateshopping(dingdanbianhao, myuser.Id,0);//清空购物车
            YF.JsHelper.AlertAndRedirect("下单成功！", "/user/order.aspx");
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("下单失败！", "/user/order.aspx");
        }
    }
}