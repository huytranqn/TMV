using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class PromotionDao
    {
        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public PromotionDao()
        {
            db = new OnlineTMV();
        }

        private static PromotionDao instance;

        public static PromotionDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PromotionDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public Promotion getByID(int _key)
        {
            return db.PROMOTION.SingleOrDefault(obj => obj.ProID == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(Promotion _pro)
        {
            var product = db.PROMOTION.SingleOrDefault(obj => obj.ProID == _pro.ProID);
            return product != default(Promotion) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(Promotion _request)
        {
            if (!hasProcuct(_request))
            {
                _request.CreateAt = DateTime.Now;
                db.PROMOTION.Add(_request);
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
            db.PROMOTION.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        public bool changeStatus(int _key)
        {
            var promotion = getByID(_key);
            promotion.isActive = !promotion.isActive;
            promotion.UpdateAt = DateTime.Now;
            db.SaveChanges();
            return promotion.isActive;
        }

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(Promotion _request)
        {
            var promotion = getByID(_request.ProID);
            promotion.ProTitle = _request.ProTitle;
            promotion.ProContent = _request.ProContent;
            promotion.UpdateAt = DateTime.Now;
            promotion.isActive = _request.isActive;
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


        public IEnumerable<Promotion> ListAllPaging(string searchString, int page)
        {
            IQueryable<Promotion> model = db.PROMOTION;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProTitle.Contains(searchString) || x.ProContent.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateAt).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<Promotion> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.PROMOTION.OrderBy(p => p.CreateAt).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.ProTitle.Contains(_search)).ToList();
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
            return db.PROMOTION.Where(x => x.ProTitle.Contains(keyword)).Select(x => x.ProTitle).ToList();
        }
        public List<Promotion> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.PROMOTION.Where(x => x.ProTitle.Contains(search_kw)).ToList();
            totalRecord = db.PROMOTION.Where(x => x.ProTitle.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}

