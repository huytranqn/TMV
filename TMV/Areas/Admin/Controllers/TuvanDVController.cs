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
    public class TuvanDVController : BaseController
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
        public ActionResult Create(TBL_TUVAN_DICHVU model, string chonnv)
        {
            model.MA_KHACHHANG = chonnv;
            if (ModelState.IsValid)
            {
                if (TuvanDVDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khuyến mãi thất bại!");
                }
            }
            KhachHang(model.MA_KHACHHANG);
            SetCategoryViewBagNV(model.NHANVIEN_TUVAN);
            return View();
        }

        public void KhachHang(string mkh=null)
        {
            var dao = new TuvanDVDao();
            var list = dao.Khachhang();
            ViewBag.KHACHHANG = new SelectList(list,"KH","MKH", mkh);
        }

        public void SetCategoryViewBagNV(string manv = null)
        {

            var dao = new NhanvienDao();
            var listCategory = dao.GetListActive();
            ViewBag.NHANVIEN = new SelectList(listCategory,"TEN_NHANVIEN","TEN_NHANVIEN" ,manv);
            
        }
    }
}