using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MvcWithAutomapper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Blogs or something:";

            var blogs = new Models.Blog[]
            {
                new Models.Blog { Author = new Author { Age = 55, Bio = "Neat guy", HomeTown = "Minneapolis", Name = "Jerry Iatrics" }, Description = "Blog about health topics for the elderly.", Title = "Growing old" },
                new Models.Blog { Author = new Author { Age = 35, Bio = "Fun guy", HomeTown = "St. Paul", Name = "Peter Trician" }, Description = "Blog about avoiding injuries to your feet.", Title = "Happy Feet" },
                new Models.Blog { Author = new Author { Age = 22, HomeTown = "Blaine", Name = "Lyona Round" }, Description = "Blog about keeping sedentary.", Title = "Guide to a Lazy Life" }
            };

            Mapper.CreateMap<Models.Blog, Models.BlogSummary>()
                .AfterMap((src, dest) => dest.AuthorBio += "$")
                .ForMember(x => x.AuthorBio, opt => 
                                                {
                                                    opt.NullSubstitute("N/A");
                                                    opt.AddFormatter<BlogFormatter>();
                                                });

            var summaries = Mapper.Map<Models.Blog[], Models.BlogSummary[]>(blogs);

            return View(summaries);
        }

        public ActionResult About()
        {
            
            return View();
        }
    }

    public class BlogFormatter : IValueFormatter
    {

        public string FormatValue(ResolutionContext context)
        {
            string value = context.SourceValue.ToString();

            return value + "!";
        }
    }
}
