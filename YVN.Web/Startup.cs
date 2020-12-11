using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YVN.Database;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.Services;
using YVN.Web.Areas.Identity.Pages;

namespace YNV___YourVirtualNeighborhood
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YvnDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<YvnDbContext>()
            //    .AddUserManager<IdentityUser>()
            //    .AddRoleManager<IdentityRole>();

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddEntityFrameworkStores<YvnDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.LogoutPath = new PathString("/Identity/Account/Logout");
                options.AccessDeniedPath = new PathString("/Home/Index");
            });

            services.AddControllersWithViews(
                /* GLABAL CONFIGURATION FOR ANTI FORGERY KEY!!!!*/
                configure =>
                {
                    configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                });

            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();

            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IFriendRequestService, FriendRequestService>();
            services.AddScoped<ICommentService, CommentService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
