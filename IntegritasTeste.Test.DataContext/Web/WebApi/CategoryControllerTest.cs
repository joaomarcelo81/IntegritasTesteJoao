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
    public class CategoryControllerTest
     {

         private ICategoryApplication CategoryApplication;
         private CategoryController CategoryController;
         private Category Category = new Category();
         [SetUp]
         protected virtual void SetUp()
         {
             CategoryApplication = MockRepository.GenerateMock<ICategoryApplication>();
             Category = new Category()
             {
                 Name = "Fruits"
                
             };
             #region Stub Methods
             CategoryApplication.Stub(x => x.Get(1)).Return(Category);
             CategoryApplication.Stub(x => x.GetAll()).Return(new[] { Category });
             #endregion
             CategoryController = new CategoryController(CategoryApplication);
         }
        [Test]
        public void GetCategory()
        {
            var Category  = CategoryController.Get(1);
            Assert.IsNotNull(Category);
        }


        [Test]
        public void GetAllCategory()
        {
            var Categorys = CategoryController.Get();
            Assert.IsNotNull(Categorys);
            Assert.IsTrue(Categorys.ToList().Count() == 1);
        }

        [Test]
        public void PostCategory()
        {
            CategoryController.Post(Category);
            var CategoryReturn = CategoryController.Get(1);
            Assert.IsNotNull(CategoryReturn);
        }

        [TearDown]
        protected virtual void TearDown()
        {

        }
    }
}
