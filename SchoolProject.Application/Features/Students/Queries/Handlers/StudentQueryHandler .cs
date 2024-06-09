using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Application.Resources;
using SchoolProject.Application.Wrappers;
using SchoolProject.Domain.Entities;
using System.Linq.Expressions;



namespace SchoolProject.Application.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentLisResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public StudentQueryHandler(IStudentRepository studentRepository, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<Response<List<GetStudentLisResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentRepository.GetStudentsListAsync();
            var studentListResult = _mapper.Map<List<GetStudentLisResponse>>(studentList);

            var result = Success(studentListResult);
            result.Meta = new { Count = studentListResult.Count() };
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                           .Include(x => x.Department)
                                           .Where(x => x.StudID.Equals(request.Id))
                                           .FirstOrDefaultAsync();


            // if (student == null) return NotFound<GetSingleStudentResponse>("NotFound");
            if (student == null) return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = student =>
            new GetStudentPaginatedListResponse(student.StudID, student.Localize(student.NameEn, student.NameAr), student.Address, student.Localize(student.Department.DNameEn, student.Department.DNameAr));

            // var queryable = _studentRepository.GetStudentsQueryabl();
            var filterQuery = _studentRepository.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);

            // var paginatedList= await queryable.ToPaginatedListAsync(request.PageNumber,request.PageSize);
            var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }


}
