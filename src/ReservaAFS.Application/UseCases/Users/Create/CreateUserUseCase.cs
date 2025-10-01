using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Exception.ExceptionsBase;
using System.Reflection;

namespace ReservaAFS.Application.UseCases.Users.Create;
public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IMapper _mapper;
    public CreateUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<ResponseCreatedUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        return _mapper.Map<ResponseCreatedUserJson>(user);
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();

        var result = validator.Validate(request);

        var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

        if (!result.IsValid)
            throw new ErrorOnValidationException(errorMessages);
    }
}
