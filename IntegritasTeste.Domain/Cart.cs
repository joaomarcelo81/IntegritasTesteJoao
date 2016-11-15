using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using IntegritasTeste.Domain.Entities;

namespace IntegritasTeste.Domain
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public string Session { get; set; }
        private Customer _customer { get; set; }
        public Customer customer
        {
            get { return _customer ?? (_customer = new Customer()); }
            set { _customer = value; }
        }
        private IList<Product> _products;
        public IList<Product> products
        {
            get { return _products ?? (_products = new List<Product>()); }
            set { _products = value; }
        }

        public Cart()
        {
            
        }

        public Cart(Customer Customer)
        {
            _customer = Customer;
        }

        public void AddItem(Product product)
        {
            products.Add(product);
            
        }
        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }
        public void RemoveItem(Product product)
        {
            products.Remove(product);
        }
    }
}
