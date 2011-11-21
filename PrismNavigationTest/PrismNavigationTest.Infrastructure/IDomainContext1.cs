using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using PrismNavigationTest.RIA.Web;

namespace PrismNavigationTest.Infrastructure
{
    public interface IDomainContext1
    {
        
        Person[] Persons { get; set; }

        void GetPersons(Action onCompleted);
    }
}
