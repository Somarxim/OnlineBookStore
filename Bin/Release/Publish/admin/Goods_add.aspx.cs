using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YF.Model;
using YF.BLL;
using System.IO;

public partial class admin_Goods_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        YF.Model.Goods goods = new YF.Model.Goods(); 
        goods.Title = this.title.Text.Trim();
        goods.Author = this.author.Text.Trim();
        goods.Type = this.type.Text.Trim();
        goods.Price = int.Parse(this.price.Text.Trim());
        goods.Num = int.Parse(this.num.Text.Trim());
        goods.Detail = this.detail.Text.Trim();
        goods.State = int.Parse(this.state.Text);
        goods.Adddate = DateTime.Now;

        if (img.HasFile)
        {
            string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Path.GetExtension(img.FileName);
            string filePath = "~/img/" + filename;
            img.SaveAs(MapPath(filePath));
            goods.Img = filename;
        }

        if (YF.BLL.Goods.add(goods))
        {
            YF.JsHelper.AlertAndRedirect("发布成功！", "Goods.aspx");
        }
        else
        {
            YF.JsHelper.AlertAndRedirect("发布失败！", "Goods_add.aspx");
        }
    }
}