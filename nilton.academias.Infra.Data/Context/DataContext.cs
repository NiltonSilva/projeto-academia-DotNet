using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nilton.academias.Domain.Entities.Account;
using nilton.academias.Infra.Data.DataConfig;

namespace nilton.academias.Infra.Data.Context
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<Users>(new UsersConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
