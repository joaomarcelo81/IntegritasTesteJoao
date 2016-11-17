using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.Application.Application
{
    public class LoggerApplication : BaseApplication<Logger>, ILoggerApplication
    {
        public LoggerApplication(IBaseRepository<Logger> serviceBase)
            : base(serviceBase)
        {
        }
    }
}
