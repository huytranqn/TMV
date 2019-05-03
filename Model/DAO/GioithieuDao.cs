using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class GioithieuDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public GioithieuDao()
        {
            db = new OnlineTMV();
        }

        private static GioithieuDao instance;

        public static GioithieuDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GioithieuDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public APP_GIOITHIEU getByID(int _key)
        {
            return db.APP_GIOITHIEU.SingleOrDefault(obj => obj.ID_GIOITHIEU == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(APP_GIOITHIEU _pro)
        {
            var product = db.APP_GIOITHIEU.SingleOrDefault(obj => obj.ID_GIOITHIEU == _pro.ID_GIOITHIEU);
            return product != default(APP_GIOITHIEU) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(APP_GIOITHIEU _request)
        {
            if (!hasProcuct(_request))
            {
                db.APP_GIOITHIEU.Add(_request);
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
            db.APP_GIOITHIEU.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var gioithieu = getByID(_key);
            gioithieu.TRANG_THAI = !gioithieu.TRANG_THAI;
            db.SaveChanges();
            return gioithieu.TRANG_THAI;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(APP_GIOITHIEU _request)
        {
            var gioithieu = getByID(_request.ID_GIOITHIEU);
            gioithieu.MOTA_VANTAT = _request.MOTA_VANTAT;
            gioithieu.NOIDUNG_CHITIET = _request.NOIDUNG_CHITIET;
            gioithieu.TRANG_THAI = _request.TRANG_THAI;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<APP_GIOITHIEU> ListAllPaging(string searchString, int page)
        {
            IQueryable<APP_GIOITHIEU> model = db.APP_GIOITHIEU;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MOTA_VANTAT.Contains(searchString) || x.NOIDUNG_CHITIET.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_GIOITHIEU).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<APP_GIOITHIEU> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.APP_GIOITHIEU.OrderBy(p => p.ID_GIOITHIEU).ToList();

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
            return db.APP_GIOITHIEU.Where(x => x.MOTA_VANTAT.Contains(keyword)).Select(x => x.MOTA_VANTAT).ToList();
        }
        public List<APP_GIOITHIEU> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.APP_GIOITHIEU.Where(x => x.MOTA_VANTAT.Contains(search_kw)).ToList();
            totalRecord = db.APP_GIOITHIEU.Where(x => x.MOTA_VANTAT.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}

