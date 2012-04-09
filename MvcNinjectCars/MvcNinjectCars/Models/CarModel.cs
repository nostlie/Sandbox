
namespace MvcNinjectCars.Models
{
    public class CarModel
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int InventoryCount { get; set; }
    }
}