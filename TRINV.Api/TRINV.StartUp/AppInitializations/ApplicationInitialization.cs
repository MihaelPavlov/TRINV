using TRINV.Domain.Common.Mapping;

namespace TRINV.StartUp.AppInitializations;

public static class ApplicationInitialization
{
    public static IApplicationBuilder InitializeMappings(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var initializers = serviceScope.ServiceProvider.GetServices<IMappingInitializer>();

        foreach (var initializer in initializers)
        {
            initializer.InitializeMappings();
        }

        return app;
    }
}
