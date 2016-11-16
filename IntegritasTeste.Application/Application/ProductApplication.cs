using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Application.Application
{
    public class ProductApplication : BaseApplication<Product>, IProductApplication
    {
        public ProductApplication(IBaseRepository<Product> serviceBase)
            : base(serviceBase)
        {
        }
    }
}
