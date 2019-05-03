using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using System.IO;

namespace TMV.Areas.Admin.Controllers
{
    public class KhaosatController : BaseController
    {
        // GET: Admin/Khaosat
        #region ActionResult
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new KhaosatDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(APP_KHAOSAT model)
        {
            if (ModelState.IsValid)
            {
                if (KhaosatDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khảo sát thất bại!");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var ks = KhaosatDao.Instance.getByID(id);
            return View(ks);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(APP_KHAOSAT model)
        {
            if (ModelState.IsValid)
            {
                if (KhaosatDao.Instance.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa khảo sát thất bại!");
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
                result = KhaosatDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = KhaosatDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}