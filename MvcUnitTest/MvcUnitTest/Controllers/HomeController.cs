using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUnitTest.Models;

namespace MvcUnitTest.Controllers
{
    public class HomeController : Controller
    {
        private Models.IBlahRepository _blahRepository;

        public HomeController()
            : this(new BlahRepository())
        {
        }

        public HomeController(Models.IBlahRepository blahRepository)
        {
            _blahRepository = blahRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag message";

            return View();
        }

        public ActionResult About()
        {
            var blah = _blahRepository.GetBlah();
            var blahs = _blahRepository.GetAllBlahs();
            return View(blah);
        }
    }
}
