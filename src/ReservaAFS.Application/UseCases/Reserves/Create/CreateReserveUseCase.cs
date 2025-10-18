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
    private readonly IReservesWriteOnlyRepository _writeRepository;
    private readonly IReservesReadOnlyRepository _readRepository;
    private readonly IMapper _mapper;
    public CreateReserveUseCase(IReservesReadOnlyRepository readRepository ,IReservesWriteOnlyRepository writeRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }
    public async Task<ResponseCreatedReserveJson> Execute(RequestReserveJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Reserve>(request);

        var result = await _readRepository.IsAvailable(entity.EquipmentId, entity.ReservationTime, entity.Class);

        if (result is false)
            throw new ErrorOnValidationException(["Conflito de horário"]);

        await _writeRepository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCreatedReserveJson>(entity);
    }

    private void Validate(RequestReserveJson request)
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
