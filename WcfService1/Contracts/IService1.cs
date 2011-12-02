using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfService1.Contracts
{
    [ServiceContract(Namespace = "WcfService1.Contracts")]
    public interface IService1 : IDisposable
    {
        [OperationContract]
        Blog[] GetBlogs();
        
    }
}
