using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcUnitTest.Models
{
    public interface IBlahRepository
    {
        BlahModel GetBlah();
        IEnumerable<BlahModel> GetAllBlahs();
    }
}
