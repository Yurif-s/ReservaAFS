using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Equipments;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Equipments.Create;
public class CreateEquipmentUseCase : ICreateEquipmentUseCase
{
    private readonly IMapper _mapper;
    private readonly IEquipmentsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateEquipmentUseCase(IMapper mapper, IEquipmentsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseCreatedEquipmentJson> Execute(RequestEquipmentJson request)
    {
        Validade(request);

        var equipment = _mapper.Map<Equipment>(request);

        await _repository.Add(equipment);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseCreatedEquipmentJson>(equipment);
    }
    private void Validade(RequestEquipmentJson request)
    {
        var validator = new EquipmentValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
