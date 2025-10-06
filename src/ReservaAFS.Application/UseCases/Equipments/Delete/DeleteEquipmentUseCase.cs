
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Exception.ExceptionsBase;
using ReservaAFS.Exception;
using ReservaAFS.Domain.Repositories.Equipments;

namespace ReservaAFS.Application.UseCases.Equipments.Delete;
public class DeleteEquipmentUseCase : IDeleteEquipmentUseCase
{
    private readonly IEquipmentsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteEquipmentUseCase(IEquipmentsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result is false)
            throw new NotFoundException("Equipamento não encontrado.");

        await _unitOfWork.Commit();
    }
}
