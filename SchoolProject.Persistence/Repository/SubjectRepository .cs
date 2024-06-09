using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Persistence.Repository
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subjects> subjects;
        #endregion

        #region Constructors
        public SubjectRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subjects>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
