using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WcfService1.Contracts;
using WcfService1.Data;

namespace WcfService1.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        private IData1 _data;

        public Service1()
        {
            _data = new Data1();
        }

        public Blog[] GetBlogs()
        {
            var blogs = _data.GetBlogs();
            return blogs.ToArray();
        }

        public void Dispose()
        {
        }
    }
}
