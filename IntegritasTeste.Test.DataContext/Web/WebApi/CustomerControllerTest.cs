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
    public class CustomerControllerTest
     {

         private ICustomerApplication CustomerApplication;
         private CustomerController CustomerController;
         private Customer Customer = new Customer();
         [SetUp]
         protected virtual void SetUp()
         {
             CustomerApplication = MockRepository.GenerateMock<ICustomerApplication>();
             Customer = new Customer()
             {
                 Name = "Joao",
               
             };
             #region Stub Methods
             CustomerApplication.Stub(x => x.Get(1)).Return(Customer);
             CustomerApplication.Stub(x => x.GetAll()).Return(new[] { Customer });
             #endregion
             CustomerController = new CustomerController(CustomerApplication);
         }
        [Test]
        public void GetCustomer()
        {
            var Customer  = CustomerController.Get(1);
            Assert.IsNotNull(Customer);
        }


        [Test]
        public void GetAllCustomer()
        {
            var Customers = CustomerController.Get();
            Assert.IsNotNull(Customers);
            Assert.IsTrue(Customers.ToList().Count() == 1);
        }

        [Test]
        public void PostCustomer()
        {
            CustomerController.Post(Customer);
            var CustomerReturn = CustomerController.Get(1);
            Assert.IsNotNull(CustomerReturn);
        }

        [TearDown]
        protected virtual void TearDown()
        {

        }
    }
}
