using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNinject.Filters;
using MvcNinject.Models;
using MvcNinject.Models.Views;
using MvcNinject.Services;
using MvcNinject.Mappers;

namespace MvcNinject.Controllers
{
    public class HomeController : BaseController<IBlahService>
    {
        public HomeController(IBlahService blahService, IMapper blahMapper)
            :base(blahService, blahMapper)
        {
        }

        [AutoMap(typeof(BlahModel), typeof(BlahIndexViewModel))]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            bool someParameter = true;
            return View(Service.GetBlah(someParameter));
        }

        [AutoMapArray(typeof(IEnumerable<BlahModel>), typeof(IEnumerable<BlahAboutViewModel>))]
        public ActionResult About()
        {
            var model = Service.GetAllBlahs();
            return View(model);
        }

    }
}
