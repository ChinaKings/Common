using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Core.DataRepository
{
    public class DbContextFactory : IDbContextFactory
    {
        private DbContext _dbContext;
        public DbContextFactory(DbContext context)
        {
            _dbContext = context;
        }
        public DbContext Get()
        {
            return _dbContext;
        }
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            return _dbContext as TDbContext;
        }
    }
}
