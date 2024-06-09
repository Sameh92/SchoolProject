using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Persistence.Repository;

namespace SchoolProject.Persistence
{
    public static class ModulePersistenceDependencies
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorsRepository, InstructorsRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            return services;
        }

    }
}