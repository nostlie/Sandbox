using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcSecurity.Filters;

namespace MvcSecurity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Need a custom Authorize filter so the Login/Register methods of the AccountController 
            // can be accessed while not logged in. Every action/controller not labled with the AllowAnonymous attribute
            // in the application now has Authorize attribute protection.
            // Good to Know: if new methods are added to AccountController or the name of the
            // AccountController is changed, they won't be protected.
            filters.Add(new LoginAuthorize());

            // The RequireHttpsAttribute should be applied globally to avoid transmitting cookie in cleartext
            // I used a self-signed cert for localhost testing (http://blogs.iis.net/thomad/archive/2010/04/16/setting-up-ssl-made-easy.aspx)
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new HandleErrorAttribute());
        }

        // Do not use Route Contraints to implement security
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}