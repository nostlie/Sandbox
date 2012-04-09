using MvcNinjectCars.Models;

namespace MvcNinjectCars.Services
{
    public interface ICarService
    {
        CarModel GetCar(int carId);
        CarModel[] GetCarByManufacturer(int manufacturerId);
        CarModel[] GetAllCars(bool availableFlag);
    }
}
