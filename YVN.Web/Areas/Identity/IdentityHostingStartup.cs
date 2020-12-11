using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(YVN.Web.Areas.Identity.IdentityHostingStartup))]
namespace YVN.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}