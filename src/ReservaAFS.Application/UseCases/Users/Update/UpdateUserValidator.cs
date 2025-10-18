using FluentValidation;
using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Users.Update;
public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("O email não pode ser vazio.")
            .EmailAddress()
            .WithMessage("O email é inválido.");
    }
}
