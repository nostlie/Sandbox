using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcUnitTest;
using MvcUnitTest.Controllers;
using MvcUnitTest.Models;
using Moq;


namespace MvcUnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var repoMock = new Mock<IBlahRepository>();

            var controller = new HomeController(repoMock.Object);
            var result = (ViewResult)controller.Index();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewBag.Message, "ViewBag message");
        }

        [TestMethod]
        public void AboutTest()
        {
            var repoMock = new Mock<IBlahRepository>();
            repoMock.Setup(x => x.GetBlah()).Returns(new BlahModel { Message = "Blah!", MessageId = 1 });
            //repoMock.Setup(x => x.GetAllBlahs()).Returns(new[] 
            //    {
            //        new BlahModel { Message = "Blah!", MessageId = 1 }, 
            //        new BlahModel { Message = "Blah2!", MessageId = 2 }
            //    });

            var controller = new HomeController(repoMock.Object);
            var result = (ViewResult)controller.About();
            var model = (BlahModel)result.ViewData.Model;
            //var model = (BlahModel[])result.ViewData.Model;

            Assert.IsNotNull(model);
            Assert.AreEqual("Blah!", model.Message);
            //Assert.IsNotNull(model[0]);
            //Assert.AreEqual("Blah!", model[0].Message);
        }
    }
}
