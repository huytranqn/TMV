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
    public class KhachhangDao
    {
        /**
   * Constants
   */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public KhachhangDao()
        {
            db = new OnlineTMV();
        }

        private static KhachhangDao instance;

        public static KhachhangDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachhangDao();
                }
                return instance;
            }
        }

        public List<TBL_KHACHHANG> GetListActive()
        {
            return db.TBL_KHACHHANG.Where(x => x.KICHHOAT_THE == true).OrderByDescending(x => x.MA_KHACHHANG).ToList();
        }

        public TBL_KHACHHANG getByID(String _key)
        {
            return db.TBL_KHACHHANG.SingleOrDefault(obj => obj.MA_KHACHHANG == _key);
        }

        public bool Update(APP_CHITIET_SINHNHAT_KHACHHANG _request)
        {
            var kh = getByID(_request.MA_KHACHHANG);
            kh.BIRTHDAY = true ;
            db.SaveChanges();
            return true;
        }
    }
}
