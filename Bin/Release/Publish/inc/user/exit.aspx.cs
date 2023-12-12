using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF;

public partial class user_exit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        YF.SessionHelper.SetSession("user", null); 
        YF.JsHelper.Redirect("/login.aspx");
    }
}