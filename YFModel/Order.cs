using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.Model
{
    public class Order
    {
        private string id;
        private YF.Model.User user;
        private int amount;
        private int state;
        private DateTime adddate;

        public string Id { get => id; set => id = value; }
        public User User { get => user; set => user = value; }
        public int Amount { get => amount; set => amount = value; }
        public int State { get => state; set => state = value; }
        public DateTime Adddate { get => adddate; set => adddate = value; }
    }
}
