using FluentValidation;
using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Users.Create;
public class CreateUserValidator : AbstractValidator<RequestCreateUserJson>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("O email não pode ser vazio.")
            .EmailAddress()
            .WithMessage("O email é inválido.");
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestCreateUserJson>());
    }
}
