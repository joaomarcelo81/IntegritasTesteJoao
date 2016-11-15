using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegritasTeste.Domain;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;
using System.Web;

namespace IntegritasTeste.Web.Controllers
{
    public class HomeController : DefaultController
    {
 

        public ActionResult Index()
        {
            var CartId = Cart.CartId;
            ViewBag.Title = "Home Page" + CartId;
            return View();
        }
    }
}
