using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;
using ADO = MvcWithAutomapper.Models.ADO;
using LinqToSql = MvcWithAutomapper.Models.LinqToSql;

namespace MvcWithAutomapper.Controllers
{
    public class HomeController : Controller
    {
        //// ADO.NET Entity Framework classes
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Blogs or something:";
        //    var db = new ADO.TestDBEntities();
        //    var blogs = db.Blogs.ToArray();
        //    Mapper.CreateMap<ADO.Blog, Models.BlogSummary>()
        //        .AfterMap((src, dest) => dest.AuthorBio += "$")
        //        .ForMember(x => x.AuthorBio, opt =>
        //                                        {
        //                                            opt.NullSubstitute("N/A");
        //                                            opt.AddFormatter<BlogFormatter>();
        //                                        });

        //    var summaries = Mapper.Map<ADO.Blog[], Models.BlogSummary[]>(blogs);

        //    return View(summaries.ToArray());
        //}

        //// Used SqlConnections
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Blogs or something:";

        //    Mapper.Reset();
        //    Mapper.CreateMap<IDataReader, Models.BlogSummary>()
        //        .ForMember(m => m.AuthorName, opt => opt.MapFrom(r => r.GetString(r.GetOrdinal("Name"))))
        //        .ForMember(m => m.AuthorAge, opt => opt.MapFrom(r => r.GetInt32(r.GetOrdinal("Age"))))
        //        .ForMember(m => m.AuthorBio, opt => opt.MapFrom(r => r.GetString(r.GetOrdinal("Bio"))));

        //    IEnumerable<Models.BlogSummary> summaries = null;

        //    using (SqlConnection connection = new SqlConnection(@"server=.\SQLEXPRESS; DataBase=TestDB; Integrated Security=SSPI"))
        //    {
        //        var command = connection.CreateCommand();
        //        command.CommandText = "dbo.GetAllBlogs";
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        connection.Open();
        //        summaries = Mapper.Map<IDataReader, IEnumerable<Models.BlogSummary>>(command.ExecuteReader());
        //    }


        //    return View(summaries.ToArray());
        //}

        // Used LINQ to SQL implementation
        public ActionResult Index()
        {
            LinqToSql.TestDBLinqToSqlDataContext db = new LinqToSql.TestDBLinqToSqlDataContext();

            Mapper.Reset();
            Mapper.CreateMap<LinqToSql.Blog, Models.BlogSummary>();
                //.ForMember(m => m.AuthorName, opt => opt.MapFrom(r => r.Name))
                //.ForMember(m => m.AuthorBio, opt => opt.MapFrom(r => r.Bio))
                //.ForMember(m => m.AuthorAge, opt => opt.MapFrom(r => r.Age))
                //.ForMember(m => m.AuthorHometown, opt => opt.MapFrom(r => r.Hometown));

            //var query = db.GetAllBlogs().ToArray();            

            var query = (from b in db.Blogs select b).ToArray();

            var summaries = Mapper.Map<LinqToSql.Blog[], Models.BlogSummary[]>(query);

            return View(summaries);
        }

        public ActionResult About()
        {            

            return View();
        }

        public ActionResult CreateBlog()
        {

            Models.BlogSummary summary = new Models.BlogSummary();

            return View(summary);
        } 

        [HttpPost]
        public ActionResult CreateBlog(Models.BlogSummary summary)
        {
            //object blogIdResult = null;
            //using (SqlConnection connection = new SqlConnection(@"server=.\SQLEXPRESS; DataBase=TestDB; Integrated Security=SSPI"))
            //{
            //    var command = connection.CreateCommand();
            //    command.CommandText = "dbo.InsertBlog";
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.Add(new SqlParameter("@Title", summary.Title));
            //    command.Parameters.Add(new SqlParameter("@Description", summary.Title));
            //    command.Parameters.Add(new SqlParameter("@AuthorName", summary.AuthorName));
            //    command.Parameters.Add(new SqlParameter("@AuthorBio", summary.AuthorBio));
            //    command.Parameters.Add(new SqlParameter("@AuthorAge", summary.AuthorAge));
            //    command.Parameters.Add(new SqlParameter("@AuthorHometown", summary.AuthorHometown));               
            //    connection.Open();
            //    blogIdResult = command.ExecuteScalar();
            //}
            //summary.BlogId = (int)(decimal)blogIdResult;

            var db = new ADO.TestDBEntities();

            ADO.Blog blog = new ADO.Blog { Title = summary.Title, Description = summary.Description };
            ADO.Author author = new ADO.Author { Name = summary.AuthorName, Bio = summary.AuthorBio, Hometown = summary.AuthorHometown, Age = summary.AuthorAge };
            db.AddToBlogs(blog);
            db.AddToAuthors(author);
            var result = db.SaveChanges();

            summary.BlogId = blog.BlogId;
            summary.AuthorId = author.AuthorId;

            return View(new Models.BlogSummary(summary));
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
