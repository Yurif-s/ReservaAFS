namespace ReservaAFS.Application.UseCases.Equipments.Delete;
public interface IDeleteEquipmentUseCase
{
    Task Execute(long id);
}
