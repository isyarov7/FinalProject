using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YVN.Database.Configuration;
using YVN.Models.Models;

namespace YVN.Database
{
    public class YvnDbContext : IdentityDbContext<User, Role, int>
    {
        public YvnDbContext(DbContextOptions<YvnDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new PhotoConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new FriendConfig());

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "member",
                    NormalizedName = "MEMBER",
                },
                new Role
                {
                    Id = 2,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                });

            var hasher = new PasswordHasher<User>();

            User admin = new User
            {
                Id = 1,
                UserName = "admin@admin.admin",
                FirstName = "Admin",
                LastName = "Admin",
                NormalizedUserName = "ADMIN@ADMIN.ADMIN",
                Email = "admin@admin.admin",
                NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                SecurityStamp = "7I5VHIJTSZNOT3KDWKNFUV5PVYBHGXN",
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            modelBuilder.Entity<User>().HasData(admin);

            base.OnModelCreating(modelBuilder);
        }
    }
}
