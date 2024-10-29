using FluentValidation;
using school.core.Futuer.Students.commends.Module;
using school.service.StudentServicerepo;

namespace school.core.Futuer.Students.commends.Validation
{
    public class UpdateStudentvalidator : AbstractValidator<UpdateStudentCommend>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentvalidator(IStudentService studentService)
        {
            UpdateStudentValidator();
            customUbdateValid();
            _studentService = studentService;
        }

        public void UpdateStudentValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("must enter name")
            .NotNull().WithMessage("must not be null")
            .MaximumLength(10).WithMessage("must be 10");
            RuleFor(A => A.Address).MinimumLength(5).NotEmpty().WithMessage("{PropertyName} Address shoud have value")
                .NotNull().WithMessage("{PropertyName} must not by null ");

        }
        public void customUbdateValid()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Module, key, CancellationToken) => !await _studentService.IsNameExistExcloudSelf(key, Module.Id))
                .WithMessage("Name is Exist");

        }
    }
}
