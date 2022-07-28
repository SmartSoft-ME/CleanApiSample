using CleanApiSample.Domain.Entities;
using CleanApiSample.Domain.EntityProperties.UserProperties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApiSample.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .HasConversion(un => un.Value, un => Username.Create(un));
            builder.Property(u => u.Email)
                .HasConversion(e => e.ToString(), e => Email.Create(e));
        }
    }
}
