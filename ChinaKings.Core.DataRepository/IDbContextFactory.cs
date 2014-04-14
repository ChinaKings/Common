using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Core.DataRepository
{
    interface IDbContextFactory
    {
        DbContext Get();
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
