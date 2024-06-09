using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {

            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmementId))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));



        }
    }
}
