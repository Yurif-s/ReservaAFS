using FluentValidation;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Exception;

namespace ReservaAFS.Application.UseCases.Reserves;
public class ReserveValidator : AbstractValidator<RequestCreateReserveJson>
{
    public ReserveValidator()
    {
        RuleFor(reserve => reserve.ReservationTime).GreaterThan(DateTime.UtcNow).WithMessage(ResourceErrorMessages.RESERVES_CANNOT_PAST);
        RuleFor(reserve => reserve.Description).NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_INVALID);
        RuleFor(reserve => reserve.ReserveType).IsInEnum().WithMessage(ResourceErrorMessages.RESERVE_TYPE_INVALID);
    }
}
