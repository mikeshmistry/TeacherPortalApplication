using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TeacherPortal.UI.Areas.Identity.IdentityHostingStartup))]
namespace TeacherPortal.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}