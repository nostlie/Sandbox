using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PrismNavigationTest.Modules
{
    public partial class View : UserControl
    {
        private readonly ViewModel _viewModel;

        public View(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
