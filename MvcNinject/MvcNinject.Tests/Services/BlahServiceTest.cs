using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNinject.Models;
using MvcNinject.Repositories;
using Moq;
using MvcNinject.Services;

namespace MvcNinject.Tests.Services
{
    [TestClass]
    public class BlahServiceTest
    {
        [TestMethod]
        public void GetBlahTest_True()
        {
            var expectedResult = new BlahModel
                {
                    BlahId = 1,
                    BlahMessage = "Blah1",
                    BlahAboutTitle = "Blah1 About",
                    BlahAboutBody = "Blah1 About body"
                };

            var mockRepo = new Mock<IBlahRepository>(MockBehavior.Strict);
            mockRepo.Setup(r => r.GetBlahTrue()).Returns(expectedResult);

            var service = new BlahService(mockRepo.Object);
            var result = service.GetBlah(true);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetBlahTest_False()
        {
            var expectedResult = new BlahModel
            {
                BlahId = 1,
                BlahMessage = "Blah1",
                BlahAboutTitle = "Blah1 About",
                BlahAboutBody = "Blah1 About body"
            };

            var mockRepo = new Mock<IBlahRepository>(MockBehavior.Strict);
            mockRepo.Setup(r => r.GetBlahFalse()).Returns(expectedResult);

            var service = new BlahService(mockRepo.Object);
            var result = service.GetBlah(false);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetAllBlahsTest()
        {
            var expectedResult = new[]
                {
                    new BlahModel
                    {
                        BlahId = 1,
                        BlahMessage = "Blah1",
                        BlahAboutTitle = "Blah1 About",
                        BlahAboutBody = "Blah1 About body"
                    },
                    new BlahModel
                    {
                        BlahId = 2,
                        BlahMessage = "Blah2",
                        BlahAboutTitle = "Blah2 About",
                        BlahAboutBody = "Blah2 About body"
                    }
                };

            var mockRepo = new Mock<IBlahRepository>(MockBehavior.Strict);
            mockRepo.Setup(r => r.GetAllBlahs()).Returns(expectedResult);

            var service = new BlahService(mockRepo.Object);
            var result = service.GetAllBlahs();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
