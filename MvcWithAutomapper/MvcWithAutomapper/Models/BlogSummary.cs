using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWithAutomapper.Models
{
    public class BlogSummary
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int AuthorAge { get; set; }
        public string AuthorBio { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; set; }
    }
  
}