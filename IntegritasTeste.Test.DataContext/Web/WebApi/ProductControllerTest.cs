using System;
using System.Collections.Generic;
using System.Linq;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Assert = NUnit.Framework.Assert;

namespace IntegritasTeste.Test.DataContext.Controller.WebApi
{
     [TestFixture]
    public class ProductControllerTest
     {

         private IProductApplication ProductApplication;
         private ProductController ProductController;
         private Product product = new Product();
         [SetUp]
         protected virtual void SetUp()
         {
             ProductApplication = MockRepository.GenerateMock<IProductApplication>();
             product = new Product()
             {
                 Name = "Banana",
                 Prices = new List<Price>()
                 {
                     new Price()
                     {
                         Value = 1M
                     }
                 }
             };
             #region Stub Methods
             ProductApplication.Stub(x => x.Get(1)).Return(product);
             ProductApplication.Stub(x => x.GetAll()).Return(new[] { product });
             #endregion
             ProductController = new ProductController(ProductApplication);
         }
        [Test]
        public void GetProduct()
        {
            var product  = ProductController.Get(1);
            Assert.IsNotNull(product);
        }


        [Test]
        public void GetAllProduct()
        {
            var products = ProductController.Get();
            Assert.IsNotNull(products);
            Assert.IsTrue(products.ToList().Count() == 1);
        }

        [Test]
        public void PostProduct()
        {
            ProductController.Post(product);
            var productReturn = ProductController.Get(1);
            Assert.IsNotNull(productReturn);
        }

        [TearDown]
        protected virtual void TearDown()
        {

        }
    }
}
