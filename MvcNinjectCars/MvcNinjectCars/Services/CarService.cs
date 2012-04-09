using System.Linq;
using MvcNinjectCars.Models;
using MvcNinjectCars.Repositories;

namespace MvcNinjectCars.Services
{
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