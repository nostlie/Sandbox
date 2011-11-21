using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Practices.Prism.Events;
using PrismNavigationTest.Infrastructure;

namespace PrismNavigationTest.Shell
{
    public partial class Shell : UserControl
    {
        private readonly ShellVM _viewModel;

        public Shell(ShellVM viewModel, IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ActivateView>().Subscribe(ActivateView, true);
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            
        }

        // After the Frame navigates, ensure the HyperlinkButton representing the current page is selected
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        public void ActivateView(ViewActivation view)
        {
            Application.Current.Host.NavigationState = string.Format("/{0}/", view.NavigateTo);
        }
    }
}
