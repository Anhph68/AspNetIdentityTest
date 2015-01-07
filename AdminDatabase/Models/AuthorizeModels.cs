using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace AdminDatabase.Models
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        private TDKTEntities db = new TDKTEntities();

        //public override void On(AuthorizationContext filterContext)
        //{
        //    var allowedRoles = db.sp_getAllowedRoles(filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, 1).ToList();

        //    filterContext.Controller.ViewBag.AutherizationMessage = HttpContext.Current.User.Identity.Name;
        //    Debug.Write(filterContext);
        //    //filterContext.Controller.ViewBag.AutherizationMessage = "Custom Authorization: Message from OnAuthorization method.";
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var rd = httpContext.Request.RequestContext.RouteData;
            var allowedRoles = db.sp_getAllowedRoles(rd.GetRequiredString("action"), rd.GetRequiredString("controller"), 1).ToList();
            var currentRoles = db.sp_getRolesforUser(httpContext.User.Identity.GetUserId()).ToList();

            return currentRoles.Any(c => allowedRoles.Contains(c));

            //return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}