using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;


namespace Model.DAO
{
    public class HanghoaDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public HanghoaDao()
        {
            db = new OnlineTMV();
        }

        private static HanghoaDao instance;

        public static HanghoaDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HanghoaDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public KH_HANGHOA getByID(String _key)
        {
            return db.KH_HANGHOA.SingleOrDefault(obj => obj.MA_HANGHOA == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(KH_HANGHOA _pro)
        {
            var product = db.KH_HANGHOA.SingleOrDefault(obj => obj.MA_HANGHOA == _pro.MA_HANGHOA);
            return product != default(KH_HANGHOA) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(KH_HANGHOA _request)
        {
            if (!hasProcuct(_request))
            {
                db.KH_HANGHOA.Add(_request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /**
         * @description -- delete a product
         * @param _key: int -- is field ProdID
         */

        public bool delete(String _key)
        {
            //if (hasReference(_key))
            //    return false;
            db.KH_HANGHOA.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(String _key)
        {
            var hanghoa = getByID(_key);
            hanghoa.TRANG_THAI = !hanghoa.TRANG_THAI;
            db.SaveChanges();
            return hanghoa.TRANG_THAI;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(KH_HANGHOA _request)
        {
            var hanghoa = getByID(_request.MA_HANGHOA);
            hanghoa.TEN_HANGHOA = _request.TEN_HANGHOA;
            hanghoa.DON_GIA = _request.DON_GIA;
            hanghoa.MO_TA = _request.MO_TA;
            hanghoa.ID_DVT = _request.ID_DVT;
            hanghoa.GHI_CHU = _request.GHI_CHU;
            hanghoa.HINH_ANH = _request.HINH_ANH;
            hanghoa.ID_NCC = _request.ID_NCC;
            hanghoa.THU_TU = _request.THU_TU;
            hanghoa.ID_NHOMHH = _request.ID_NHOMHH;
            hanghoa.MA_VACH = _request.MA_VACH;
            hanghoa.MOTA_CHITIET = _request.MOTA_CHITIET;
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


        public IEnumerable<KH_HANGHOA> ListAllPaging(string searchString, int page)
        {
            IQueryable<KH_HANGHOA> model = db.KH_HANGHOA;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MO_TA.Contains(searchString) || x.MOTA_CHITIET.Contains(searchString));
            }
            return model.OrderByDescending(x => x.DON_GIA).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<KH_HANGHOA> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.KH_HANGHOA.OrderBy(p => p.DON_GIA).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.MO_TA.Contains(_search)).ToList();
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

        private bool hasReference(String _key)
        {
            var dichvu = getByID(_key);
            if (dichvu != default(KH_HANGHOA))
            {
                var count_one = db.KH_HANGHOA.Where(obj => obj.MA_HANGHOA == _key).ToList().Count;
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
            return db.KH_HANGHOA.Where(x => x.MO_TA.Contains(keyword)).Select(x => x.MO_TA).ToList();
        }
        public List<KH_HANGHOA> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.KH_HANGHOA.Where(x => x.MO_TA.Contains(search_kw)).ToList();
            totalRecord = db.KH_HANGHOA.Where(x => x.MO_TA.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}
