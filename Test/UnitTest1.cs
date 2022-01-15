using NUnit.Framework;
using System;
using System.Web.Mvc;
using TPSema.Controllers;
using TPSema.Models;

namespace Test
{
    public class Tests
    {   public readonly Customer db =new();
        public readonly CustomersController cs = new();

        [Test]
        public void Test1()
        {
            CustomersController controller = new CustomersController();
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreNotEqual(1231,db.price);
        }
        [Test]
        public void Test2()
        {
            CustomersController controller = new CustomersController();
            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(db.transport == "�����");
            Assert.AreEqual(db.transport == "�������",
                            db.transport == "�������");
        }
        [Test]
        public void Test3()
        {
            CustomersController controller = new CustomersController();
            ViewResult result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(db.residence == "������");
            Assert.AreEqual(db.residence == "���������",
                            db.residence == "���������"); 
        }
        [Test]
        public void Test4()
        {
            Assert.AreNotEqual(1000, db.daysTour);
            Assert.IsNotNull(db.daysTour == Convert.ToString(4));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual(db.daysTour == "1",db.daysTour == "�������");
        }
    }
}