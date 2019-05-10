using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class TuvanDVDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public TuvanDVDao()
        {
            db = new OnlineTMV();
        }

        private static TuvanDVDao instance;

        public static TuvanDVDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TuvanDVDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public TBL_TUVAN_DICHVU getByID(int _key)
        {
            return db.TBL_TUVAN_DICHVU.SingleOrDefault(obj => obj.ID_TUVAN == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasTuvandicvu(TBL_TUVAN_DICHVU _tvdv)
        {
            var tvdv = db.DM_DICHVU.SingleOrDefault(obj => obj.MA_DICHVU == _tvdv.ID_TUVAN);
            return tvdv != default(DM_DICHVU) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(TBL_TUVAN_DICHVU _request)
        {
            if (!hasTuvandicvu(_request))
            {
                db.TBL_TUVAN_DICHVU.Add(_request);
                _request.MODIFIED = DateTime.Now;
                _request.NGAY_TUVAN = DateTime.Now;
                _request.APPROVE = false;
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
            db.TBL_TUVAN_DICHVU.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }



        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var tvdv = getByID(_key);
            tvdv.APPROVE = !tvdv.APPROVE;
            db.SaveChanges();
            return tvdv.APPROVE;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(TBL_TUVAN_DICHVU _request)
        {
            var tvdv = getByID(_request.ID_TUVAN);
            tvdv.MA_KHACHHANG = _request.MA_KHACHHANG;
            tvdv.NGAY_TUVAN = _request.NGAY_TUVAN;
            tvdv.NHANVIEN_TUVAN = _request.NHANVIEN_TUVAN;
            tvdv.NOIDUNG_TUVAN = _request.NOIDUNG_TUVAN;
            tvdv.GHI_CHU = _request.GHI_CHU;
            tvdv.MODIFIED = _request.MODIFIED;
            tvdv.APPROVE = _request.APPROVE;
            db.SaveChanges();
            return true;
        }

        public IEnumerable<TBL_TUVAN_DICHVU> ListAllPaging(string searchString, int page)
        {
            IQueryable<TBL_TUVAN_DICHVU> model = db.TBL_TUVAN_DICHVU;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MA_KHACHHANG.Contains(searchString) || x.NHANVIEN_TUVAN.Contains(searchString) || x.NOIDUNG_TUVAN.Contains(searchString) || x.GHI_CHU.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_TUVAN).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<TBL_TUVAN_DICHVU> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.TBL_TUVAN_DICHVU.OrderBy(p => p.ID_TUVAN).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.MA_KHACHHANG.Contains(_search) || obj.NHANVIEN_TUVAN.Contains(_search) || obj.NOIDUNG_TUVAN.Contains(_search)).ToList();
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

        private bool hasReference(int _key)
        {
            var tvdv = getByID(_key);
            if (tvdv != default(TBL_TUVAN_DICHVU))
            {
                var count_one = db.TBL_TUVAN_DICHVU.Where(obj => obj.ID_TUVAN == _key).ToList().Count;
                return count_one > Constants.zeroNumber;
            }
            return Constants.falseValue;
        }

        public List<TBL_KHACHHANG> Khachhang()
        {
            var query = from cust in db.TBL_KHACHHANG
                        where cust.NGUNG_HOATDONG == true
                        select cust;
            return query.ToList();
        }
    }
}
