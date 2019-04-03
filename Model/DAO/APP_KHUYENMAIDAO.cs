using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class APP_KHUYENMAIDAO
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public APP_KHUYENMAIDAO()
        {
            db = new OnlineTMV();
        }

        private static APP_KHUYENMAIDAO instance;

        public static APP_KHUYENMAIDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APP_KHUYENMAIDAO();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public APP_KHUYENMAI getByID(int _key)
        {
            return db.APP_KHUYENMAI.SingleOrDefault(obj => obj.ID_KHUYENMAI == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(APP_KHUYENMAI _pro)
        {
            var product = db.APP_KHUYENMAI.SingleOrDefault(obj => obj.ID_KHUYENMAI == _pro.ID_KHUYENMAI);
            return product != default(APP_KHUYENMAI) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(APP_KHUYENMAI _request)
        {
            if (!hasProcuct(_request))
            {
                _request.NGAY_TAO = DateTime.Now;
                db.APP_KHUYENMAI.Add(_request);
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
            db.APP_KHUYENMAI.Remove(getByID(_key));
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
            app_khuyenmai.TRANG_THAI = !app_khuyenmai.TRANG_THAI;
            db.SaveChanges();
            return app_khuyenmai.TRANG_THAI;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(APP_KHUYENMAI _request)
        {
            var app_khuyenmai = getByID(_request.ID_KHUYENMAI);
            app_khuyenmai.MOTA_VANTAT = _request.MOTA_VANTAT;
            app_khuyenmai.MOTA_CHITIET = _request.MOTA_CHITIET;
            app_khuyenmai.TRANG_THAI = _request.TRANG_THAI;
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


        public IEnumerable<APP_KHUYENMAI> ListAllPaging(string searchString, int page)
        {
            IQueryable<APP_KHUYENMAI> model = db.APP_KHUYENMAI;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MOTA_VANTAT.Contains(searchString) || x.MOTA_CHITIET.Contains(searchString));
            }
            return model.OrderByDescending(x => x.NGAY_TAO).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<APP_KHUYENMAI> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.APP_KHUYENMAI.OrderBy(p => p.NGAY_TAO).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.MOTA_VANTAT.Contains(_search)).ToList();
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

        //private bool hasReference(int _key)
        //{
        //    var promotion = getByID(_key);
        //    if (promotion != default(Promotion))
        //    {
        //        object count_one = db.Order.Where(obj => obj.ProID == _key).ToList().Count;
        //        return count_one > Constants.zeroNumber;
        //    }
        //    return Constants.falseValue;
        //}
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
            return db.APP_KHUYENMAI.Where(x => x.MOTA_VANTAT.Contains(keyword)).Select(x => x.MOTA_VANTAT).ToList();
        }
        public List<APP_KHUYENMAI> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.APP_KHUYENMAI.Where(x => x.MOTA_VANTAT.Contains(search_kw)).ToList();
            totalRecord = db.APP_KHUYENMAI.Where(x => x.MOTA_VANTAT.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}

