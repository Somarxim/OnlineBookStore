using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_user_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YF.Model.User user = new YF.Model.User();
            user = (YF.Model.User)YF.SessionHelper.GetSession("user");
            this.password.Text = user.Password;
            this.name.Text = user.Name;
            this.address.Text = user.Address;
            this.sex.Text = user.Sex.ToString();
            this.mobile.Text = user.Mobile;
            this.email.Text = user.Email;
            this.qq.Text = user.Qq;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        YF.Model.User user = new YF.Model.User();
        user = (YF.Model.User)YF.SessionHelper.GetSession("user");
        user.Password = this.password.Text;
        user.Name = this.name.Text;
        user.Address = this.address.Text;
        user.Sex = int.Parse(this.sex.Text);
        user.Mobile = this.mobile.Text;
        user.Email = this.email.Text;
        user.Qq = this.qq.Text;
        if (YF.BLL.User.update(user))
        {
            YF.JsHelper.AlertAndRedirect("用户信息修改成功！", "index.aspx");
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("修改失败！", "index.aspx");
        }
    }
}