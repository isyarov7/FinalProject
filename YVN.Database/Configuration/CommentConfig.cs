using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YVN.Models.Models;

namespace YVN.Database.Configuration
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(c => c.User)
               .WithMany(p => p.Comments)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
