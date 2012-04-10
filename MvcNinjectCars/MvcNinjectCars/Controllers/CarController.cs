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

        /*
         * Constructor takes injected service and mapper interfaces and calls base constructor,
         *  which also has the Service and ModelMapper properties
         */
        public CarController(ICarService carService, IMapper carMapper)
            : base(carService, carMapper)
        {
        }

        /* 
         * There is a one-to-one relationship between ViewModels and Views. To maintain this
         *      and to only include necessary properties, map the result of the service call
         *      to a view model.
         * The AutoMap attribute is a custom attribute that sets the Source and Destination
         *      Type properties then calls OnActionExecuted of the AutoMapFilter action filter
         *      The AutoMapFilter takes the filterContext's instance of Controller, finds its
         *      ModelMapper property, and performs the mapping.
         * AutoMapper also knows how to map CarModel.ManufacturerModel.Name to CarViewModel.ManufacturerName
         * The Index view is strongly typed to IEnumerable<CarViewModel>.     
         */
        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public ActionResult Index(bool availableFlag, int carId = 0, int manufacturerId = 0)
        {
            CarModel[] model;

            // This is just some logic to demonstrate different scenarios.
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

        // The CarDetails action returns a PartialView to display car details
        // Created this to show Ajax.ActionLink functionality
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

        /* 
         * The CarSearch action returns a partial view that shows the details of a list of cars
         * This was created to show how to implement a search box using Ajax.BeginForm functionality
         */
        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public PartialViewResult CarSearch(string q)
        {
            var cars = Service.GetAllCars(false).Where(c => c.Name.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) >= 0 || string.IsNullOrEmpty(q));
            return PartialView("CarSearchResults", cars);
        }

        // The CarQuickSearch action was created to demo jQuery's autocomplete method
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
