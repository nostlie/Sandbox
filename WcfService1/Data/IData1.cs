using System;
using System.Collections.Generic;
using WcfService1.Contracts;

namespace WcfService1.Data
{
    public interface IData1
    {
        IList<Blog> GetBlogs();
    }
}
