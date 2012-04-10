
namespace MvcNinjectCars.Models
{
    /*
     * This model could be replaced by EntityFramework objects
     *      or any other data access framework. Here it is being 
     *      instantiated in the CarRepository class for demo purposes.
     */
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