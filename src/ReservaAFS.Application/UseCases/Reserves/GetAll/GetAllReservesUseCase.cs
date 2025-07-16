using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Reserves;

namespace ReservaAFS.Application.UseCases.Reserves.GetAll;
public class GetAllReservesUseCase : IGetAllReservesUseCase
{
    private readonly IReservesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllReservesUseCase(IReservesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseReservesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseReservesJson
        {
            Reserves = _mapper.Map<List<ResponseShortReserveJson>>(result)
        };
    }
}
