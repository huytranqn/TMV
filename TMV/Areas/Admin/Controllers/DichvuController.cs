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

        public ActionResult Edit()
        {
            GetAllNhomDV();
            GetAllLoai();
            GetAllDV();    
            return View();
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

            //bool hasErrors = ViewData.ModelState.Values.Any(x => x.Errors.Count > 1);
            //ModelState.IsValid
            if (!(ViewData.ModelState.Values.Any(x => x.Errors.Count > 1)))
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

        public JsonResult GetAllNhomDV()
        {
            
            var data = NhomdichvuDao.Instance.GetAllNhomDV();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllLoai(int? NhomDV=null)
        {
            var data = LoaidichvuDao.Instance.GetAllLoai(NhomDV);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDV(int? LoaiDV=null)
        {
            var data = DichvuDao.Instance.GetAllDV(LoaiDV);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDV(int? maDV = null)
        {
            var data = DichvuDao.Instance.GetDV(maDV);
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

        public JsonResult Add(int ma, string ten,int loai, float gia,float km, string tg,int thutu,bool kd, DateTime mod, DM_DICHVU model, HttpPostedFileBase fileUpLoad)
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
            model.MA_DICHVU = ma;
            model.TEN_DICHVU = ten;
            model.MA_LOAIDV = loai;
            model.GIA_DICHVU = gia;
            model.GIA_KHUYENMAI =km;
            model.THOIGIAN_LAMVIEC = tg;
            model.THU_TU = thutu;
            model.NGUNG_KINHDOANH = kd;
            model.MODIFIED = mod;
            var result = DichvuDao.Instance.insert(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }


}