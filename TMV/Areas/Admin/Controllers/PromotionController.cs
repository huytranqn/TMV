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
    public class PromotionController : BaseController
    {
        protected override bool DisableAsyncSupport => base.DisableAsyncSupport;
        #region ActionResult
        // GET: Admin/Promotion
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new PromotionDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);

        }
        //public static MvcHtmlString FixedTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        //{
        //    return new MvcHtmlString(htmlHelper.TextAreaFor(expression)
        //        .ToHtmlString()
        //        .Replace(">&#13;&#10;", ">" + Environment.NewLine));
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Promotion model)
        {
            if (ModelState.IsValid)
            {
                if (PromotionDao.Instance.insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại!");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = PromotionDao.Instance.getByID(id);
            return View(product);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Promotion model)
        {
            if (ModelState.IsValid)
            {
                if (PromotionDao.Instance.Update(model))
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
        public JsonResult ChangeStatus(int id)
        {
            bool result = false;
            try
            {
                result = PromotionDao.Instance.changeStatus(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var result = PromotionDao.Instance.delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override void Execute(RequestContext requestContext)
        {
            base.Execute(requestContext);
        }

        protected override ContentResult Content(string content, string contentType, Encoding contentEncoding)
        {
            return base.Content(content, contentType, contentEncoding);
        }

        protected override IActionInvoker CreateActionInvoker()
        {
            return base.CreateActionInvoker();
        }

        protected override ITempDataProvider CreateTempDataProvider()
        {
            return base.CreateTempDataProvider();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }

        protected override FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName)
        {
            return base.File(fileContents, contentType, fileDownloadName);
        }

        protected override FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName)
        {
            return base.File(fileStream, contentType, fileDownloadName);
        }

        protected override FilePathResult File(string fileName, string contentType, string fileDownloadName)
        {
            return base.File(fileName, contentType, fileDownloadName);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            base.HandleUnknownAction(actionName);
        }

        protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        {
            return base.HttpNotFound(statusDescription);
        }

        protected override JavaScriptResult JavaScript(string script)
        {
            return base.JavaScript(script);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return base.Json(data, contentType, contentEncoding);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, behavior);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            base.OnAuthenticationChallenge(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override PartialViewResult PartialView(string viewName, object model)
        {
            return base.PartialView(viewName, model);
        }

        protected override RedirectResult Redirect(string url)
        {
            return base.Redirect(url);
        }

        protected override RedirectResult RedirectPermanent(string url)
        {
            return base.RedirectPermanent(url);
        }

        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }

        protected override RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return base.RedirectToActionPermanent(actionName, controllerName, routeValues);
        }

        protected override RedirectToRouteResult RedirectToRoute(string routeName, RouteValueDictionary routeValues)
        {
            return base.RedirectToRoute(routeName, routeValues);
        }

        protected override RedirectToRouteResult RedirectToRoutePermanent(string routeName, RouteValueDictionary routeValues)
        {
            return base.RedirectToRoutePermanent(routeName, routeValues);
        }

        protected override ViewResult View(string viewName, string masterName, object model)
        {
            return base.View(viewName, masterName, model);
        }

        protected override ViewResult View(IView view, object model)
        {
            return base.View(view, model);
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            return base.BeginExecuteCore(callback, state);
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);
        }

        protected override void EndExecuteCore(IAsyncResult asyncResult)
        {
            base.EndExecuteCore(asyncResult);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }


        #endregion
    }
}