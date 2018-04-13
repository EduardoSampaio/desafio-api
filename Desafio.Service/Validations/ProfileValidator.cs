using Desafio.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Service.Validations
{
    public class ProfileValidator : AbstractValidator<ProfileViewModel>, IValidatorCustomize<ProfileViewModel>
    {
        public ProfileValidator()
        {
            RuleFor(role => role.Name)
            .NotNull()
            .NotEmpty().WithMessage("Por favor preencha o nome do perfil")
            .MaximumLength(30).WithMessage("Excedeu número de 30 caracteres permitidos");
        }

        public ValidationResult Validation(ProfileViewModel model)
        {
            var validator = new ProfileValidator();
            return validator.Validate(model);
        }
    }
}