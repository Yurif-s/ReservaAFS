using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Domain.Repositories.Users;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Exception.ExceptionsBase;
using ReservaAFS.Domain.Security;

namespace ReservaAFS.Application.UseCases.Users.ChangePassword;
public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUsersWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public ChangePasswordUseCase(
        IMapper mapper,
        IPasswordEncripter passwordEncripter,
        IUsersWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _repository = repository;
        _unitOfWork = unitOfWork;       
    }
    public async Task Execute(RequestChangePasswordJson request)
    {
        Validate(request);
        

    }
    private void Validate(RequestChangePasswordJson request)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(request);

        var passwordMatch = _passwordEncripter.Verify(request.Password, "");

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
