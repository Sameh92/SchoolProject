using MediatR;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Application.Wrappers;
using SchoolProject.Domain.Helper;

namespace SchoolProject.Application.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string Search { get; set; }
    }
}
