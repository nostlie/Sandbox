using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PrismNavigationTest.Infrastructure;


namespace PrismNavigationTest.Modules
{
    public class Modules : IModule
    {
        private readonly IUnityContainer _unityContainer;

        public Modules(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void Initialize()
        {
            RegisterInstances();
            RegisterViews();
            ResolveServices();
        }

        private void RegisterViews()
        {
            var registry = _unityContainer.Resolve<IRegionViewRegistry>();
            var navData = _unityContainer.Resolve<INavigationMetadata>();
            var views = GetViewsToRegister();
            foreach (var view in views)
            {
                navData.NamedViews.Add(view.ViewName, view);
                registry.RegisterViewWithRegion(view.RegionName, view.ViewType);    
            }
            
        }

        private void RegisterInstances()
        {
            foreach (var instanceToRegister in GetInstancesToRegister())
            {
                if (instanceToRegister.IsSingleton)
                {
                    _unityContainer.RegisterType(instanceToRegister.Interface, instanceToRegister.Implementation, new ContainerControlledLifetimeManager());
                }
                else
                {
                    _unityContainer.RegisterType(instanceToRegister.Interface, instanceToRegister.Implementation);
                }
            }
        }

        protected IEnumerable<InstanceToRegister> GetInstancesToRegister()
        {
            yield return new InstanceToRegister(typeof(IDomainContext1), typeof(DomainContext1), true);
        }

        private void ResolveServices()
        {
            foreach (var type in GetInterfacesToResolve())
            {
                _unityContainer.Resolve(type);
            }
        }

        protected IEnumerable<Type> GetInterfacesToResolve()
        {
            yield return typeof(IDomainContext1);
        }

        protected IEnumerable<ViewRegistration> GetViewsToRegister()
        {
            yield return new ViewRegistration(typeof(Module1.View1), "Main", "View1");
            yield return new ViewRegistration(typeof(Module2.OtherView), "Main", "OtherView");
        }
    }
}
