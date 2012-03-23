using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcNinjectCars.Attributes;
using MvcNinjectCars.Mappers;
using MvcNinjectCars.Models;
using MvcNinjectCars.Models.Views;
using MvcNinjectCars.Services;

namespace MvcNinjectCars.Controllers
{
    public class CarController : BaseController<ICarService>
    {
        private bool _carToggle = false;

        public CarController(ICarService carService, IMapper carMapper)
            : base(carService, carMapper)
        {
        }

        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public ActionResult Index(bool availableFlag, int carId = 0, int manufacturerId = 0)
        {
            CarModel[] model;
            if (manufacturerId == 0 && carId != 0)
            {
                model = new[] { Service.GetCar(carId) };
            }
            else if (carId == 0 && manufacturerId != 0)
            {
                model = Service.GetCarByManufacturer(manufacturerId);
            }
            else
            {
                model = Service.GetAllCars(availableFlag);
            }
            
            return View(model);
        }

        [AutoMap(typeof(CarModel), typeof(CarViewModel))]
        public PartialViewResult CarDetails()
        {
            CarModel car;
            if (_carToggle)
            {               
                car = Service.GetCar(1);
            }
            else
            {
                car = Service.GetCar(2);
            }
            _carToggle = !_carToggle;
            return PartialView("CarDetails", car);
        }

        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public PartialViewResult CarSearch(string q)
        {
            var cars = Service.GetAllCars(false).Where(c => c.Name.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) >= 0 || string.IsNullOrEmpty(q));
            return PartialView("CarSearchResults", cars);
        }

        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public ActionResult CarQuickSearch(string term)
        {
            var cars = Service.GetAllCars(false)
                .Where(c => c.Name.IndexOf(term, StringComparison.CurrentCultureIgnoreCase) >= 0 || string.IsNullOrEmpty(term))
                .Select(c => new { label = c.Name });
            return Json(cars, JsonRequestBehavior.AllowGet);
        }
    }
}
