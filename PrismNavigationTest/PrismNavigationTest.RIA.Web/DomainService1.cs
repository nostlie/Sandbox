using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;

namespace PrismNavigationTest.RIA.Web
{
    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DomainService1 : DomainService
    {
        [Invoke]
        public string GetName()
        {
            return "Charlie";
        }

        [Query]
        public Person[] GetPerson()
        {
            return new Person[] { new Person { Id = 1, Name = "Charlie", Age = 22, BirthDate = DateTime.Parse("1/1/1989") } };
        }
    }
}


