using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using YF;

public partial class goods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request["id"];
        YF.Model.Goods goods = YF.BLL.Goods.GetGoods(int.Parse(id));
        this.title.Text = goods.Title;
        this.author.Text = goods.Author;
        this.type.Text = goods.Type;
        this.price.Text = goods.Price.ToString();
        this.num.Text = goods.Num.ToString();
        this.detail.Text = goods.Detail.ToString();
        this.img.ImageUrl = "img/" + goods.Img.ToString();
        this.img.Width = 180;
        this.txtComment.Visible = false;
        this.btnSubmitComment.Visible = false;
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");
        if (myuser != null)
        {
            this.txtComment.Visible = true;
            this.btnSubmitComment.Visible = true;
        }
        else
        {
            // 用户未登录，隐藏评论框和提交按钮
            YF.JsHelper.Alert("尚未登录，无法评论！");
        }
    }

    protected void btnSubmitComment_Click(object sender, EventArgs e)
    {
        string commentstr = this.txtComment.Text;
        YF.Model.User myuser = new YF.Model.User();
        myuser = (YF.Model.User)YF.SessionHelper.GetSession("user");
        if (!string.IsNullOrEmpty(commentstr))
        {
            YF.Model.Comment comment = new YF.Model.Comment();
            int goodsid = int.Parse(Request.QueryString["id"].ToString());
            comment.Goods = YF.BLL.Goods.GetGoods(goodsid);
            comment.User = myuser;
            comment.Detail = commentstr;
            comment.Adddate = DateTime.Now;
            YF.BLL.Comment.add(comment);
        }
        this.txtComment.Visible = false;
        this.btnSubmitComment.Visible = false;
    }
}