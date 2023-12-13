using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF;

namespace YF.BLL
{
    public class Comment
    {
        public static bool add(YF.Model.Comment comment)
        {
            return YF.DAL.Comment.add(comment);
        }
        public static List<YF.Model.Comment> list(int goodsid)
        {
            return YF.DAL.Comment.list(goodsid);
        }
        public static bool del(int id)
        {
            return YF.DAL.Comment.del(id);
        }
    }
}
