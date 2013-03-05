using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutWebAPI_Pianos.Models
{
    public class PianoModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string SpecialFeature { get; set; }
    }

    public class ManufacturerModel
    {
        public IList<PianoModel> Pianos { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Person Founder { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthYear { get; set; }
        public string BirthLocation { get; set; }
        public string TimePeriod { get; set; }
        public string Biography { get; set; }
    }
}