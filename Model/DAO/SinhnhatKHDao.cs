using Model.EF;
using Models.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SinhnhatKHDao
    {
        /**
    * Constants
    */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public SinhnhatKHDao()
        {
            db = new OnlineTMV();
        }

        private static SinhnhatKHDao instance;

        public static SinhnhatKHDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SinhnhatKHDao();
                }
                return instance;
            }
        }

        public List<APP_SINHNHAT_KHACHHANG> GetListActive()
        {
            return db.APP_SINHNHAT_KHACHHANG.Where(x => x.TRANG_THAI == true).OrderByDescending(x => x.ID_SINHNHAT).ToList();
        }

        public APP_SINHNHAT_KHACHHANG getByID(int _key)
        {
            return db.APP_SINHNHAT_KHACHHANG.SingleOrDefault(obj => obj.ID_SINHNHAT == _key);
        }
    }
}
