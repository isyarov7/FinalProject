using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YVN.Models.Models;

namespace YVN.Database.Configuration
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(r => r.User)
                 .WithMany(b => b.Posts)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Photo)
                .WithOne(photo => photo.Post)
                .HasForeignKey<Photo>(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}