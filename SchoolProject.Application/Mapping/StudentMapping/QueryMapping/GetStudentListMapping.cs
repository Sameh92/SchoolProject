using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Domain.Entities;


namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentLisResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DNameEn))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameEn, src.NameAr)));

        }
    }
}
