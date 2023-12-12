using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF;

namespace YF.BLL
{
    public class Shopping
    {
        public static List<YF.Model.Shopping> listgoods(int goodsid)
        {
            return YF.DAL.Shopping.listgoods(goodsid);
        }
        public static bool add(YF.Model.Shopping shopping)
        {
            return YF.DAL.Shopping.add(shopping);
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="dingdanbianhao">购物车信息和订单编号关联</param>
        /// <param name="user">用户</param>
        /// <param name="state">购物车信息状态</param>
        /// <returns></returns>
        public static bool updateshopping(string dingdanbianhao, int user, int state)
        {
            return YF.DAL.Shopping.updateshopping(dingdanbianhao, user, state);
        }
        public static List<YF.Model.Shopping> list(int user)
        {
            return YF.DAL.Shopping.list(user);
        }
        /// <summary>
        /// 通过订单编号查询关联购物车信息
        /// </summary>
        /// <param name="dingdanbianhao">订单编号</param>
        /// <returns></returns>
        public static List<YF.Model.Shopping> list(string dingdanbianhao)
        {
            return YF.DAL.Shopping.list(dingdanbianhao);
        }

        public static List<YF.Model.Shopping> list(int goodsid, int user, int state)
        {
            return YF.DAL.Shopping.list(goodsid,user,state);
        }
        public static bool updatenum(int goodsid, int user, int state)
        {
            return YF.DAL.Shopping.updatenum(goodsid, user, state);
        }
        public static bool del(int id)
        {
            return YF.DAL.Shopping.del(id);
        }
    }

}
