using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF;

public partial class user_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");
        if(myuser != null)
        {
            this.username.Text = myuser.Username;
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("尚未登录！", "/login.aspx");
        }
    }
}