using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PrismNavigationTest.Modules.Module1
{
    public partial class View1 : UserControl
    {
        private readonly View1VM _viewModel;

        public View1(View1VM viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
