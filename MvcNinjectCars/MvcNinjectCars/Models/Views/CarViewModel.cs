using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcNinjectCars.Models.Views
{
    public class CarViewModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string ManufacturerName { get; set; }
        public decimal Price { get; set; }
    }
}