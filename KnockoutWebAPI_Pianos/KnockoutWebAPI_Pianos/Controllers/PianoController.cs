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
        public IEnumerable<string> Get()
        {
            var file = HttpContext.Current.Server.MapPath("/PianoData/pianos.json");

            return new string[] { "value1", "value2" };
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
