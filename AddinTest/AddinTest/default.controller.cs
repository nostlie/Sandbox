using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.ServiceModel;
using CON = [contractusing]

namespace [namespace]
{
    public class [controllername] : IDisposable
    {
        #region IDisposable implementation
        ~[controllername]()
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
        
        private static ChannelFactory<CON.[contractname]> _channelFactory;
    }
}
