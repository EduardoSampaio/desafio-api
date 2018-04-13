using FluentValidation.Results;

namespace Desafio.Service.Validations
{
    public interface IValidatorCustomize<Model> where Model : class
    {
        ValidationResult Validation(Model model);
    }
}