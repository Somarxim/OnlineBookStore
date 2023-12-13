using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            YF.Model.User user = YF.BLL.User.GetUser(int.Parse(id));
            this.password.Text = user.Password;
            this.name.Text = user.Name;
            this.address.Text = user.Address;
            this.sex.Text = user.Sex.ToString();
            this.mobile.Text = user.Mobile;
            this.email.Text = user.Email;
            this.qq.Text = user.Qq;
            this.state.Text = user.State.ToString();
            this.id.Value = user.Id.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        YF.Model.User user = new YF.Model.User();
        user.Password = this.password.Text;
        user.Name = this.name.Text;
        user.Address = this.address.Text;
        user.Sex = int.Parse(this.sex.Text);
        user.Mobile = this.mobile.Text;
        user.Email = this.email.Text;
        user.Qq = this.qq.Text;
        user.State = int.Parse(this.state.Text);
        user.Id = int.Parse(this.id.Value);

        if (YF.BLL.User.update(user) == true)
        {
            YF.JsHelper.AlertAndRedirect("编辑成功！", "user.aspx");
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("编辑失败！", "user.aspx");
        }
    }
}