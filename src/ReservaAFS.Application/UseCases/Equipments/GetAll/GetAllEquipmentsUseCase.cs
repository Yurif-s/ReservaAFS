using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Equipments;

namespace ReservaAFS.Application.UseCases.Equipments.GetAll;
public class GetAllEquipmentsUseCase : IGetAllEquipmentsUseCase
{
    private readonly IMapper _mapper;
    private readonly IEquipmentsReadOnlyRepository _repository;
    public GetAllEquipmentsUseCase(IMapper mapper, IEquipmentsReadOnlyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseEquipmentsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseEquipmentsJson
        {
            Equipments = _mapper.Map<List<ResponseEquipmentJson>>(result)
        };
    }
}
