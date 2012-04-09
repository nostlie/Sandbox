using System;
using System.Configuration;
using System.ServiceModel;

using WcfService1.Contracts;

namespace WcfService1.Controllers
{
    public class Controller1 : ClientBase<IService1>, IDisposable
    {
        #region IDisposable implementation
        ~Controller1()
        {
            Dispose(false);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        } 
        #endregion

        public Controller1()
        {
            _channelFactory = new ChannelFactory<IService1>("Service1-Address",
                new EndpointAddress(ConfigurationManager.AppSettings["ServiceAddress"]));
        }

        private static ChannelFactory<IService1> _channelFactory;

        public Blog[] GetBlogs()
        {
            Blog[] response;
            using (var channel = _channelFactory.CreateChannel())
            {
                response = channel.GetBlogs();
            }
            return response;
        }
    }
}
