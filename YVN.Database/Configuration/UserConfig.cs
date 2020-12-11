using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YVN.Models.Models;

namespace YVN.Database.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(r => r.FriendRequestSent)
                .WithOne(b => b.Sender)
                .HasForeignKey(r => r.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.FriendRequestReceived)
                .WithOne(b => b.Receiver)
                .HasForeignKey(r => r.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
