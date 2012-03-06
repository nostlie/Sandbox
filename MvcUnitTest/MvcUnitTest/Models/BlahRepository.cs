using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUnitTest.Models
{
    public class BlahRepository : IBlahRepository
    {
        public BlahModel GetBlah()
        {
            // Normal call to data source goes here
            return new BlahModel { Message = "Blah!", MessageId = 1 };
        }

        public IEnumerable<BlahModel> GetAllBlahs()
        {
            // Normal call to data source goes here
            return new[] { 
                new BlahModel { MessageId = 1, Message = "Blah!" }, 
                new BlahModel { MessageId = 2, Message = "Blah2!" } 
            };
        }
    }
}