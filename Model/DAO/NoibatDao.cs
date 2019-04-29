using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class NoibatDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public NoibatDao()
        {
            db = new OnlineTMV();
        }

        private static NoibatDao instance;

        public static NoibatDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NoibatDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public APP_NOIBAT getByID(int _key)
        {
            return db.APP_NOIBAT.SingleOrDefault(obj => obj.ID_NOIBAT == _key);
        }

        public IEnumerable<APP_NOIBAT> ListAllPaging(string searchString, int page)
        {
            IQueryable<APP_NOIBAT> model = db.APP_NOIBAT;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENHINH_VIDEO.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_NOIBAT).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool hasProcuct(APP_NOIBAT _pro)
        {
            var chitiet = db.APP_NOIBAT.SingleOrDefault(obj => obj.ID_NOIBAT == _pro.ID_NOIBAT);
            return chitiet != default(APP_NOIBAT) ? true : false;
        }

        public bool insert(APP_NOIBAT _request)
        {
            if (!hasProcuct(_request))
            {
                db.APP_NOIBAT.Add(_request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool changeStatus(int _key)
        {
            var product = getByID(_key);
            product.TRANG_THAI = !product.TRANG_THAI;
            db.SaveChanges();
            return product.TRANG_THAI;
        }

    }
}
