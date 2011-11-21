using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Client;
using PrismNavigationTest.RIA.Web;
using PrismNavigationTest.Infrastructure;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Commands;

namespace PrismNavigationTest.Modules
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private IUnityContainer _unityContainer;
        private IEventAggregator _eventAggregator;
        private IDomainContext1 _context;
        private DomainService1 _service;

        private readonly DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand
        {
            get { return _navigateCommand; }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }

        private Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                if (_person != value)
                {
                    _person = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Person"));
                    }
                }
            }
        }

        public ViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            _eventAggregator = _unityContainer.Resolve<IEventAggregator>();
            _navigateCommand = new DelegateCommand(NavigateAway, () => true);
            _context = new DomainContext1();
            _service = new DomainService1();
            LoadControls();
        }

        private void LoadControls()
        {
            _service.GetName(GetNameCompleted, null);
            _context.GetPersons(GetPersonsCompleted);
        }

        private void GetNameCompleted(InvokeOperation invOp)
        {
            if (!invOp.HasError)
            {
                Name = invOp.Value.ToString();
            }
        }

        private void GetPersonsCompleted()
        {
            Person = _context.Persons[0];
        }

        private void NavigateAway()
        {
            _eventAggregator.GetEvent<ActivateView>().Publish(new ViewActivation { NavigateFrom = "View", NavigateTo = "OtherView" });

        }

     
    }
}
