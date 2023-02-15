using Microsoft.EntityFrameworkCore;
using StudentRegistration.Infra.Domain;

namespace StudentRegistrationDemo.API.Configuration
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServer(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"];
            services.AddDbContext<StudentContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("StudentRegistration.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            },ServiceLifetime.Singleton);
        }
    }
}