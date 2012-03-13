using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNinject.Models;
using MvcNinject.Models.Views;
using Moq;
using MvcNinject.Controllers;
using MvcNinject.Filters;

namespace MvcNinject.Tests.Infrastructure
{
    [TestClass]
    public class MapperTest
    {
        private class Model1
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
            public string Property4 { get; set; }
        }

        private class Model2
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }

       // [TestMethod]
        public void AutoMapFilterTest()
        {
            var sourceModel = new Model1
            {
                Property1 = 1,
                Property2 = "Prop 2",
                Property3 = "Prop 3",
                Property4 = "Prop 4"
            };

            var destModel = new Model2
            {
                Property1 = 1,
                Property2 = "Prop 2"
            };

        }

        //[TestMethod]
        public void AutoMapAttributeTest()
        {
            var sourceModel = new Model1
            {
                Property1 = 1,
                Property2 = "Prop 2",
                Property3 = "Prop 3",
                Property4 = "Prop 4"
            };

            var destModel = new Model2
            {
                Property1 = 1,
                Property2 = "Prop 2"
            };


        }

        //[TestMethod]
        public void AutoMapAttributeTest_WithArrays()
        {
            var sourceModel = new[]
                {
                    new Model1
                    {
                        Property1 = 1,
                        Property2 = "Prop 2",
                        Property3 = "Prop 3",
                        Property4 = "Prop 4"
                    },
                    new Model1
                    {
                        Property1 = 2,
                        Property2 = "Prop 2",
                        Property3 = "Prop 3",
                        Property4 = "Prop 4"
                    }
                };

            var destModel = new[]
                {
                    new Model2
                    {
                        Property1 = 1,
                        Property2 = "Prop 2",
                    },
                    new Model2
                    {
                        Property1 = 2,
                        Property2 = "Prop 2",
                    }
                };

        }
    }
}
