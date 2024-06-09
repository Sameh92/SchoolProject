using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Department.Queries.Results;

namespace SchoolProject.Application.Features.Department.Queries.Models
{
    public class GetDepartmentByIDQuery : IRequest<Response<GetDepartmentByIDResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }

}