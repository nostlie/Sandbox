using MvcNinjectCars.Models;

namespace MvcNinjectCars.Repositories
{
    public interface ICarRepository
    {
        CarModel GetCar(int carId);
        CarModel[] GetCarsByManufacturer(int manufacturerId);
        CarModel[] GetAllCars();

    }
}
