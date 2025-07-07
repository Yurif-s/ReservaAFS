using AutoMapper;
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
    private readonly IMapper _mapper;
    public CreateReserveUseCase(IReservesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseShortReserveJson> Execute(RequestCreateReserveJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Reserve>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseShortReserveJson>(entity);
    }

    private void Validate(RequestCreateReserveJson request)
    {
        var validator = new ReserveValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
