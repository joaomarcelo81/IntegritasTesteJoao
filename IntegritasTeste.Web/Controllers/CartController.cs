using System;
using System.Web;
using System.Web.Mvc;
using IntegritasTeste.Domain;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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



            return Json(new{success = true, message = "success"}, JsonRequestBehavior.AllowGet);
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
                var newList = new List<Product>();
                if (cart != null)
                {
                   newList  = cart.products.Where(x => x.ProductID != product.ProductID).ToList();
                }
                cart.products = newList;
            }
            HttpContext.Response.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Request.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, cart.CartId.ToString()));
            CacheRepository.SetObjectCache(cart, CacheRepositories.ShoppingCart + cart.CartId);
            return Json(new{success = true, message = "success"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(List<Product> products)
        {
            var cart = new Cart();
            var httpCookie = HttpContext.Request.Cookies.Get(CacheRepositories.ShoppingCart);
            if (httpCookie != null)
            {
                var CartId = httpCookie.Value;
                cart = CacheRepository.GetObjectCache<Cart>(CacheRepositories.ShoppingCart + CartId.ToString());
               
                if (cart != null)
                {

                    var newList = new List<Product>();
                    foreach (var ItemProduct in products)
                    {
                        var product  = cart.products.FirstOrDefault(x => x.ProductID == ItemProduct.ProductID);
                        if (product != null)
                        {
                            product.Quantity = ItemProduct.Quantity;
                            if (product.Quantity > 0)
                                newList.Add(product);
                        }
                    }
                    cart.products = newList;
                }
            }
            HttpContext.Response.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Request.Cookies.Remove(CacheRepositories.ShoppingCart);
            HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, cart.CartId.ToString()));
            CacheRepository.SetObjectCache(cart, CacheRepositories.ShoppingCart + cart.CartId);
            return Json(new { success = true, message = "success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetCustomer(Customer customer)
        {
            Cart.SetCustomer(customer);
            return Json(new{success = true, message = "success"}, JsonRequestBehavior.AllowGet);
        }
    }
}

