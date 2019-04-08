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
    public class NhacungcapDao
    {
        /**
* Constants
*/
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public NhacungcapDao()
        {
            db = new OnlineTMV();
        }

        private static NhacungcapDao instance;

        public static NhacungcapDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhacungcapDao();
                }
                return instance;
            }
        }

        public KH_NHA_CUNG_CAP getByID(int _key)
        {
            return db.KH_NHA_CUNG_CAP.SingleOrDefault(obj => obj.ID_NCC == _key);
        }

        public List<KH_NHA_CUNG_CAP> GetListActive()
        {
            return db.KH_NHA_CUNG_CAP.Where(x => x.TRANG_THAI == true).OrderByDescending(x => x.ID_NCC).ToList();
        }
    }
}
