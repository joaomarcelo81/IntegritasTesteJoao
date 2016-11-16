using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegritasTeste.Web.Controllers
{
    public class ProductController : CommonWebApiController<Product>
    {

        public ProductController(IBaseApplication<Product> application)
        {
            app = application;
        }
    }
}