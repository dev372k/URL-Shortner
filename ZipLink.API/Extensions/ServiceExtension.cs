using ZipLink.Infrastructure.Implementation;
using ZipLink.Infrastructure.Interfaces;

namespace ZipLink.API.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUrlServiceRepo, UrlServiceRepo>();
        }
    }
}
