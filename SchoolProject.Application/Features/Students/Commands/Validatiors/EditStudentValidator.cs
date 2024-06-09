using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Application.Contracts.IRepository;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Application.Resources;

namespace SchoolProject.Application.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentRepository studentRepository, IStringLocalizer<SharedResources> localizer)
        {
            ApplyValidationRules();
            ApplyCustomeValidationRules();
            _studentRepository = studentRepository;
            _localizer = localizer;

        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name must be not empty")
                .NotNull().WithMessage("Name must be not Null")
                .MaximumLength(10).WithMessage("Max Lenght is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} must be not empty")
            .NotNull().WithMessage("{PropertyValue} must be not Null")
            .MaximumLength(10).WithMessage("{PropertyValue} Lenght is 10");

        }

        public void ApplyCustomeValidationRules()
        {
            // RuleFor(x => x.NameEn).MustAsync(async (model, Key, CancellationToken) => !await _studentRepository.IsNameExistExcludeSelf(Key, model.Id))
            //.WithMessage("The name is Exist");

            RuleFor(x => x.NameAr)
               .MustAsync(async (model, Key, CancellationToken) => !await _studentRepository.IsNameArExistExcludeSelf(Key, model.Id))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentRepository.IsNameEnExistExcludeSelf(Key, model.Id))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
