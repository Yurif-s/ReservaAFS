using FluentValidation;
using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Users;
public class UserValidator : AbstractValidator<RequestUserJson>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(user => user.Email).EmailAddress().WithMessage("O email é inválido.");
        RuleFor(user => user.Password).NotEmpty().WithMessage("A senha é obrigatória.");
        When(user => string.IsNullOrWhiteSpace(user.Password) == false, () =>
        {
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage("A senha deve conter pelo menos 8 caracteres.");
        });
    }
}
