﻿using MediatR;
using SchoolProject.Application.Bases;

namespace SchoolProject.Application.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmementId { get; set; }
    }
}
