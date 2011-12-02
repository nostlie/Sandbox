using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.ServiceModel;

using WcfService1.Contracts;

namespace WcfService1.Controllers
{
    public class Controller1 : IDisposable
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

        private static ChannelFactory<IService1> _channelFactory;

        public Blog[] GetBlogs()
        {
            
            var channel = _channelFactory.CreateChannel();
            return channel.GetBlogs();
        }
    }
}
