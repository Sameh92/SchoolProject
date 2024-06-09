using MediatR;
using SchoolProject.Application.Bases;
//using System.ComponentModel.DataAnnotations;


namespace SchoolProject.Application.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {

        // [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmementId { get; set; }
    }
}