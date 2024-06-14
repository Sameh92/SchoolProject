using AutoMapper;


namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIDMapping();
            GetStudentPaginationMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
