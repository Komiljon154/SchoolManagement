using SchoolManagement.Repository.Services;

namespace SchoolManagement.Server.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();

        // Other services will be registered only after creation // Comment by Saidabror
    }
}
