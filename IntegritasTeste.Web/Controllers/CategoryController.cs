using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegritasTeste.Web.Controllers
{
    public class CategoryController : CommonWebApiController<Category>
    {

        public CategoryController(IBaseApplication<Category> application)
        {
            app = application;
        }
    }
}