using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntegritasTeste.Application;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;

namespace IntegritasTeste.Web.Controllers
{
    public class CustomerController : CommonWebApiController<Customer>
    {

      
        public CustomerController(IBaseApplication<Customer> customerService)
        {
            app = customerService;
        }
    }
}