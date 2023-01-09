using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nilton.academias.Domain.Entities.Account;

namespace nilton.academias.Infra.Data.DataConfig
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        { 
            builder.ToTable("Users");

            builder.Property(x => x.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnType("varchar(50)")
                .IsRequired();

        }
    }
}
