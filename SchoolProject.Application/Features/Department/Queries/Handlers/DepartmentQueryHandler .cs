using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Application.Features.Department.Queries.Models;
using SchoolProject.Application.Features.Department.Queries.Results;
using SchoolProject.Application.Resources;
using SchoolProject.Application.Wrappers;
using SchoolProject.Domain.Entities;
using System.Linq.Expressions;

namespace SchoolProject.Application.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
     IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDResponse>>
    {

        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                      IDepartmentRepository departmentRepository,
                                      IMapper mapper,
                                      IStudentRepository studentRepository) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<Response<GetDepartmentByIDResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            //service Get By Id include St sub ins
            var response = await _departmentRepository.GetDepartmentById(request.Id);
            //check Is Not exist
            if (response == null) return NotFound<GetDepartmentByIDResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            //mapping 
            var mapper = _mapper.Map<GetDepartmentByIDResponse>(response);

            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentRepository.GetStudentsByDepartmentIDQuerable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaginatedList;

            //return response
            return Success(mapper);
        }
        #endregion

        #region Handle Functions
        #endregion
    }
}
