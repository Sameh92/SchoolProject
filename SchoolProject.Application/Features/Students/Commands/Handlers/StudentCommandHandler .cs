using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Application.Resources;
using SchoolProject.Domain.Entities;
namespace SchoolProject.Application.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
         IRequestHandler<EditStudentCommand, Response<string>>,
         IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion


        #region Constructors

        public StudentCommandHandler(IMapper mapper, IStudentRepository studentRepository, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _stringLocalizer = stringLocalizer;

        }

        #endregion


        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var studentmapper = _mapper.Map<Student>(request);
            await _studentRepository.AddAsync(studentmapper);

            return Created("");
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student == null) return NotFound<string>("Student is Not Found");


            var newStudent = _mapper.Map(request, student);

            await _studentRepository.UpdateAsync(newStudent);

            return Success($"Edit Sussessfully {newStudent.StudID}");

        }
        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {

            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student == null) return NotFound<string>("Student is Not Found");

            using (var trans = _studentRepository.BeginTransaction())
            {
                try
                {
                    await _studentRepository.DeleteAsync(student);
                    await trans.CommitAsync();
                    return Deleted<string>($"Delete Successfully  {student.StudID}");
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return BadRequest<string>(ex.Message);
                }

            }






        }

        #endregion
    }
}
