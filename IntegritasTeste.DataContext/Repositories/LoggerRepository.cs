using IntegritasTeste.DataContext.DataContext;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.DataContext.Repositories
{
    public class LoggerRepository : BaseRepository<Logger>, ILoggerRepository
    {
        public LoggerRepository(IntegritasTesteDataContext _context)
            : base(_context)
        {
        }
    }
}
