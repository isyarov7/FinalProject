using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YVN.Models.Models;

namespace YVN.Database.Configuration
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany(b => b.Photos)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Post)
               .WithOne(b => b.Photo)
               .HasForeignKey<Post>(p => p.PhotoId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
