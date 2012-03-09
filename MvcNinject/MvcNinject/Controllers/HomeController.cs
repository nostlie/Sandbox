using System.Collections.Generic;
using System.Web.Mvc;
using MvcNinject.Filters;
using MvcNinject.Mappers;
using MvcNinject.Models;
using MvcNinject.Models.Views;
using MvcNinject.Services;

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

        [AutoMap(typeof(IEnumerable<BlahModel>), typeof(IEnumerable<BlahAboutViewModel>))]
        public ActionResult About()
        {
            var model = Service.GetAllBlahs();
            return View(model);
        }

    }
}
