using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helper;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Persistence.Repository
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _students = dBContext.Set<Student>();

        }


        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum ordering, string search)
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            query = query.Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                query = query.Where(x => x.NameEn.Contains(search) || x.Address.Contains(search));
            }
            switch (ordering)
            {
                case StudentOrderingEnum.StudID:
                    query.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    query.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderingEnum.Address:
                    query.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    query.OrderBy(x => x.Department.DNameEn);
                    break;
                default:
                    query.OrderBy(x => x.NameAr);
                    break;
            }

            return query;

        }
        public IQueryable<Student> GetStudentsQueryabl()
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            return query.Include(x => x.Department).AsQueryable();
        }

        public async Task<bool> IsNameArExist(string studentName)
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            var student = await query.Where(x => x.NameAr.Equals(studentName)).FirstOrDefaultAsync();
            if (student != null)
                return true;
            return false;
        }
        public async Task<bool> IsNameEnExist(string studentName)
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            var student = await query.Where(x => x.NameEn.Equals(studentName)).FirstOrDefaultAsync();
            if (student != null)
                return true;
            return false;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string studentName, int studentId)
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            var student = await query.Where(x => x.NameAr.Equals(studentName) && !x.StudID.Equals(studentId)).FirstOrDefaultAsync();

            if (student != null)
                return true;
            return false;
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string studentName, int studentId)
        {
            var query = GetTableAsTracking() as IQueryable<Student>;
            var student = await query.Where(x => x.NameEn.Equals(studentName) && !x.StudID.Equals(studentId)).FirstOrDefaultAsync();

            if (student != null)
                return true;
            return false;
        }

        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID)
        {
            var query = GetTableNoTracking();
            return query.Where(x => x.DID.Equals(DID)).AsQueryable();
        }
        #endregion

    }
}
