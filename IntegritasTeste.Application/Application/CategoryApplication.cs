using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Application.Application
{
    public class CategoryApplication : BaseApplication<Category>, ICategoryApplication
    {
        public CategoryApplication(IBaseRepository<Category> serviceBase)
            : base(serviceBase)
        {
        }
    }
}
