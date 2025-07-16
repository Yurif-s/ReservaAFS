using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Exception;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Reserves.GetById;
public class GetReserveByIdUseCase : IGetReserveByIdUseCase
{
    private readonly IReservesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetReserveByIdUseCase(IReservesReadOnlyRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseReserveJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
            throw new NotFoundException(ResourceErrorMessages.RESERVE_NOT_FOUND);
         
        return _mapper.Map<ResponseReserveJson>(result);
    }
}
