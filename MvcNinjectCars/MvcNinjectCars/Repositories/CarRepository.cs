using System;
using System.Linq;
using MvcNinjectCars.Models;

namespace MvcNinjectCars.Repositories
{
    /*
     * These Repository methods would normally make a DAL call, to EF, SQL Server, etc.
     *      These values are hard-coded for demo purposes.
     */ 
    public class CarRepository : ICarRepository
    {
        public CarModel GetCar(int carId)
        {
            return CarData.Where(c => c.CarId == carId).First();
        }

        public CarModel[] GetCarsByManufacturer(int manufacturerId)
        {
            return CarData.Where(c => c.Manufacturer.ManufacturerId == manufacturerId).ToArray();
        }

        public CarModel[] GetAllCars()
        {
            return CarData;
        }

        // This data is for demo purposes
        private CarModel[] CarData
        {
            get
            {
                return new[] 
                {
                    new CarModel
                    {
                        CarId = 1,
                        Name = "Camry",
                        Color = "Metallic Gray",
                        Price = 25000,
                        Manufacturer = new ManufacturerModel
                        {
                            ManufacturerId = 1,
                            Name = "Toyota",
                            Country = "Japan"
                        },
                        InventoryCount = 3
                    },
                    new CarModel
                    {
                        CarId = 2,
                        Name = "Prius",
                        Color = "Black",
                        Price = 23499,
                        Manufacturer = new ManufacturerModel
                        {
                            ManufacturerId = 1,
                            Name = "Toyota",
                            Country = "Japan"
                        },
                        InventoryCount = 0
                    },
                    new CarModel
                    {
                        CarId = 3,
                        Name = "Fusion",
                        Color = "Blue",
                        Price = 19250,
                        Manufacturer = new ManufacturerModel
                        {
                            ManufacturerId = 2,
                            Name = "Ford",
                            Country = "USA"
                        },
                        InventoryCount = 1
                    }
                };
            }
        } 
    }
}