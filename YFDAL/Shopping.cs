using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.DAL
{
    public class Shopping
    {
        public static List<YF.Model.Shopping> listgoods(int goodsid)
        {
            string strsql = "select * from t_shopping where goodsid=" + goodsid + " and state=1";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Shopping> list(int user)
        {
            string strsql = "select * from t_shopping where userid=" + user+" and state=0";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }

        public static List<YF.Model.Shopping> list(int goodsid,int user,int state)
        {
            string strsql = "select * from t_shopping where goodsid=" + goodsid+" and userid=" + user +" and state=" + state +"";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        /// <summary>
        /// 通过订单编号查询关联购物车信息
        /// </summary>
        /// <param name="dingdanbianhao">订单编号</param>
        /// <returns></returns>
        public static List<YF.Model.Shopping> list(string dingdanbianhao)
        {
            string strsql = "select * from t_shopping where orderid='" + dingdanbianhao + "' and state=1";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Shopping> Dotolist(DataTable dt)
        {
            List<YF.Model.Shopping> list = new List<Model.Shopping>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                YF.Model.Shopping shopping = new YF.Model.Shopping();
                shopping.Id = int.Parse(dt.Rows[i]["id"].ToString());
                YF.Model.Goods goods = YF.DAL.Goods.GetGoods(int.Parse(dt.Rows[i]["goodsid"].ToString()));
                shopping.Goods = goods;
                YF.Model.User user = YF.DAL.User.Getuser(int.Parse(dt.Rows[i]["userid"].ToString()));
                shopping.User = user;
                shopping.Num = int.Parse(dt.Rows[i]["num"].ToString());
                shopping.State = int.Parse(dt.Rows[i]["state"].ToString());
                shopping.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());
                list.Add(shopping);
            }
            return list;
        }
        public static bool updatenum(int goodsid, int user, int state)
        {
            bool result = false;
            string strsql = "update t_shopping set num=num+1 where goodsid=" + goodsid + " and userid=" + user + " and state=" + state + "";
            int i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 清空购物车，返回state=1
        /// </summary>
        /// <param name="dingdanbianhao">购物车信息和订单编号关联</param>
        /// <param name="user">用户</param>
        /// <param name="state">购物车信息状态</param>
        /// <returns></returns>
        public static bool updateshopping(string dingdanbianhao,int user, int state)
        {
            bool result = false;
            string strsql = "update t_shopping set orderid=" + dingdanbianhao + ",state=1 where userid=" + user + " and state=" + state + "";
            int i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool add(YF.Model.Shopping shopping)
        {
            bool result = false;
            string strsql = "insert into t_shopping(goodsid,orderid,userid,num,state,adddate) values (" + shopping.Goods.Id + ",''," + shopping.User.Id + "," + shopping.Num + "," + shopping.State + ",'" + shopping.Adddate + "')";
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
            string strsql = "delete from t_shopping where id=" + id + "";
            int i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
