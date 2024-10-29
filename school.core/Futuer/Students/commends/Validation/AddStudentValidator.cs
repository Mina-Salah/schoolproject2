using FluentValidation;
using school.core.Futuer.Students.commends.Module;
using school.service.StudentServicerepo;

namespace school.core.Futuer.Students.commends.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommend>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            AddStudentValidation();
            customValidator();
        }
        public void AddStudentValidation()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("must enter name")
                .NotNull().WithMessage("must not be null")
                .MaximumLength(10).WithMessage("must be 10");
            RuleFor(A => A.Address).MinimumLength(5).NotEmpty().WithMessage("{PropertyName} Address shoud have value")
                .NotNull().WithMessage("{PropertyName} must not by null ");


        }
        public void customValidator()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("Name is Exist");
        }
    }
}
