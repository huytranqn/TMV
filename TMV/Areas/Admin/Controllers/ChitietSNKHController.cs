using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.IO;
using System.Text;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace TMV.Areas.Admin.Controllers
{
    public class ChitietSNKHController : BaseController
    {
        // GET: Admin/ChitietSNKH
        #region ActionResult
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new ChitietSNKHDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            SetCategoryViewBag();
            SetCategoryViewBag1();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(APP_CHITIET_SINHNHAT_KHACHHANG model)
        {
            if (ModelState.IsValid)
            {
                if (ChitietSNKHDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khuyến mãi thất bại!");
                }
            }
            SetCategoryViewBag();
            SetCategoryViewBag1();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var sn = ChitietSNKHDao.Instance.getByID(id);
            SetCategoryViewBag(sn.ID_SINHNHAT);
            SetCategoryViewBag1(sn.MA_KHACHHANG);
            return View(sn);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(APP_CHITIET_SINHNHAT_KHACHHANG model)
        {
            if (ModelState.IsValid)
            {
                if (ChitietSNKHDao.Instance.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa sản phẩm thất bại!");
                }
            }
            SetCategoryViewBag(model.ID_SINHNHAT);
            SetCategoryViewBag1(model.MA_KHACHHANG);
            return View(model);
        }

        public void SetCategoryViewBag(int? selectedID = null)
        {
            var dao = new SinhnhatKHDao();
            var listCategory = dao.GetListActive();
            ViewBag.SINHNHAT = new SelectList(listCategory, "ID_SINHNHAT", "NOI_DUNG", selectedID);
        }

        public void SetCategoryViewBag1(string makh=null)
        {
            
            var dao = new KhachhangDao();
            var listCategory = dao.GetListActive();
            ViewBag.KHACHHANG = new SelectList(listCategory, "MA_KHACHHANG", "HO_TEN", makh);
        }

        #endregion

        #region ActionResult
        public JsonResult Delete(int id)
        {
            var result = ChitietSNKHDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}