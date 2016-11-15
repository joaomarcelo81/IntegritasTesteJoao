using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegritasTeste.DataContext.DataContext;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Repositories;

namespace IntegritasTeste.DataContext.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IntegritasTesteDataContext _context)
            : base(_context)
        {
        }
    }
}
