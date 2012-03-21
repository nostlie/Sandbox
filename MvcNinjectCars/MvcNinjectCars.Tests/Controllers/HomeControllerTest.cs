using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNinjectCars;
using MvcNinjectCars.Controllers;
using MvcNinjectCars.Models;
using Moq;
using MvcNinjectCars.Services;
using MvcNinjectCars.Models.Views;

namespace MvcNinjectCars.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_GetCar()
        {
            var expectedResult = new[]
                {
                    new CarModel
                    {
                        CarId = 1,
                        Name = "Foo",
                        Color = "FooColor",
                        Price = 11111,
                        InventoryCount = 1,
                        Manufacturer = new ManufacturerModel
                        {
                            ManufacturerId = 1,
                            Country = "FooCountry",
                            Name = "FooManu"
                        }
                    }
                };
            var mockService = new Mock<ICarService>(MockBehavior.Strict);
            mockService.Setup(s => s.GetCar(expectedResult[0].CarId)).Returns(expectedResult[0]);

            var mockMapper = new Mock<Mappers.IMapper>(MockBehavior.Strict);
            mockMapper.Setup(m => m.Map(expectedResult, typeof(IEnumerable<CarModel>), typeof(IEnumerable<CarViewModel>)));

            var controller = new CarController(mockService.Object, mockMapper.Object);
            var result = controller.Index(false, expectedResult[0].CarId) as ViewResult;
            var model = result.Model as CarModel[];

            Assert.IsNotNull(model);
            mockService.Verify(foo => foo.GetCar(expectedResult[0].CarId));
        }

        
    }
}
