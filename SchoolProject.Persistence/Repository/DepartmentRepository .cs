using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Persistence.Repository
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var query = GetTableNoTracking();
            var result = await query.Where(x => x.DID.Equals(id))
                        .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                        .Include(x => x.Instructors)
                        .Include(x => x.Instructor).FirstOrDefaultAsync();

            return result;
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
