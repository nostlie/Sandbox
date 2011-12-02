using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SVC = WcfService1.Services;
using CON = WcfService1.Contracts;
using DAL = WcfService1.Data;

namespace UnitTests
{
    [TestClass]
    public class Service1Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new SVC.Service1();
            var result = service.GetBlogs();
        }
    }
}
