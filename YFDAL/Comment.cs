using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF.Model;

namespace YF.DAL
{
    public class Comment
    {
        public static bool add(YF.Model.Comment comment)
        {
            bool result = false;
            string strsql = "insert into t_comment(goodsid,userid,detail,adddate) values (" + comment.Goods.Id + "," + comment.User.Id + ",'" + comment.Detail + "','" + comment.Adddate + "')";
            int i = 0;
            i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static List<YF.Model.Comment> list(int goodsid)
        {
            string strsql = "select * from t_comment where goodsid=" + goodsid + "";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Comment> Dotolist(DataTable dt)
        {
            List<YF.Model.Comment> list = new List<Model.Comment>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                YF.Model.Comment comment = new YF.Model.Comment();
                comment.Id = int.Parse(dt.Rows[i]["id"].ToString());
                YF.Model.Goods goods = YF.DAL.Goods.GetGoods(int.Parse(dt.Rows[i]["goodsid"].ToString()));
                comment.Goods = goods;
                YF.Model.User user = YF.DAL.User.Getuser(int.Parse(dt.Rows[i]["userid"].ToString()));
                comment.User = user;
                comment.Detail = dt.Rows[i]["detail"].ToString();
                comment.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());
                list.Add(comment);
            }
            return list;
        }
        public static bool del(int id)
        {
            bool result = false;
            string strsql = "delete from t_comment where id=" + id + "";
            int i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
