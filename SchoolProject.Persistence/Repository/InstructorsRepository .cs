using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Persistence.Repository
{
    public class InstructorsRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion

        #region Constructors
        public InstructorsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
