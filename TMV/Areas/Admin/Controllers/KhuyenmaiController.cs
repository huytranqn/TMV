using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMV.Areas.Admin.Controllers
{
    public class KhuyenmaiController : BaseController
    {
        // GET: Admin/Khuyenmai
        public ActionResult Index()
        {
            return View();
        }
    }
}