using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TPSema;
using TPSema.Controllers;

namespace TPSema.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            CustomersController controller = new CustomersController();
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.Equals(1, result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        private readonly TourDBEntities3 db = new TourDBEntities3();

        [TestMethod]
        public void TestMethod1()
        {

            CustomersController controller = new CustomersController();
            ViewResult result = controller.Index(db.Customer.ToList()) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            CustomersController controllers = new CustomersController();

            // Act

            ViewResult result = controllers.Details() as ViewResult;

            // Assert
            Assert.AreEqual(result);
        }
    }
}
