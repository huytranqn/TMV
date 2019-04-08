using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;


namespace Model.DAO
{
    public class NhomhanghoaDao
    {
       /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public NhomhanghoaDao()
        {
            db = new OnlineTMV();
        }

        private static NhomhanghoaDao instance;

        public static NhomhanghoaDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhomhanghoaDao();
                }
                return instance;
            }
        }
        public KH_NHOMHANGHOA getByID(int _key)
        {
            return db.KH_NHOMHANGHOA.SingleOrDefault(obj => obj.ID_NHOMHH == _key);
        }

        public List<KH_NHOMHANGHOA> GetListActive()
        {
            return db.KH_NHOMHANGHOA.Where(x => x.TRANG_THAI == true).OrderByDescending(x => x.ID_NHOMHH).ToList();
        }

    }
}




