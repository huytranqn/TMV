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
    public class NhomdichvuController : BaseController
    {
        // GET: Admin/Nhomdichvu
        #region ActionResult
        public ActionResult Index(string searchString, int page = 1)
        {
            var nhomdichvu = new NhomdichvuDao();
            var model = nhomdichvu.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DM_NHOMDV model)
        {
            if (ModelState.IsValid)
            {
                if (NhomdichvuDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhóm dịch vụ thất bại!");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var nhomdicvu = NhomdichvuDao.Instance.getByID(id);
            return View(nhomdicvu);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(DM_NHOMDV model)
        {
            if (ModelState.IsValid)
            {
                if (NhomdichvuDao.Instance.Update(model))
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
        public JsonResult Delete(int id)
        {
           // var dichvu = DichvuDao.Instance.deleteForeign(id);
            //var loaidichvu = LoaidichvuDao.Instance.deleteForeign(id);
            var result = NhomdichvuDao.Instance.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }

}