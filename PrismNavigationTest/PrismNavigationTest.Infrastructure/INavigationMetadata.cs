using System.Collections.Generic;

namespace PrismNavigationTest.Infrastructure
{
    public interface INavigationMetadata
    {
        Dictionary<string, ViewRegistration> NamedViews { get; }
    }
}
