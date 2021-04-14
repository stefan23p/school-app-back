using EFDataLibrary.DataAccess;
using EFDataLibrary.Repository.Interfaces;
using EFDataLibrary.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFDataLibrary
{
    public static class EFStartUpExtension
    {
        public static void AddEntityFramework(this IServiceCollection services , string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void AddEFServices(this IServiceCollection services)
        {
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
        }

    }
}
