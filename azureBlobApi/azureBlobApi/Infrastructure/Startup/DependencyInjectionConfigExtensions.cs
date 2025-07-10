using azureBlobApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace azureBlobApi.Infrastructure.Startup;

public static class DependencyInjectionConfigExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddAutoMapper(AssemblyReference.Assembly);
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MinhaConexao")));

    }
}
