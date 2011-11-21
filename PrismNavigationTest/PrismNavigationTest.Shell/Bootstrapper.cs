using System.Windows;
using System.Windows.Navigation;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using PrismNavigationTest.Infrastructure;

namespace PrismNavigationTest.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = Container.Resolve<Shell>();
            Application.Current.RootVisual = shell;
            return shell;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(PrismNavigationTest.Modules.Modules));
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShell, ShellVM>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationMetadata, NavigationMetadata>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationContentLoader, ViewRegistrationContentLoader>();
        }
    }
}
