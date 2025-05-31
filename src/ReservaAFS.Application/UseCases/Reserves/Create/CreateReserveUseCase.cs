using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Reserves.Create;
public class CreateReserveUseCase : ICreateReserveUseCase
{
    public ResponseCreateReserveJson Execute(RequestCreateReserveJson request)
    {
        Validate(request);

        return new ResponseCreateReserveJson()
        {
            ReserveType = request.ReserveType,
            ReservationTime = request.ReservationTime
        };
    }

    private void Validate(RequestCreateReserveJson request)
    {
        var validator = new CreateReserveValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
