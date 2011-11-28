using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWithAutomapper.Models
{
    public class Blog
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
    }
}