using SchoolProject.Application.Features.ApplicationUser.Queries.Results;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Application.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginationMapping()
        {
            CreateMap<User, GetUserPaginationReponse>();

        }
    }
}
