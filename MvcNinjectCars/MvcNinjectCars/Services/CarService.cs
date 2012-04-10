using System.Linq;
using MvcNinjectCars.Models;
using MvcNinjectCars.Repositories;

namespace MvcNinjectCars.Services
{
    /*
     * The Service layer is meant to be where any business logic or other
     *      manipulation of data (outside of object mapping) takes place. 
     * This layer keeps the Controller and Repository layers relatively clean
     *      and allows for easier unit testing.
     */
    public class CarService : ICarService
    {
        ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public CarService()
            : this(new CarRepository())
        {
        }

        public CarModel GetCar(int carId)
        {
            return _repository.GetCar(carId);
        }

        public CarModel[] GetCarByManufacturer(int manufacturerId)
        {
            return _repository.GetCarsByManufacturer(manufacturerId);
        }

        public CarModel[] GetAllCars(bool availableFlag)
        {
            if (availableFlag)
            {
                return _repository.GetAllCars().Where(c => c.InventoryCount > 0).ToArray();
            }
            return _repository.GetAllCars();
        }
    }
}