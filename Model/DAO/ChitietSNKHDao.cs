using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class ChitietSNKHDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public ChitietSNKHDao()
        {
            db = new OnlineTMV();
        }

        private static ChitietSNKHDao instance;

        public static ChitietSNKHDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChitietSNKHDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public APP_CHITIET_SINHNHAT_KHACHHANG getByID(int _key)
        {
            return db.APP_CHITIET_SINHNHAT_KHACHHANG.SingleOrDefault(obj => obj.ID_CHITIET_SINHNHAT == _key);
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool hasProcuct(APP_CHITIET_SINHNHAT_KHACHHANG _pro)
        {
            var chitiet = db.APP_CHITIET_SINHNHAT_KHACHHANG.SingleOrDefault(obj => obj.ID_CHITIET_SINHNHAT == _pro.ID_CHITIET_SINHNHAT);
            return chitiet != default(APP_CHITIET_SINHNHAT_KHACHHANG) ? true : false;
        }

        public bool insert(APP_CHITIET_SINHNHAT_KHACHHANG _request)
        {
            if (!hasProcuct(_request))
            {
                db.APP_CHITIET_SINHNHAT_KHACHHANG.Add(_request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /**
         * @description -- delete a product
         * @param _key: int -- is field ProdID
         */

        public bool delete(int _key)
        {
            //if (hasReference(_key))
            //    return false;
            db.APP_CHITIET_SINHNHAT_KHACHHANG.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(APP_CHITIET_SINHNHAT_KHACHHANG _request)
        {
            var chitiet = getByID(_request.ID_CHITIET_SINHNHAT);
            chitiet.ID_SINHNHAT = _request.ID_SINHNHAT;
            chitiet.MA_KHACHHANG = _request.MA_KHACHHANG;
            chitiet.GHI_CHU = _request.GHI_CHU;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<APP_CHITIET_SINHNHAT_KHACHHANG> ListAllPaging(string searchString, int page)
        {
            IQueryable<APP_CHITIET_SINHNHAT_KHACHHANG> model = db.APP_CHITIET_SINHNHAT_KHACHHANG;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.GHI_CHU.Contains(searchString) || x.MA_KHACHHANG.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_CHITIET_SINHNHAT).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<APP_CHITIET_SINHNHAT_KHACHHANG> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.APP_CHITIET_SINHNHAT_KHACHHANG.OrderBy(p => p.ID_CHITIET_SINHNHAT).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.MA_KHACHHANG.Contains(_search)).ToList();
            }

            totalRows = model.Count();
            totalPages = (int)Math.Ceiling((double)(totalRows / Constants.PageSize));

            return model.Skip((page - 1) * Constants.PageSize)
                        .Take(Constants.PageSize);
        }

        public List<string> ListName(string keyword)
        {
            return db.APP_CHITIET_SINHNHAT_KHACHHANG.Where(x => x.MA_KHACHHANG.Contains(keyword)).Select(x => x.MA_KHACHHANG).ToList();
        }
        public List<APP_CHITIET_SINHNHAT_KHACHHANG> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.APP_CHITIET_SINHNHAT_KHACHHANG.Where(x => x.MA_KHACHHANG.Contains(search_kw)).ToList();
            totalRecord = db.APP_CHITIET_SINHNHAT_KHACHHANG.Where(x => x.MA_KHACHHANG.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}
