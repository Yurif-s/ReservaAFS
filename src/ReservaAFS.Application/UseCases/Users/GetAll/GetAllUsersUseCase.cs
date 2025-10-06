using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Users;

namespace ReservaAFS.Application.UseCases.Users.GetAll;
public class GetAllUsersUseCase : IGetAllUsersUseCase
{
    private readonly IMapper _mapper;
    private readonly IUsersReadOnlyRepository _repository;
    public GetAllUsersUseCase(IMapper mapper, IUsersReadOnlyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseUsersJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseUsersJson
        {
            Users = _mapper.Map<List<ResponseShortUserJson>>(result)
        };
    }
}
