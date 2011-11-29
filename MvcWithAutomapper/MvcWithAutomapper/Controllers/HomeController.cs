using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;

namespace MvcWithAutomapper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Blogs or something:";

            //var blogs = new Models.BlogModel[]
            //{
            //    new Models.BlogModel { Author = new Author { Age = 55, Bio = "Neat guy", HomeTown = "Minneapolis", Name = "Jerry Iatrics" }, Description = "Blog about health topics for the elderly.", Title = "Growing old" },
            //    new Models.BlogModel { Author = new Author { Age = 35, Bio = "Fun guy", HomeTown = "St. Paul", Name = "Poe Diatry" }, Description = "Blog about avoiding injuries to your feet.", Title = "Happy Feet" },
            //    new Models.BlogModel { Author = new Author { Age = 22, HomeTown = "Blaine", Name = "Lyona Round" }, Description = "Blog about keeping sedentary.", Title = "Guide to a Lazy Life" }
            //};

            //var db = new Models.TestDBEntities();
            //var blogs = db.Blogs.ToArray();          

            Mapper.Reset();
            Mapper.CreateMap<IDataReader, Models.BlogSummary>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(r => r.GetString(r.GetOrdinal("Name"))))
                .ForMember(m => m.AuthorAge, opt => opt.MapFrom(r => r.GetInt32(r.GetOrdinal("Age"))))
                .ForMember(m => m.AuthorBio, opt => opt.MapFrom(r => r.GetString(r.GetOrdinal("Bio"))));
            
            IEnumerable<Models.BlogSummary> summaries = null;

            using (SqlConnection connection = new SqlConnection(@"server=.\SQLEXPRESS; DataBase=TestDB; Integrated Security=SSPI"))
            {
                var command = connection.CreateCommand();
                command.CommandText = "dbo.GetAllBlogs";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                summaries = Mapper.Map<IDataReader, IEnumerable<Models.BlogSummary>>(command.ExecuteReader());
            }
                                 
            //Mapper.CreateMap<Models.Blog, Models.BlogSummary>()
            //    .AfterMap((src, dest) => dest.AuthorBio += "$")
            //    .ForMember(x => x.AuthorBio, opt => 
            //                                    {
            //                                        opt.NullSubstitute("N/A");
            //                                        opt.AddFormatter<BlogFormatter>();
            //                                    });

            //var summaries = Mapper.Map<Models.Blog[], Models.BlogSummary[]>(blogs)

            return View(summaries.ToArray());
        }

        public ActionResult About()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Blogs()
        {
            Mapper.Reset();
            Mapper.CreateMap<IDataReader, Models.BlogModel>();
                
            IEnumerable<Models.BlogModel> blogs = null;

            using (SqlConnection connection = new SqlConnection(@"server=.\SQLEXPRESS; DataBase=TestDB; Integrated Security=SSPI"))
            {
                var command = connection.CreateCommand();
                command.CommandText = "dbo.GetBlogs";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                blogs = Mapper.Map<IDataReader, IEnumerable<Models.BlogModel>>(command.ExecuteReader());
            }           
            return View(blogs.ToArray());
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
