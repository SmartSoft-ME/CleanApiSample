using CleanApiSample.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApiSample.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.User).WithMany()
                .HasForeignKey(p => p.UserId);
            builder.HasMany(p => p.Tags).WithMany(t => t.Posts);
        }
    }
}
