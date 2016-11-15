using System;
using System.Web;
using System.Web.Mvc;
using IntegritasTeste.Domain;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;

namespace IntegritasTeste.Web.Controllers
{

    /// <summary>
    /// Cart Controller
    /// </summary>
    public class CartController : DefaultController
    {
        private CacheRepository _cacheRepository { get; set; }
        public CacheRepository CacheRepository
        {
            get { return _cacheRepository ?? (_cacheRepository = new CacheRepository()); }
            set { _cacheRepository = value; }
        }

 


        public CartController()
        {
          
            
    
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Json(Cart, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(Product value)
        {
            var cart = new Cart();
           var httpCookie = HttpContext.Request.Cookies.Get(CacheRepositories.ShoppingCart);
           if (httpCookie != null)
           {
               var CartId = httpCookie.Value;
               cart = CacheRepository.GetObjectCache<Cart>(CacheRepositories.ShoppingCart + CartId.ToString());
               if (cart != null)
               {
                   cart.AddItem(value);
               }

           }
           HttpContext.Response.Cookies.Remove(CacheRepositories.ShoppingCart);
           HttpContext.Request.Cookies.Remove(CacheRepositories.ShoppingCart);
           HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, cart.CartId.ToString()));
           CacheRepository.SetObjectCache(Cart, CacheRepositories.ShoppingCart + cart.CartId);



            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Remove(Product value)
        {
            Cart.RemoveItem(value);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetCustomer(Customer customer)
        {
            Cart.SetCustomer(customer);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
