using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Users;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Users.Update;
public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUsersUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserUseCase(IMapper mapper,IUsersUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id, RequestUserJson request)
    {
        Validate(request);

        var user = await _repository.GetById(id);

        if (user is null)
            throw new NotFoundException("Usuário não encontrado.");

        _mapper.Map(request, user);

        _repository.Update(user);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
