using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YVN.Models.Models;

namespace YVN.Database.Configuration
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasOne(r => r.FriendOfUser)
                 .WithMany(b => b.Friends)
                 .HasForeignKey(r => r.FriendId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
