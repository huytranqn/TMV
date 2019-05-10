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

namespace TMV.Areas.Admin.Controllers
{
    public class TuvanDVController : Controller
    {
        // GET: Admin/TuvanDV
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new TuvanDVDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            KhachHang();
            SetCategoryViewBagNV();
            return View();

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(TBL_TUVAN_DICHVU model)
        {
            if (ModelState.IsValid)
            {
                if (TuvanDVDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tư vấn thất bại!");
                }
            }
            KhachHang(model.MA_KHACHHANG);
            SetCategoryViewBagNV(model.NHANVIEN_TUVAN);
            return View();
        }


        public ActionResult Edit(int id)
        {
            var tuvan = TuvanDVDao.Instance.getByID(id);
            return View(tuvan);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(TBL_TUVAN_DICHVU model)
        {
            if (ModelState.IsValid)
            {
                if (TuvanDVDao.Instance.Update(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa sản phẩm thất bại!");
                }
            }
            KhachHang(model.MA_KHACHHANG);
            SetCategoryViewBagNV(model.NHANVIEN_TUVAN);
            return View(model);
        }

        public void KhachHang(string mkh=null)
        {
            var dao = new TuvanDVDao();
            var list = dao.Khachhang();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (TBL_KHACHHANG kh in list)
            {
                listItems.Add(new SelectListItem
                {
                    Text = kh.HO_TEN+"-"+kh.DIEN_THOAI,
                    Value = kh.MA_KHACHHANG
                });
            }
           
            ViewBag.KHACHHANG = new SelectList (listItems, "Value", "Text", mkh);
        }

        public void SetCategoryViewBagNV(string manv = null)
        {

            var dao = new NhanvienDao();
            var listCategory = dao.GetListActive();
            ViewBag.NHANVIEN = new SelectList(listCategory,"TEN_NHANVIEN","TEN_NHANVIEN" ,manv);
            
        }

        #region ActionResult
        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = TuvanDVDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = TuvanDVDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}