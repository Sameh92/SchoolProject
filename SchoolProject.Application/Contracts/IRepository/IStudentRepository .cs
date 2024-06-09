using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helper;

namespace SchoolProject.Application.Contracts.IRepository
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<bool> IsNameArExist(string studentName);
        Task<bool> IsNameEnExist(string studentName);
        Task<bool> IsNameArExistExcludeSelf(string studentName, int studentId);
        Task<bool> IsNameEnExistExcludeSelf(string studentName, int studentId);
        public IQueryable<Student> GetStudentsQueryabl();
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);

        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum ordering, string search);
    }
}
