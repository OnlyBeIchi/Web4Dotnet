using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web4dotnet.Helper
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Không kiểm tra quyền vì bộ lọc AllowAnonymous được áp dụng cho hành động hoặc controller
                return;
            }

            // Kiểm tra quyền
            if (System.Web.HttpContext.Current.Session["TenDangNhap"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}