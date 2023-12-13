using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF.MsSqlHelper;
using System.Data;

namespace YF.DAL
{
    public class Goods
    {
        public static bool add(YF.Model.Goods goods)
        {
            bool result = false;
            string strsql = "insert into t_goods(title,author,type,price,num,img,detail,state,adddate) values ('" + goods.Title + "','" + goods.Author + "','" + goods.Type + "'," + goods.Price + "," + goods.Num + ",'" + goods.Img + "','" + goods.Detail + "'," + goods.State + ",'" + goods.Adddate + "')";
            int i = 0;
            i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if(i > 0)
            {
                result = true;
            }
            return result;
        }

        public static YF.Model.Goods GetGoods(int id)
        {
            string strsql = "select * from t_goods where id=" + id + "";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            List<YF.Model.Goods> list = Dotolist(dt);
            return list[0];
        }
        public static List<YF.Model.Goods> search(string title)
        {
            string strsql = "select * from t_goods where title='" + title + "' and state = 1";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Goods> listUI()
        {
            string strsql = "select * from t_goods where state = 1";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Goods> list()
        {
            string strsql = "select * from t_goods";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Goods> typelist(string type)
        {
            string strsql = "select * from t_goods where type='" + type + "'";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Goods> Dotolist(DataTable dt)
        {
            List<YF.Model.Goods> list = new List<Model.Goods>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                YF.Model.Goods goods = new YF.Model.Goods();
                goods.Id = int.Parse(dt.Rows[i]["id"].ToString());
                goods.Title = dt.Rows[i]["title"].ToString();
                goods.Author = dt.Rows[i]["author"].ToString();
                goods.Type = dt.Rows[i]["type"].ToString();
                goods.Price = int.Parse(dt.Rows[i]["price"].ToString());
                goods.Num = int.Parse(dt.Rows[i]["num"].ToString()) ;
                goods.Img = dt.Rows[i]["img"].ToString();
                goods.Detail = dt.Rows[i]["detail"].ToString() ;
                goods.State = int.Parse(dt.Rows[i]["state"].ToString()) ;
                goods.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());
                list.Add(goods);
            }
            return list;
        }
        public static bool update(YF.Model.Goods goods)
        {
            bool result = false;
            string strsql = "update t_goods set title='" + goods.Title + "',author='" + goods.Author + "',type='" + goods.Type + "', price=" + goods.Price + ",num=" + goods.Num + ",detail='" + goods.Detail + "',state=" + goods.State + ",img='" + goods.Img + "' where id=" + goods.Id + "";
            int i = 0;
            i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool del(int id)
        {
            bool result = false;
            string strsql = "delete from t_goods where id=" + id + "";
            int i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
