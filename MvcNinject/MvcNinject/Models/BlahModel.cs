using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcNinject.Models
{
    public class BlahModel
    {
        /*         
         * The mapping of this Model to the ViewModel happens in the Action Filter called from the 
         *      Action Attribute of the controller method.
         * This Model is really a representation of the Domain Model, whether it's EF or a mapped 
         *      object from a web server, etc.
         */
        public int BlahId { get; set; }
        public string BlahMessage { get; set; }
        public string BlahAboutTitle { get; set; }
        public string BlahAboutBody { get; set; }
    }
}