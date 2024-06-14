using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Contracts.IRepository
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<bool> IsDepartementIdExist(int departmetnId);
    }
}
