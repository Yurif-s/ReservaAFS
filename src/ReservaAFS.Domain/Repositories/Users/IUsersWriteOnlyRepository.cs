using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Users;
public interface IUsersWriteOnlyRepository
{
    Task Add(User user);
    /// <summary>
    /// This function return TRUE if the deletion was successful
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
