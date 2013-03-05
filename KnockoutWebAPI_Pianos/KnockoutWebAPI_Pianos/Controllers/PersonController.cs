using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockoutWebAPI_Pianos.Controllers
{
    public class PersonController : ApiController
    {
        // GET api/person
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/person
        public void Post([FromBody]string value)
        {
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
        }
    }
}
