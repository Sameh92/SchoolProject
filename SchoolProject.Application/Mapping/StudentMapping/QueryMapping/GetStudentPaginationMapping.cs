using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
               .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudID))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
