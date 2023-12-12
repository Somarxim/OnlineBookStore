using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF.Model;

namespace YF.DAL
{
    public class Order
    {
        //把订单对象，插入订单数据
        public static bool add(YF.Model.Order order)
        {
            bool result = false;
            string strsql = "insert into t_order(id,userid,amount,state,adddate) values ('" + order.Id + "'," + order.User.Id + "," + order.Amount + "," + order.State + ",'" + order.Adddate + "')";
            int i = 0;
            i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="dingdanbianhao"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool update(string dingdanbianhao,int state)
        {
            bool result = false;
            string strsql = "update t_order set state=" + state + "where id='" + dingdanbianhao + "'";
            int i = 0;
            i = YF.MsSqlHelper.YFMsSqlHelper.ExecuteSql(strsql);
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 查询所有订单信息
        /// </summary>
        /// <returns></returns>
        public static List<YF.Model.Order> list()
        {
            string strsql = "select * from t_order order by adddate desc";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        //通过用户ID查询订单信息
        public static List<YF.Model.Order> list(int user)
        {
            string strsql = "select * from t_order where userid=" + user + " order by adddate desc";
            DataTable dt = YF.MsSqlHelper.YFMsSqlHelper.Query(strsql).Tables[0];
            return Dotolist(dt);
        }
        public static List<YF.Model.Order> Dotolist(DataTable dt)
        {
            List<YF.Model.Order> list = new List<Model.Order>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                YF.Model.Order order = new YF.Model.Order();
                order.Id = dt.Rows[i]["id"].ToString();
                YF.Model.User user = YF.DAL.User.Getuser(int.Parse(dt.Rows[i]["userid"].ToString()));
                order.Amount = int.Parse(dt.Rows[i]["amount"].ToString());
                order.State = int.Parse(dt.Rows[i]["state"].ToString());
                order.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());
                list.Add(order);
            }
            return list;
        }
    }
}
