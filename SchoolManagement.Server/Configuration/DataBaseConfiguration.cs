using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess;

namespace SchoolManagement.Server.Configuration;

public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionConfiguration = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionConfiguration));
    }
}
