
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Users;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Users.Delete;
public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUsersWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserUseCase(IUsersWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result is false)
            throw new NotFoundException("Usuário não encontrado.");

        await _unitOfWork.Commit();
    }
}
