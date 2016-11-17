using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegritasTeste.Web.Controllers
{
    public class CategoryController : CommonWebApiController<Category>
    {

        public CategoryController(ICategoryApplication application)
        {
            app = application;
        }

        //[HttpGet]
        //[Route("api/{categoryId}/Products")]
        //public IEnumerable<Product> Products(string categoryId)
        //{
        //   app.GetAll().Where(x=>x.CategoryID == categoryId).Select(x=>x.pr)
        //}
    }
}