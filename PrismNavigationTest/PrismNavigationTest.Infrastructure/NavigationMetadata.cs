using System.Collections.Generic;

namespace PrismNavigationTest.Infrastructure
{
    public class NavigationMetadata :  INavigationMetadata
    {
        private readonly Dictionary<string, ViewRegistration> _namedViews = new Dictionary<string, ViewRegistration>();

        public Dictionary<string, ViewRegistration> NamedViews
        {
            get
            {
                return _namedViews;
            }
        }
    }
}
