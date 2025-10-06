using AutoMapper;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Repositories.Users;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Users.GetById;
public class GetByIdUserUseCase : IGetByIdUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUsersReadOnlyRepository _repository;
    public GetByIdUserUseCase(IMapper mapper, IUsersReadOnlyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseUserJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
            throw new NotFoundException("Usuário não encontrado.");

        return _mapper.Map<ResponseUserJson>(result);
    }
}
