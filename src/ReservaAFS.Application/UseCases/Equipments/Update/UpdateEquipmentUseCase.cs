using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Equipments;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Equipments.Update;
public class UpdateEquipmentUseCase : IUpdateEquipmentUseCase
{
    private readonly IMapper _mapper;
    private readonly IEquipmentsUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateEquipmentUseCase(IMapper mapper, IEquipmentsUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id, RequestEquipmentJson request)
    {
        Validate(request);

        var equipment = await _repository.GetById(id);

        if (equipment is null)
            throw new NotFoundException("Equipamento não encontrado");

        _mapper.Map(request, equipment);

        _repository.Update(equipment);

        await _unitOfWork.Commit();
    }
    private void Validate(RequestEquipmentJson request)
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
