using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Client;
using PrismNavigationTest.RIA.Web;
using PrismNavigationTest.Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Commands;

namespace PrismNavigationTest.Modules
{
    public class OtherViewVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private IUnityContainer _unityContainer;
        private IEventAggregator _eventAggregator;

        private readonly DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand
        {
            get { return _navigateCommand; }
        }

        public OtherViewVM(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            _eventAggregator = _unityContainer.Resolve<IEventAggregator>();
            _navigateCommand = new DelegateCommand(NavigateBack, () => true);
        }

        private void NavigateBack()
        {
            _eventAggregator.GetEvent<ActivateView>().Publish(new ViewActivation { NavigateFrom = "OtherView", NavigateTo = "View1" });

        }
    }
}
