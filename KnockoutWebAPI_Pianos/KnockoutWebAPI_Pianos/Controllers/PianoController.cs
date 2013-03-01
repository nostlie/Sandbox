using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace KnockoutWebAPI_Pianos.Controllers
{
    public class PianoController : ApiController
    {
        // GET api/piano
        public IEnumerable<object> Get()
        {
            //var file = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/PianoData/pianos.json"));

            var pianos = new[] {
                new { Id = 1, ManufacturerName = "Steinway", PianoName = "Model D Concert Grand" },
                new { Id = 2, ManufacturerName = "Kawai", PianoName = "EX Concert Grand" }
            };

            return pianos;
        }

        // GET api/piano/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/piano
        public void Post([FromBody]string value)
        {
        }

        // PUT api/piano/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/piano/5
        public void Delete(int id)
        {
        }
    }
}
