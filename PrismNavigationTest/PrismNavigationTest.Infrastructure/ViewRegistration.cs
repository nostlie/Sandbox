using System;
using System.Windows.Controls;


namespace PrismNavigationTest.Infrastructure
{
    public class ViewRegistration
    {
        public readonly Type ViewType;
        public readonly string RegionName;
        public readonly string ViewName;

        public ViewRegistration(Type viewType, string regionName, string viewName)
        {
            ViewType = viewType;
            RegionName = regionName;
            ViewName = viewName;
        }
    }
}
