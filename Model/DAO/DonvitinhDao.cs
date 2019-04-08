using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;


namespace Model.DAO
{
    public class DonvitinhDao
    {
        /**
* Constants
*/
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public DonvitinhDao()
        {
            db = new OnlineTMV();
        }

        private static DonvitinhDao instance;

        public static DonvitinhDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DonvitinhDao();
                }
                return instance;
            }
        }

        public KH_DONVITINH getByID(int _key)
        {
            return db.KH_DONVITINH.SingleOrDefault(obj => obj.ID_DVT == _key);
        }

        public List<KH_DONVITINH> GetListActive()
        {
            return db.KH_DONVITINH.Where(x => x.TRANG_THAI == true).OrderByDescending(x => x.ID_DVT).ToList();
        }
    }
}
