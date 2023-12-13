using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.Model
{
    public class Comment
    {
        private int id;
        private YF.Model.Goods goods;
        private YF.Model.User user;
        private string detail;
        private DateTime adddate;

        public int Id { get => id; set => id = value; }
        public Goods Goods { get => goods; set => goods = value; }
        public User User { get => user; set => user = value; }
        public string Detail { get => detail; set => detail = value; }
        public DateTime Adddate { get => adddate; set => adddate = value; }
    }
}
