using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Domain.Entities;


namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentByIDMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
           //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized()));
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
