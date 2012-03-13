using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcNinject.Controllers;
using MvcNinject.Models;
using MvcNinject.Services;
using MvcNinject.Models.Views;

namespace MvcNinject.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var expectedResult = new BlahModel
                {
                    BlahId = 1,
                    BlahMessage = "blah1",
                    BlahAboutBody = "This is the body",
                    BlahAboutTitle = "About Me"
                };
            var mockService = new Mock<IBlahService>(MockBehavior.Strict);
            mockService.Setup(s => s.GetBlah(true)).Returns(expectedResult);

            var mockMapper = new Mock<Mappers.IMapper>(MockBehavior.Strict);
            mockMapper.Setup(m => m.Map(expectedResult, typeof(BlahModel), typeof(BlahIndexViewModel)));

            var controller = new HomeController(mockService.Object, mockMapper.Object);
            var result = controller.Index() as ViewResult;
            var model = result.Model as BlahModel;

            Assert.IsNotNull(model);
            Assert.AreEqual(expectedResult.BlahId, model.BlahId);
            Assert.AreEqual(expectedResult.BlahMessage, model.BlahMessage);
        }

        [TestMethod]
        public void About()
        {
            var expectedResult = new[] 
            {
                new BlahModel
                {
                    BlahId = 1,
                    BlahMessage = "blah1",
                    BlahAboutBody = "This is the body1",
                    BlahAboutTitle = "About Me1"
                },
                new BlahModel
                {
                    BlahId = 2,
                    BlahMessage = "blah2",
                    BlahAboutBody = "This is the body2",
                    BlahAboutTitle = "About Me2"
                }
            };
            var mockService = new Mock<IBlahService>(MockBehavior.Strict);
            mockService.Setup(s => s.GetAllBlahs()).Returns(expectedResult);

            var mockMapper = new Mock<Mappers.IMapper>(MockBehavior.Strict);
            mockMapper.Setup(m => m.Map(expectedResult, typeof(IEnumerable<BlahModel>), typeof(IEnumerable<BlahIndexViewModel>)));

            var controller = new HomeController(mockService.Object, mockMapper.Object);
            var result = controller.About() as ViewResult;
            var model = result.Model as IEnumerable<BlahModel>;

            Assert.IsNotNull(model);
            Assert.AreEqual(expectedResult.First().BlahAboutTitle, model.First().BlahAboutTitle);
            Assert.AreEqual(expectedResult.First().BlahAboutBody, model.First().BlahAboutBody);
            Assert.AreEqual(expectedResult.Last().BlahAboutTitle, model.Last().BlahAboutTitle);
            Assert.AreEqual(expectedResult.Last().BlahAboutBody, model.Last().BlahAboutBody);
        }
    }
}
