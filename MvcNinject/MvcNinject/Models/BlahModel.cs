using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcNinject.Models
{
    public class BlahModel
    {
        /*
         * The Model can be used as a mapping destination from the data layer.
         * The mapping of this Model to the ViewModel would happen in the Controller
         */
        public int BlahId { get; set; }
        public string BlahMessage { get; set; }
        public string BlahAboutTitle { get; set; }
        public string BlahAboutBody { get; set; }
    }
}