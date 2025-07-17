using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Exception;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Reserves.Delete;
public class DeleteReserveUseCase : IDeleteReserveUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReservesWriteOnlyRepository _repository;
    public DeleteReserveUseCase(IUnitOfWork unitOfWork, IReservesWriteOnlyRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);
        
        if (result is false)
            throw new NotFoundException(ResourceErrorMessages.RESERVE_NOT_FOUND);

        await _unitOfWork.Commit();
    }
}
