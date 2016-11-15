using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegritasTeste.Domain;
using IntegritasTeste.Domain.Common;
using IntegritasTeste.Domain.Entities;

namespace IntegritasTeste.Web.Controllers
{
    public class DefaultController : Controller
    {
        private CacheRepository _cacheRepository { get; set; }
        public CacheRepository CacheRepository
        {
            get { return _cacheRepository ?? (_cacheRepository = new CacheRepository()); }
            set { _cacheRepository = value; }
        }

        private Cart _Cart { get; set; }

        public Cart Cart
        {
            get
            {

                _Cart = new Cart()
                {
                    CartId = Guid.NewGuid(),
                    customer = new Customer()
                    {

                        Active = true,
                        Name = "Anonymous"
                    }
                };

                var httpCookie = HttpContext.Request.Cookies.Get(CacheRepositories.ShoppingCart);
                if (httpCookie != null)
                {
                    var CartId = httpCookie.Value;
                    _Cart = CacheRepository.GetObjectCache<Cart>(CacheRepositories.ShoppingCart + CartId.ToString());
                    if (_Cart == null)
                    {
                        _Cart = new Cart()
                        {
                            CartId = Guid.NewGuid(),
                            customer = new Customer()
                            {

                                Active = true,
                                Name = "Anonymous"
                            }
                        };
                        HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, CartId.ToString()));
                        CacheRepository.SetObjectCache(_Cart, CacheRepositories.ShoppingCart + _Cart.CartId);
                    }
                }
                else
                {
                    HttpContext.Response.Cookies.Add(new HttpCookie(CacheRepositories.ShoppingCart, _Cart.CartId.ToString()));
                    CacheRepository.SetObjectCache(_Cart, CacheRepositories.ShoppingCart + _Cart.CartId);
                }
                return _Cart;
            }
            set { _Cart = value; }
        }
    }
}