using muscshop.Context;
using muscshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace muscshop.filters
{
    public class AutorizeUserAttribute : AuthorizeAttribute
    {
        private readonly string[] allowRoles;

        public AutorizeUserAttribute(params string [] roles)
        {
            this.allowRoles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            var autorized = false;

            var user = (User)filterContext.HttpContext.Session["User"];

            if(user != null)
            {
                using (var _storeContext = new StoreContext())
                {
                    //var us = _storeContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();

                    var roleNames = user.Roles.Select(x => x.RoleName);
                    autorized = roleNames.Any(item => allowRoles.ToList().Contains(item));
                }
            }

            if(!autorized)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"Controller", "Account" },
                        {"Action", "Login" }
                    }

                );
            }
        }
    }
}