using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Domain.Entities;


namespace SchoolProject.Application.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentLisResponse>>>
    {
    }
}
