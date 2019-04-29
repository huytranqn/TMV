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
using System.Linq;
using System.Web;

namespace TMV.Areas.Admin.Controllers
{
    public class NoibatController : BaseController
    {
        // GET: Admin/APP_NOIBAT
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new NoibatDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(APP_NOIBAT model, HttpPostedFileBase fileUpLoad)
        {
            if (fileUpLoad != null && fileUpLoad.ContentLength > 0)
            {
                //tên file
                string fileName = Path.GetFileName(fileUpLoad.FileName);
                // đương dẫn
                string path = Path.Combine(Server.MapPath("~/Assets/Data/Images"), fileName);
                fileUpLoad.SaveAs(path);
                model.HINHANH_VIDEO = "/Assets/Data/Images/" + fileName;
            }
            if (ModelState.IsValid)
            {
                if (NoibatDao.Instance.insert(model))
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

        #region JsonResult

        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = NoibatDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }


}