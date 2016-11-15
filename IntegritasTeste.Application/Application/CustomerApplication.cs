using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Application.Application
{
    public class CustomerApplication : BaseApplication<Customer>, ICustomerApplication
    {
        public CustomerApplication(IBaseRepository<Customer> serviceBase) : base(serviceBase)
        {
        }
    }
}
