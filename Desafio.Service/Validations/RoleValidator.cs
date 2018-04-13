using Desafio.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Service.Validations
{
    public class RoleValidator : AbstractValidator<RoleViewModel>, IValidatorCustomize<RoleViewModel>
    {
        public RoleValidator()
        {
            RuleFor(role => role.Name)
              .NotNull()
              .NotEmpty().WithMessage("Por favor preencha o nome da função")
              .MaximumLength(30).WithMessage("Excedeu número de 30 caracteres permitidos");

            RuleFor(role => role.Description)
            .NotNull()
            .NotEmpty().WithMessage("Por favor preencha o descrição da função")
            .MaximumLength(100).WithMessage("Excedeu número de 100 caracteres permitidos");
        }

        public ValidationResult Validation(RoleViewModel model)
        {
            var validator = new RoleValidator();
            return validator.Validate(model);
        }
    }
}