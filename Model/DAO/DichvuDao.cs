using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class DichvuDao
    {

        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public DichvuDao()
        {
            db = new OnlineTMV();
        }

        private static DichvuDao instance;

        public static DichvuDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DichvuDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public DM_DICHVU getByID(int _key)
        {
            return db.DM_DICHVU.SingleOrDefault(obj => obj.MA_DICHVU == _key);
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

        public bool hasProcuct(DM_DICHVU _pro)
        {
            var product = db.DM_DICHVU.SingleOrDefault(obj => obj.MA_DICHVU == _pro.MA_DICHVU);
            return product != default(DM_DICHVU) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(DM_DICHVU _request)
        {
            if (!hasProcuct(_request))
            {
                db.DM_DICHVU.Add(_request);
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
            if (hasReference(_key))
                return false;
            var dichvu = getByID(_key);
            dichvu.HINH_ANH = "";
            dichvu.MOTA_CHITIET = "";
            db.SaveChanges();
            return true;
        }



        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var app_khuyenmai = getByID(_key);
            app_khuyenmai.NGUNG_KINHDOANH = !app_khuyenmai.NGUNG_KINHDOANH;
            db.SaveChanges();
            return app_khuyenmai.NGUNG_KINHDOANH;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(DM_DICHVU _request)
        {
            var dichvu = getByID(_request.MA_DICHVU);
            dichvu.TEN_DICHVU = _request.TEN_DICHVU;
            dichvu.MOTA_CHITIET = _request.MOTA_CHITIET;
            dichvu.NGUNG_KINHDOANH = _request.NGUNG_KINHDOANH;
            dichvu.GIA_DICHVU = _request.GIA_DICHVU;
            dichvu.GIA_KHUYENMAI = _request.GIA_KHUYENMAI;
            dichvu.HINH_ANH = _request.HINH_ANH;
            dichvu.MA_DICHVU = _request.MA_DICHVU;
            dichvu.THOIGIAN_LAMVIEC=_request.THOIGIAN_LAMVIEC;
            db.SaveChanges();
            return true;
        }
        //public bool UpdateWantity(Promotion _request)
        //{
        //    var product = getByID(_request.ProID);
        //    product.UpdatedAt = DateTime.Now;
        //    product.isActive = _request.isActive;
        //    product.Wantity = _request.Wantity;
        //    db.SaveChanges();
        //    return true;
        //}


        public IEnumerable<DM_DICHVU> ListAllPaging(string searchString, int page)
        {
            IQueryable<DM_DICHVU> model = db.DM_DICHVU;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TEN_DICHVU.Contains(searchString) || x.MOTA_CHITIET.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MA_DICHVU).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<DM_DICHVU> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.DM_DICHVU.OrderBy(p => p.MA_DICHVU).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.TEN_DICHVU.Contains(_search)).ToList();
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


        //public List<Promotion> ListNewPromotion(int top, string _keysearch)
        //{
        //    return db.PROMOTION.OrderByDescending(x => x.CreateAt).Where(x => x.ProdName.Contains(_keysearch)).Take(top).ToList();
        //    //return db.Promotion.OrderByDescending(x => x.CreatedAt).Take(top).ToList();
        //}

        private bool hasReference(int _key)
        {
            var dichvu = getByID(_key);
            if (dichvu != default(DM_DICHVU))
            {
                var count_one = db.DM_LOAIDV.Where(obj => obj.MA_LOAIDV == _key).ToList().Count;
                return count_one > Constants.zeroNumber;
            }
            return Constants.falseValue;
        }
        //public List<Promotion> ListRelatePromotion(int productID)
        //{
        //    var product = db.PROMOTION.Find(productID);
        //    return db.PROMOTION.Where(x => x.ProID != productID && x.CateID == product.CateID).ToList();
        //}

        //public List<Promotion> ListByCategoryId(ref int totalRecord, int pageIndex = 1, string key_search = "")
        //{
        //    var model = db.PROMOTION.OrderBy(x => x.ProID).Where(x => x.ProdName.Contains(key_search)).ToList();
        //    totalRecord = model.Count();//nghi nó bằng 0 chỗ này
        //    model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
        //    return model;
        //}

        public List<string> ListName(string keyword)
        {
            return db.DM_DICHVU.Where(x => x.TEN_DICHVU.Contains(keyword)).Select(x => x.TEN_DICHVU).ToList();
        }
        public List<DM_DICHVU> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.DM_DICHVU.Where(x => x.TEN_DICHVU.Contains(search_kw)).ToList();
            totalRecord = db.DM_DICHVU.Where(x => x.TEN_DICHVU.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }

        //public DM_DICHVU getByForeign(int _key)
        //{
        //    return db.DM_DICHVU.SingleOrDefault(obj => obj.MA_LOAIDV == _key);
        //}

        //public bool deleteForeign(int _key)
        //{
        //    db.DM_DICHVU.Remove(getByForeign(_key));
        //    db.SaveChanges();
        //    return true;
        //}
    }
}
