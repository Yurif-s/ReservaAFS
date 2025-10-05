using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Equipments;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Equipments.GetById;
public class GetByIdEquipmentUseCase : IGetByIdEquipmentUseCase
{
    private readonly IMapper _mapper;
    private readonly IEquipmentsReadOnlyRepository _repository;
    public GetByIdEquipmentUseCase(IMapper mapper, IEquipmentsReadOnlyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseEquipmentJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
            throw new NotFoundException("Equipamento não encontrado.");

        return _mapper.Map<ResponseEquipmentJson>(result);
    }
}
