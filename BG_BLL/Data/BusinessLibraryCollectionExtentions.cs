using BG_BLL.Imlementations;
using BG_BLL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BG_BLL.Data
{
    public static class BusinessLibraryCollectionExtentions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection services)
        {
            services.AddScoped<IPersonageBusinessServices, PersonageBusinessServices>();
            services.AddScoped<IApplicationUserBusinessServices, ApplicationUserBusinessServices>();

            return services;
        }
    }
}
