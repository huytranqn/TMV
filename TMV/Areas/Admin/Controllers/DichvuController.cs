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
    public class DichvuController : BaseController
    {
        #region ActionResult
        // GET: Admin/dichvu
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new DichvuDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            SetCategoryViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DM_DICHVU model)
        {
            if (ModelState.IsValid)
            {
                if (DichvuDao.Instance.insert(model))
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
            var dichvu = DichvuDao.Instance.getByID(id);
            SetCategoryViewBag(dichvu.MA_LOAIDV);
            return View(dichvu);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(DM_DICHVU model)
        {
            if (ModelState.IsValid)
            {
                if (DichvuDao.Instance.Update(model))
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

        public void SetCategoryViewBag(int? selectedID = null)
        {
            var dao = new LoaidichvuDao();
            var listCategory = dao.GetListActive();
            ViewBag.MA_LOAIDV = new SelectList(listCategory, "MA_LOAIDV", "TEN_LOAIDV", selectedID);
        }


        #endregion

        #region ActionResult
        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = DichvuDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = DichvuDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        #endregion
    }


}