using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF;

public partial class reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        YF.Model.User user = new YF.Model.User();
        user.Username = this.username.Text;
        user.Password = this.password.Text;
        user.Name = this.name.Text;
        user.Address = this.address.Text;
        user.Sex = int.Parse(this.sex.Text);
        user.Mobile = this.mobile.Text;
        user.Email = this.email.Text;
        user.Qq = this.qq.Text;
        user.State = 1;
        user.Adddate = DateTime.Now;

        if (YF.BLL.User.Search(this.username.Text) == false)
        {
            YF.JsHelper.AlertAndRedirect("用户名已存在！", "reg.aspx");
        }
            if (YF.BLL.User.add(user) == true)
        {
            YF.JsHelper.AlertAndRedirect("注册成功！", "index.aspx");
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("注册失败！", "index.aspx");
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        YF.JsHelper.Redirect("login.aspx");
    }
}