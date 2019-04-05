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
    public class LoaidichvuDao
    {
        /**
     * Constants
     */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public LoaidichvuDao()
        {
            db = new OnlineTMV();
        }

        private static LoaidichvuDao instance;

        public static LoaidichvuDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaidichvuDao();
                }
                return instance;
            }
        }

        public List<DM_LOAIDV> GetListActive()
        {
            return db.DM_LOAIDV.Where(x => x.HOAT_DONG == true).OrderByDescending(x => x.MA_LOAIDV).ToList();
        }
    }
}
