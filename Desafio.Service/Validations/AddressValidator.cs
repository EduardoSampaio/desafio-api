using Desafio.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Desafio.Service.Validations
{
    public class AddressRegisterValidator : AbstractValidator<AddressRegisterViewModel>, IValidatorCustomize<AddressRegisterViewModel>
    {
        public AddressRegisterValidator()
        {
            RuleFor(role => role.ZipCode)
              .Matches(@"[0-9]{8}").WithMessage("Por favor digite Cep valido")
              .MaximumLength(10).WithMessage("Excedeu número de 10 caracteres permitidos");
        }

        public ValidationResult Validation(AddressRegisterViewModel model)
        {
            var validator = new AddressRegisterValidator();
            return validator.Validate(model); ;
        }
    }

    public class AddressValidator : AbstractValidator<AddressViewModel>, IValidatorCustomize<AddressViewModel>
    {
        public AddressValidator()
        {
            RuleFor(role => role.ZipCode)
              .Matches(@"[0-9]{5}-[0-9]{3}").WithMessage("Por favor digite Cep valido")
              .MaximumLength(10).WithMessage("Excedeu número de 10 caracteres permitidos");
        }

        public ValidationResult Validation(AddressViewModel model)
        {
            var validator = new AddressValidator();
            return validator.Validate(model); ;
        }
    }
}