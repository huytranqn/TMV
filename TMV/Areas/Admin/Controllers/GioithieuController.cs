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
    public class GioithieuController : BaseController
    {
        // GET: Admin/Gioithieu
        #region ActionResult
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new GioithieuDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(APP_GIOITHIEU model)
        {
            if (ModelState.IsValid)
            {
                if (GioithieuDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khuyến mãi thất bại!");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var app_khuyenmai = GioithieuDao.Instance.getByID(id);
            return View(app_khuyenmai);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(APP_GIOITHIEU model)
        {
            if (ModelState.IsValid)
            {
                if (GioithieuDao.Instance.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa sản phẩm thất bại!");
                }
            }
            return View(model);
        }

        #endregion

        #region ActionResult
        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = GioithieuDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = GioithieuDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}