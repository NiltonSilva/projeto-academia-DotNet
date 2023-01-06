using Microsoft.EntityFrameworkCore;
using nilton.academias.Domain.Entities.Account;

namespace nilton.academias.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
        }
    }
}
