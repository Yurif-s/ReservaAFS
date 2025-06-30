using FluentValidation;
using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Reserves;
public class ReserveValidator : AbstractValidator<RequestCreateReserveJson>
{
    public ReserveValidator()
    {
        RuleFor(reserve => reserve.ReservationTime).GreaterThan(DateTime.UtcNow).WithMessage("Reserva não pode ser para o passado");
        RuleFor(reserve => reserve.Description).NotEmpty().WithMessage("Descrição é obrigatória");
        RuleFor(reserve => reserve.ReserveType).IsInEnum().WithMessage("Recurso reservado é inválido");
    }
}
