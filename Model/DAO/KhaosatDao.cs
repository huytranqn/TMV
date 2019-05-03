using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class KhaosatDao
    {

        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public KhaosatDao()
        {
            db = new OnlineTMV();
        }

        private static KhaosatDao instance;

        public static KhaosatDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhaosatDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public APP_KHAOSAT getByID(int _key)
        {
            return db.APP_KHAOSAT.SingleOrDefault(obj => obj.ID_KHAOSAT == _key);
        }

        //public DM_DICHVU getByForeign(int _key1)
        //{
        //    return db.DM_DICHVU.(obj => obj.MA_LOAIDV == _key1);
        //}

        //public bool deleteForeign(int _key1)
        //{
        //    db.DM_DICHVU.Remove(getByForeign(_key1));
        //    db.SaveChanges();
        //    return true;
        //}
        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(APP_KHAOSAT _ks)
        {
            var ks = db.APP_KHAOSAT.SingleOrDefault(obj => obj.ID_KHAOSAT == _ks.ID_KHAOSAT);
            return ks != default(APP_KHAOSAT) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(APP_KHAOSAT _request)
        {
            if (!hasProcuct(_request))
            {
                db.APP_KHAOSAT.Add(_request);
                _request.MODIFIED = DateTime.Now;
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
            db.APP_KHAOSAT.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }



        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var ks = getByID(_key);
            ks.TRANG_THAI = !ks.TRANG_THAI;
            db.SaveChanges();
            return ks.TRANG_THAI;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(APP_KHAOSAT _request)
        {
            var ks = getByID(_request.ID_KHAOSAT);
            ks.NOIDUNG_KHAOSAT = _request.NOIDUNG_KHAOSAT;
            ks.PHUONGAN_1 = _request.PHUONGAN_1;
            ks.PHUONGAN_2 = _request.PHUONGAN_2;
            ks.PHUONGAN_3 = _request.PHUONGAN_3;
            ks.TRA_LOI = _request.TRA_LOI;
            ks.TRANG_THAI = _request.TRANG_THAI;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<APP_KHAOSAT> ListAllPaging(string searchString, int page)
        {
            IQueryable<APP_KHAOSAT> model = db.APP_KHAOSAT;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NOIDUNG_KHAOSAT.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_KHAOSAT).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<APP_KHAOSAT> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.APP_KHAOSAT.OrderBy(p => p.ID_KHAOSAT).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.NOIDUNG_KHAOSAT.Contains(_search)).ToList();
            }

            totalRows = model.Count();
            totalPages = (int)Math.Ceiling((double)(totalRows / Constants.PageSize));

            return model.Skip((page - 1) * Constants.PageSize)
                        .Take(Constants.PageSize);
        }

        /**
         * @private
         * @description -- check the existence of image
         * @param imagefilePath: string -- is the path of the image file
         */

        //private bool hasReference(int _key)
        //{
        //    var ks = getByID(_key);
        //    if (ks != default(APP_KHAOSAT))
        //    {
        //        var count_one = db.APP_KHAOSAT.Where(obj => obj.ID_KHAOSAT == _key).ToList().Count;
        //        return count_one > Constants.zeroNumber;
        //    }
        //    return Constants.falseValue;
        //}

        public List<string> ListName(string keyword)
        {
            return db.APP_KHAOSAT.Where(x => x.NOIDUNG_KHAOSAT.Contains(keyword)).Select(x => x.NOIDUNG_KHAOSAT).ToList();
        }
        public List<APP_KHAOSAT> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.APP_KHAOSAT.Where(x => x.NOIDUNG_KHAOSAT.Contains(search_kw)).ToList();
            totalRecord = db.APP_KHAOSAT.Where(x => x.NOIDUNG_KHAOSAT.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }

    }
}
