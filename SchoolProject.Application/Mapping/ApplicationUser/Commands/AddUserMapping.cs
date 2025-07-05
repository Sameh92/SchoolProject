using SchoolProject.Application.Features.ApplicationUser.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Application.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
