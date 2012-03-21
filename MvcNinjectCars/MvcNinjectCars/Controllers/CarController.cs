using System.Collections.Generic;
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
        public CarController(ICarService carService, IMapper carMapper)
            : base(carService, carMapper)
        {
        }

        [AutoMap(typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>))]
        public ActionResult Index(bool availableFlag, int carId = 0, int manufacturerId = 0)
        {
            CarModel[] model;
            if (manufacturerId == 0)
            {
                model = new[] { Service.GetCar(carId) };
            }
            else if (carId == 0)
            {
                model = Service.GetCarByManufacturer(manufacturerId);
            }
            else
            {
                model = Service.GetAllCars(availableFlag);
            }
            
            return View(model);
        }
    }
}
