using Model.EF;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Model.DAO
{
    public class NhomdichvuDao
    {

        /**
      * Constants
      */
        private OnlineTMV db = null;

        /**
         * @description -- init
         */

        public NhomdichvuDao()
        {
            db = new OnlineTMV();
        }

        private static NhomdichvuDao instance;

        public static NhomdichvuDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhomdichvuDao();
                }
                return instance;
            }
        }


        /**
         * @description -- get Promotion by ProdID
         * @param _key: int -- is field ProdID
         */

        public DM_NHOMDV getByID(int _key)
        {
            return db.DM_NHOMDV.SingleOrDefault(obj => obj.MA_NHOMDV == _key);
        }

        /**
         * @description -- check exits product in table Promotion
         * @param _prod: Promotion -- is a transion object
        */

        public bool hasProcuct(DM_NHOMDV _pro)
        {
            var nhomdichvu = db.DM_NHOMDV.SingleOrDefault(obj => obj.MA_NHOMDV == _pro.MA_NHOMDV);
            return nhomdichvu != default(DM_NHOMDV) ? true : false;
        }

        /**
         * @description -- insert a product
         * @param _request: Promotion -- entity object
         */

        public bool insert(DM_NHOMDV _request)
        {
            if (!hasProcuct(_request))
            {
                db.DM_NHOMDV.Add(_request);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /**
         * @description -- delete a product
         * @param _key: int -- is field ProdID
         */

        //public bool Delete(int cateID)
        //{
        //    try
        //    {
        //        var cate = db.DM_NHOMDV.Find(cateID);
        //        db.DM_NHOMDV.Remove(cate);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool Delete(int _key)
        {
            if (hasReference(_key))
                return false;
            db.DM_NHOMDV.Remove(getByID(_key));
            db.SaveChanges();
            return true;
        }

        /**
         * @description -- change status active
         * @param _key: int -- is field ProdID
         */

        /**
         * @description -- update info product has image
         * @param _request: PromotionRequestDto -- is the data transmitted down from the display screen
         */

        public bool Update(DM_NHOMDV _request)
        {
            var gioithieu = getByID(_request.MA_NHOMDV);
            gioithieu.TEN_NHOMDV = _request.TEN_NHOMDV;
            gioithieu.KHU_DV = _request.KHU_DV;
            gioithieu.HINH_ANH = _request.HINH_ANH;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<DM_NHOMDV> ListAllPaging(string searchString, int page)
        {
            IQueryable<DM_NHOMDV> model = db.DM_NHOMDV;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TEN_NHOMDV.Contains(searchString) || x.KHU_DV.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MA_NHOMDV).ToPagedList(page, Constants.PageSize);

        }

        /**
         * @description -- get products list by search key
         * @param _search: string -- is search key
         */

        public IEnumerable<DM_NHOMDV> getObjectList(string _search, int page, out int totalRows, out int totalPages)
        {
            var model = db.DM_NHOMDV.OrderBy(p => p.MA_NHOMDV).ToList();

            if (_search != null)
            {
                model = model.Where(obj => obj.TEN_NHOMDV.Contains(_search)).ToList();
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
            var nhomdichvu = getByID(_key);
            if (nhomdichvu != default(DM_NHOMDV))
            {
                var count_one = db.DM_DICHVU.Where(obj => obj.MA_LOAIDV == _key).ToList().Count;
                return count_one > 0;
            }
            return false;
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
            return db.DM_NHOMDV.Where(x => x.TEN_NHOMDV.Contains(keyword)).Select(x => x.TEN_NHOMDV).ToList();
        }
        public List<DM_NHOMDV> Search(string search_kw, ref int totalRecord, int pageIndex = 1)
        {
            var model = db.DM_NHOMDV.Where(x => x.TEN_NHOMDV.Contains(search_kw)).ToList();
            totalRecord = db.DM_NHOMDV.Where(x => x.TEN_NHOMDV.Contains(search_kw)).Count();//nghi nó bằng 0 chỗ này
            model = model.Skip((pageIndex - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();
            return model;
        }
    }
}
