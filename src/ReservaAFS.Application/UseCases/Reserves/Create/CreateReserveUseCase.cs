using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Reserves.Create;
public class CreateReserveUseCase : ICreateReserveUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReservesRepository _repository;
    public CreateReserveUseCase(IReservesRepository repository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public ResponseCreateReserveJson Execute(RequestCreateReserveJson request)
    {
        Validate(request);

        var entity = new Reserve
        {
            Description = request.Description,
            ReservationTime = request.ReservationTime,
            ReserveType = (Domain.Enums.ReserveType)request.ReserveType
        };

        _repository.Add(entity);

        _unitOfWork.Commit();

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
