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
    public class HanghoaController : Controller
    {
        // GET: Admin/Hanghoa
        #region ActionResult
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new HanghoaDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        public ActionResult Create()
        {
            SetCategoryViewBagDVT();
            SetCategoryViewBagNHOMHH();
            SetCategoryViewBagNCC();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(KH_HANGHOA model)
        {
            if (ModelState.IsValid)
            {
                if (HanghoaDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhóm hàng hóa thất bại!");
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var dichvu = HanghoaDao.Instance.getByID(id);
            SetCategoryViewBagDVT(dichvu.ID_DVT);
            SetCategoryViewBagNHOMHH(dichvu.ID_NHOMHH);
            SetCategoryViewBagNCC(dichvu.ID_NCC);
            return View(dichvu);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(KH_HANGHOA model)
        {
            if (ModelState.IsValid)
            {
                if (HanghoaDao.Instance.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa hàng hóa thất bại!");
                }
            }
            SetCategoryViewBagDVT(model.ID_DVT);
            SetCategoryViewBagNHOMHH(model.ID_NHOMHH);
            SetCategoryViewBagNCC(model.ID_NCC);
            return View(model);
        }

        public void SetCategoryViewBagDVT(int? selectedID = null)
        {
            var dao = new DonvitinhDao();
            var listCategory = dao.GetListActive();
            ViewBag.DVT = new SelectList(listCategory, "ID_DVT", "TEN_DVT", selectedID);
        }

        public void SetCategoryViewBagNHOMHH(int? selectedID = null)
        {
            var dao = new NhomhanghoaDao();
            var listCategory = dao.GetListActive();
            ViewBag.NHOMHH = new SelectList(listCategory, "ID_NHOMHH", "TEN_NHOMHH", selectedID);
        }

        public void SetCategoryViewBagNCC(int? selectedID = null)
        {
            var dao = new NhacungcapDao();
            var listCategory = dao.GetListActive();
            ViewBag.NCC = new SelectList(listCategory, "ID_NCC", "TEN_NCC", selectedID);
        }


        #endregion

        #region ActionResult
        public JsonResult ChangeStatus(string id)
        {
            bool result = false;
            try
            {
                result = HanghoaDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(string id)
        {
            var result = HanghoaDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}