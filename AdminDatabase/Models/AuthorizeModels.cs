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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var rd = httpContext.Request.RequestContext.RouteData;
            var allowedRoles = db.sp_getAllowedRoles(rd.GetRequiredString("action"), rd.GetRequiredString("controller"), 1).ToList();
            var currentRoles = db.sp_getRolesforUser(httpContext.User.Identity.GetUserId()).ToList();

            return currentRoles.Any(r => allowedRoles.Contains(r));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}