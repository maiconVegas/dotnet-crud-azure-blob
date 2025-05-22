namespace azureBlobApi.Infrastructure.Startup;

public static class DependencyInjectionConfigExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddAutoMapper(AssemblyReference.Assembly);
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
    }
}
