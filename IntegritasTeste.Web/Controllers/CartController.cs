using System;
using System.Web;
using System.Web.Mvc;
using IntegritasTeste.Domain;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;
using System.Collections.Generic;

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
        public ActionResult Add(Product product)
        {
            var cart = new Cart();
           var httpCookie = HttpContext.Request.Cookies.Get(CacheRepositories.ShoppingCart);
           if (httpCookie != null)
           {
               var CartId = httpCookie.Value;
               cart = CacheRepository.GetObjectCache<Cart>(CacheRepositories.ShoppingCart + CartId.ToString());
               if (cart != null)
               {
                   var isIncremented = false;

                   foreach (var item in cart.products)
                       if (item.ProductID == product.ProductID)
                       {
                           isIncremented = true;
                           item.Quantity++;
                       }


                   if (!isIncremented)
                   {
                       product.Quantity = 1;
                       cart.AddItem(product);
                   }
               }

           }
           HttpContext.Response.Cookies.Remove(CacheRepositories.ShoppingCart);
           HttpContext.Request.Cookies.Remove(CacheRepositories.ShoppingCart);
           HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, cart.CartId.ToString()));
           CacheRepository.SetObjectCache(cart, CacheRepositories.ShoppingCart + cart.CartId);



            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Remove(Product product)
        {

            var cart = new Cart();
            var httpCookie = HttpContext.Request.Cookies.Get(CacheRepositories.ShoppingCart);
            if (httpCookie != null)
            {
                var CartId = httpCookie.Value;
                cart = CacheRepository.GetObjectCache<Cart>(CacheRepositories.ShoppingCart + CartId.ToString());
                if (cart != null)
                {
                    var isAdded = false;

                    foreach (var item in cart.products)
                        if (item.ProductID == product.ProductID)
                        {
                            isAdded = true;
                            item.Quantity--;
                        }


                    if (!isAdded)
                        cart.RemoveItem(product);
                }

            }
            HttpContext.Response.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Request.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, cart.CartId.ToString()));
            CacheRepository.SetObjectCache(cart, CacheRepositories.ShoppingCart + cart.CartId);




          
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
