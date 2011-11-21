using System;
using System.Linq;
using System.Threading;
using System.Windows.Navigation;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismNavigationTest.Infrastructure
{
    public class ViewRegistrationContentLoader : INavigationContentLoader
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;
        private readonly INavigationMetadata _navigationMetadata;

        public ViewRegistrationContentLoader(IRegionManager regionManager, IUnityContainer unityContainer, INavigationMetadata navigationMetadata)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
            _navigationMetadata = navigationMetadata;
        }

        public IAsyncResult BeginLoad(Uri targetUri, Uri currentUri, AsyncCallback userCallback, object asyncState)
        {
            var result = new PrismContentLoaderAsyncResult(asyncState);
            var viewRegistration = FindView(targetUri.ToString());
            
            result.Result = _regionManager.Regions
                                          .Where(r => r.Name.Equals("Main"))
                                          .First()
                                          .Views
                                          .Where(v => v.GetType().Equals(viewRegistration.ViewType))
                                          .First();
            userCallback(result);
            _unityContainer.Resolve<IEventAggregator>().GetEvent<NavigationEvent>().Publish(viewRegistration);
            return result;
        }

        private ViewRegistration FindView(string uriString)
        {
            string name = uriString;

            if (String.IsNullOrEmpty(name))
            {
                name = "View1";
            }
            return _navigationMetadata.NamedViews[name];
        }

        public bool CanLoad(Uri targetUri, Uri currentUri)
        {
            object t = FindView(targetUri.ToString());
            return t != null;
        }

        public void CancelLoad(IAsyncResult asyncResult)
        {
            return;
        }

        public LoadResult EndLoad(IAsyncResult asyncResult)
        {
            return new LoadResult(((PrismContentLoaderAsyncResult)asyncResult).Result);
        }

    }

    internal class PrismContentLoaderAsyncResult : IAsyncResult
    {
        public object Result { get; set; }

        public PrismContentLoaderAsyncResult(object asyncState)
        {
            AsyncState = asyncState;
            AsyncWaitHandle = new ManualResetEvent(true);
        }
        #region IAsyncResult Members

        public object AsyncState { get; private set; }

        public WaitHandle AsyncWaitHandle { get; private set; }

        public bool CompletedSynchronously
        {
            get
            {
                return true;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return true;
            }
        }
        #endregion

    }
}
