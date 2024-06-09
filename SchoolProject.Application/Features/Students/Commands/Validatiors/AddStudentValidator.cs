using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Application.Resources;

namespace SchoolProject.Application.Features.Students.Commands.Validatiors
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public AddStudentValidator(IStudentRepository studentRepository, IStringLocalizer<SharedResources> stringLocalizer)
        {

            ApplyValidationRules();
            ApplyCustomeValidationRules();
            _studentRepository = studentRepository;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            //RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name must be not empty")
            //    .NotNull().WithMessage("Name must be not Null")
            //    .MaximumLength(10).WithMessage("Max Lenght is 10");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]).NotNull().WithMessage("Name must be not Null")
              .MaximumLength(10).WithMessage("Max Lenght is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} must be not empty").NotNull().WithMessage("{PropertyValue} must be not Null")
            .MaximumLength(10).WithMessage("{PropertyValue} Lenght is 10");

        }

        public void ApplyCustomeValidationRules()
        {
            // RuleFor(x => x.NameEn).MustAsync(async (Key, CancellationToken) => !await _studentRepository.IsNameExist(Key))
            //.WithMessage("The name is Exist");
            RuleFor(x => x.NameAr)
               .MustAsync(async (Key, CancellationToken) => !await _studentRepository.IsNameArExist(Key))
               .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _studentRepository.IsNameEnExist(Key))
               .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
