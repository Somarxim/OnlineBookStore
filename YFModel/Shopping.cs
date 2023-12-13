using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.Model
{
    public class Shopping
    {
        private int id;
        /// <summary>
        /// 关联商品
        /// </summary>
        private YF.Model.Goods goods;
        /// <summary>
        /// 关联用户订单
        /// </summary>
        private YF.Model.Order order;
        /// <summary>
        /// 关联用户
        /// </summary>
        private YF.Model.User user;
        /// <summary>
        /// 数量
        /// </summary>
        private int num;
        /// <summary>
        /// 状态
        /// </summary>
        private int state;
        /// <summary>
        /// 时间
        /// </summary>
        private DateTime adddate;

        public int Id { get => id; set => id = value; }
        public Goods Goods { get => goods; set => goods = value; }
        public Order Order { get => order; set => order = value; }
        public User User { get => user; set => user = value; }
        public int Num { get => num; set => num = value; }
        public int State { get => state; set => state = value; }
        public DateTime Adddate { get => adddate; set => adddate = value; }
    }
}
