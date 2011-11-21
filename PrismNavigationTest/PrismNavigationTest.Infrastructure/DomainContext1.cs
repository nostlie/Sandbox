using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using PrismNavigationTest.RIA.Web;

namespace PrismNavigationTest.Infrastructure
{
    public class DomainContext1 : IDomainContext1
    {
        private DomainService1 _domainServiceContext;

        public Person[] Persons
        {
            get;
            set;
        }

        public DomainContext1()
        {
            _domainServiceContext = new DomainService1();
        }    

        public void GetPersons(Action onCompleted)
        {
            _domainServiceContext.Persons.Clear();
            var query = _domainServiceContext.GetPersonQuery();
            _domainServiceContext.Load(query, i => GetPersonsLoaded(i, onCompleted), "GetPersons");
        }

        private void GetPersonsLoaded(LoadOperation<Person> lo, Action onCompleted)
        {
            if (!lo.HasError)
            {
                if (onCompleted != null)
                {
                    Persons = _domainServiceContext.Persons.ToArray();
                    onCompleted();
                }
            }
        }
    }
}
