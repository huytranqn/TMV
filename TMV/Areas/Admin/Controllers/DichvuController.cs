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
using System.Web;
using System.Linq;

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

        public ActionResult Edit(int id)
        {
            var dichvu = DichvuDao.Instance.getByID(id);
            var nhomdv = LoaidichvuDao.Instance.getByForeign(dichvu.MA_LOAIDV);
            var ndv = NhomdichvuDao.Instance.getByID(nhomdv.MA_NHOMDV);
            GetAllNhomDV(ndv.MA_NHOMDV);
            GetAllLoai(dichvu.MA_LOAIDV);
            GetAllDV(dichvu.MA_LOAIDV);
            //SetCategoryViewBag(dichvu.MA_LOAIDV);
            return View(dichvu);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(DM_DICHVU model, HttpPostedFileBase fileUpLoad)
        {
            if (fileUpLoad != null && fileUpLoad.ContentLength > 0)
            {
                //tên file
                string fileName = Path.GetFileName(fileUpLoad.FileName);
                // đương dẫn
                string path = Path.Combine(Server.MapPath("~/Assets/Data/Images"), fileName);
                fileUpLoad.SaveAs(path);
                model.HINH_ANH = "/Assets/Data/Images/" + fileName;
            }
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

        public void SetCategoryViewBagLDV(int? selectedID = null)
        {
            var dao = new LoaidichvuDao();
            var listCategory = dao.GetListActive();
            ViewBag.MA_LOAIDV = new SelectList(listCategory, "MA_LOAIDV", "TEN_LOAIDV", selectedID);
        }

        public void SetCategoryViewBagNDV(int? selectedID = null)
        {
            var dao = new NhomdichvuDao();
            var listCategory = dao.GetListActive();
            ViewBag.MA_LOAIDV = new SelectList(listCategory, "MA_NHOMDV", "TEN_NHOMDV", selectedID);
        }

        public void SetCategoryViewBagDV(int? selectedID = null)
        {
            var dao = new DichvuDao();
            var listCategory = dao.GetListActive();
            ViewBag.MA_LOAIDV = new SelectList(listCategory, "MA_NHOMDV", "TEN_NHOMDV", selectedID);
        }

        public JsonResult test()
        {
            OnlineTMV db = new OnlineTMV();
            var data = db.DM_NHOMDV.ToList();
           return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllNhomDV(int? NhomDV)
        {
            var data = NhomdichvuDao.Instance.GetAllNhomDV(NhomDV);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLoai(int? NhomDV)
        {
            var data = LoaidichvuDao.Instance.GetAllLoai(NhomDV);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDV(int? LoaiDV)
        {
            var data = DichvuDao.Instance.GetAllDV(LoaiDV);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

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