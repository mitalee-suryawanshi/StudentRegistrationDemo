using StudentRegistration.Core.Contract;
using StudentRegistration.Core.Service;
using StudentRegistration.Infra.Contract;
using StudentRegistration.Infra.Repository;

namespace StudentRegistrationDemo.API.Configuration
{
    public static class DependancyConfiguration
    {
        public static void AddDependency(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            //services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}