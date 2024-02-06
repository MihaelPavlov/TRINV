using Microsoft.Extensions.DependencyInjection;
using TRINV.Application.ExternalAssetIntegration.Queries;

namespace TRINV.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
                 this IServiceCollection services)
                 => services
                     .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TestQuery).Assembly));
    }
}
