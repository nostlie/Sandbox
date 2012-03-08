using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcNinject.Models.Views
{
    public class BlahIndexViewModel
    {
        /*
         * View Models are tied 1-1 to a stongly-typed View
         * Never pass a Domain Model entity straight into View,
         *  since most of the time we only use a portion of the data
         */
        public int BlahId { get; set; }
        public string BlahMessage { get; set; }
    }
}