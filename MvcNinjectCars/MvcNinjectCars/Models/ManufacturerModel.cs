using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcNinjectCars.Models
{
    /*
     * This model could be replaced by EntityFramework objects
     *      or any other data access framework. Here it is being 
     *      instantiated in the CarRepository class for demo purposes.
     */
    public class ManufacturerModel
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}