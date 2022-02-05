using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPanelWebApi.Entities;

namespace UserPanelWebApi.DataAccess
{
    public class QueryContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }

        public QueryContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
