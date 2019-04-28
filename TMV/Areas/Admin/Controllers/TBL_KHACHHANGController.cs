using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace TMV.Areas.Admin.Controllers
{
    public class TBL_KHACHHANGController : Controller
    {
        private OnlineTMV db = new OnlineTMV();

        // GET: Admin/TBL_KHACHHANG
        public ActionResult Index()
        {
            return View(db.TBL_KHACHHANG.ToList());
        }

        // GET: Admin/TBL_KHACHHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KHACHHANG tBL_KHACHHANG = db.TBL_KHACHHANG.Find(id);
            if (tBL_KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KHACHHANG);
        }

        // GET: Admin/TBL_KHACHHANG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TBL_KHACHHANG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_KHACHHANG,HO_TEN,DIA_CHI,DIEN_THOAI,EMAIL,NGAY_SINH,GIOI_TINH,NO_DAU_KY,SO_THE,NGAY_KICHHOAT,NGAY_HETHAN,SO_TIEN,TIEN_SU_DUNG_DV,DIEM_TICH_LUY,KICHHOAT_THE,GHI_CHU,NGUNG_HOATDONG,SO_CMND,MAT_KHAU")] TBL_KHACHHANG tBL_KHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.TBL_KHACHHANG.Add(tBL_KHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_KHACHHANG);
        }

        // GET: Admin/TBL_KHACHHANG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KHACHHANG tBL_KHACHHANG = db.TBL_KHACHHANG.Find(id);
            if (tBL_KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KHACHHANG);
        }

        // POST: Admin/TBL_KHACHHANG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_KHACHHANG,HO_TEN,DIA_CHI,DIEN_THOAI,EMAIL,NGAY_SINH,GIOI_TINH,NO_DAU_KY,SO_THE,NGAY_KICHHOAT,NGAY_HETHAN,SO_TIEN,TIEN_SU_DUNG_DV,DIEM_TICH_LUY,KICHHOAT_THE,GHI_CHU,NGUNG_HOATDONG,SO_CMND,MAT_KHAU")] TBL_KHACHHANG tBL_KHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_KHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_KHACHHANG);
        }

        // GET: Admin/TBL_KHACHHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KHACHHANG tBL_KHACHHANG = db.TBL_KHACHHANG.Find(id);
            if (tBL_KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KHACHHANG);
        }

        // POST: Admin/TBL_KHACHHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TBL_KHACHHANG tBL_KHACHHANG = db.TBL_KHACHHANG.Find(id);
            db.TBL_KHACHHANG.Remove(tBL_KHACHHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
