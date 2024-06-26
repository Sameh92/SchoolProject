﻿using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Mapping.StudentMapping
{
    public partial class StudentProfile
    {

        public void AddStudentCommandMapping()
        {

            CreateMap<AddStudentCommand, Student>().ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmementId))
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
            .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));


        }
    }
}
