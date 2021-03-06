using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using System.Web.Routing;

namespace GiveAid.Security
{
    public class FormAuthenticationAttribute : AuthorizeAttribute
    {
        public string RoleId { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }
            if (string.IsNullOrEmpty(RoleId))
            {
                return true;
            }
            else
            {
                string Email = httpContext.User.Identity.Name;
                db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
                var userTypeId = db.tbl_User.FirstOrDefault(x => x.Email == Email).FK_UserType;
                if (RoleId.Contains(userTypeId.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Handel Unauthorize Request
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //unauthoriza page
                RouteValueDictionary route = new RouteValueDictionary(
                    new
                    {
                        area="",
                        controller="Error",
                        action="Unauthorize"
                    }
                    );

                filterContext.Result = new RedirectToRouteResult(route);
            }
            else
            {
                //redirect to login
                base.HandleUnauthorizedRequest(filterContext);
            }
        }


    }
}