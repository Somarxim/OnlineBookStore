using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF;

namespace YF.BLL
{
    public class Order
    {
        //把订单对象，调用数据库访问层，插入数据
        public static bool add(YF.Model.Order order)
        {
            return YF.DAL.Order.add(order);
        }
        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="dingdanbianhao"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool update(string dingdanbianhao, int state)
        {
            return YF.DAL.Order.update(dingdanbianhao,state);
        }
        //查询所有订单信息
        public static List<YF.Model.Order> list()
        {
            return YF.DAL.Order.list();
        }
        //通过用户ID查询订单信息
        public static List<YF.Model.Order> list(int user)
        {
            return YF.DAL.Order.list(user);
        }
    }
}
